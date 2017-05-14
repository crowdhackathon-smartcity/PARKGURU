package project.smartcity.com.smartcityapp.fragments;

import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.annotation.UiThread;
import android.support.v4.app.Fragment;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.stepstone.stepper.BlockingStep;
import com.stepstone.stepper.StepperLayout;
import com.stepstone.stepper.VerificationError;

import java.util.Locale;

import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.DataManager;
import project.smartcity.com.smartcityapp.api.RestInterface;
import project.smartcity.com.smartcityapp.api.RestService;
import project.smartcity.com.smartcityapp.models.PaymentRequest;
import project.smartcity.com.smartcityapp.models.PaymentResponse;
import project.smartcity.com.smartcityapp.models.UserTicket;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by jimpap on 5/10/17.
 */

public class CompleteBookFragment extends Fragment implements BlockingStep {

    private DataManager dataManager;
    TextView parkingTime, amountToPay;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.step_third_fr_complete, container, false);
        parkingTime = (TextView) view.findViewById(R.id.time_parking);
        amountToPay = (TextView) view.findViewById(R.id.amount_pay);

        return view;
    }

    private void completePayment() {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setMessage("Payment Complete")
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        getActivity().finish();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();

    }

    @Override
    @UiThread
    public void onNextClicked(final StepperLayout.OnNextClickedCallback callback) {
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                callback.goToNextStep();
            }
        }, 2000L);
    }

    @Override
    @UiThread
    public void onCompleteClicked(final StepperLayout.OnCompleteClickedCallback callback) {
        callback.getStepperLayout().showProgress("Making Payment  please wait...");

        PaymentRequest paymentRequest = new PaymentRequest();
        paymentRequest.setVehiclePlates(dataManager.getUserTicket().getVehiclePlates());
        paymentRequest.setSpotId(dataManager.getParkingSpot().getId());
        paymentRequest.setTickets(dataManager.getParkingSpot().getTickets());
        paymentRequest.setApiKey(RestService.API_KEY);

        RestInterface restInterface = RestService.getRestApiInterface();
        Call<PaymentResponse> call = restInterface.createPayment(paymentRequest);
        call.enqueue(new Callback<PaymentResponse>() {
            @Override
            public void onResponse(Call<PaymentResponse> call, Response<PaymentResponse> response) {
                if (response.isSuccessful()) {
                    completePayment();
                } else {
                    Toast.makeText(getActivity(), "Something went wrong", Toast.LENGTH_SHORT).show();
                }
                callback.getStepperLayout().hideProgress();
            }

            @Override
            public void onFailure(Call<PaymentResponse> call, Throwable t) {
                Toast.makeText(getActivity(), "Something went wrong", Toast.LENGTH_SHORT).show();
                callback.getStepperLayout().hideProgress();
            }
        });


    }

    @Override
    @UiThread
    public void onBackClicked(StepperLayout.OnBackClickedCallback callback) {
        callback.goToPrevStep();
    }

    @Override
    public VerificationError verifyStep() {
        return null;
    }

    @Override
    public void onSelected() {
        UserTicket userTicket = dataManager.getUserTicket();
        if (userTicket != null) {
            parkingTime.setText(userTicket.getParkTimeText());
            Double parkingSpotPrice = dataManager.getParkingSpot().getTickets().getPrice();
            //down to two decimals
            amountToPay.setText("€" + " " + String.format(Locale.getDefault(), "%.2f", parkingSpotPrice));
        }
    }

    @Override
    public void onError(@NonNull VerificationError error) {

    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof DataManager) {
            dataManager = (DataManager) context;
        } else {
            throw new IllegalStateException("Activity must implement DataManager interface!");
        }
    }

}
