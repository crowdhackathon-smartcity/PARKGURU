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
import project.smartcity.com.smartcityapp.models.Plates;
import project.smartcity.com.smartcityapp.models.UserTicket;

/**
 * Created by jimpap on 5/10/17.
 */

public class CompleteBookFragment extends Fragment implements BlockingStep {

    private DataManager dataManager;
    TextView parkingTime, amountToPay;
    EditText plateNumber;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.step_third_fr_complete, container, false);
        parkingTime = (TextView) view.findViewById(R.id.time_parking);
        amountToPay = (TextView) view.findViewById(R.id.amount_pay);
        plateNumber = (EditText) view.findViewById(R.id.plates);

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
        String plateNumberTxt = plateNumber.getText().toString();
        if (TextUtils.isEmpty(plateNumberTxt)) {
            plateNumber.setError("Empty Plates");
        } else {
            //continue
            callback.getStepperLayout().showProgress("Complete Book  please wait...");
            Realm realm = Realm.getDefaultInstance();
            realm.beginTransaction();
            Plates plates = new Plates();
            plates.setPlates(plateNumberTxt);
            realm.copyToRealmOrUpdate(plates);
            realm.commitTransaction();
            realm.close();

            new Handler().postDelayed(new Runnable() {
                @Override
                public void run() {
                    callback.complete();
                    callback.getStepperLayout().hideProgress();
                    payForTicket();
                }
            }, 2000L);

        }

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
        Realm realm = Realm.getDefaultInstance();
        Plates plates = realm.where(Plates.class).findFirst();
        if (plates != null && plates.isValid()) {
            plateNumber.setText(plates.getPlates());
        }
        realm.close();
        UserTicket userTicket = dataManager.getUserTicket();
        if (userTicket != null) {
            parkingTime.setText(userTicket.getParkTimeText());
            //down to two decimals
            amountToPay.setText("€" + " " + String.format(Locale.getDefault(), "%.2f", userTicket.getAmountToPay()));
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
