package project.smartcity.com.smartcityapp.fragments;

import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.annotation.UiThread;
import android.support.v4.app.Fragment;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import com.stepstone.stepper.BlockingStep;
import com.stepstone.stepper.StepperLayout;
import com.stepstone.stepper.VerificationError;

import java.util.Locale;

import io.realm.Realm;
import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.DataManager;
import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.Plates;
import project.smartcity.com.smartcityapp.models.UserTicket;

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

    private void payForTicket() {
        //save into database and finish
        getActivity().finish();
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
            new Handler().postDelayed(new Runnable() {
                @Override
                public void run() {
                    callback.complete();
                    callback.getStepperLayout().hideProgress();
                    payForTicket();
                }
            }, 2000L);



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
