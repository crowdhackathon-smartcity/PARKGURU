package project.smartcity.com.smartcityapp.fragments;

import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.annotation.UiThread;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Spinner;

import com.stepstone.stepper.BlockingStep;
import com.stepstone.stepper.StepperLayout;
import com.stepstone.stepper.VerificationError;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.DataManager;
import project.smartcity.com.smartcityapp.models.UserTicket;

/**
 * Created by jimpap
 */

public class ChooseTimeFragment extends Fragment implements BlockingStep {

    private DataManager dataManager;

    List<String> availableTimeList;

    List<Integer> minutes;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.step_sec_fr_select, container, false);
        //getting the time for display purposes
        availableTimeList = new ArrayList<>(Arrays.asList(getResources().getStringArray(R.array.timeList)));
        //creating an array of integers representing the time list
        Integer[] timeListOnMinutes = {15, 60, 120, 180, 360, 720, 1440};
        minutes = new ArrayList<>(Arrays.asList(timeListOnMinutes));
        //setting up view and listeners
        final Spinner timeList = (Spinner) view.findViewById(R.id.time_list);
        timeList.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int pos, long l) {
                try {
                    //save the selection of the user
                    int minutesToPark = minutes.get(pos);
                    String minutesToParkTxt = timeList.getSelectedItem().toString();
                    UserTicket userTicket = dataManager.getUserTicket();
                    if (userTicket == null) {
                        userTicket = new UserTicket();
                    }
                    userTicket.setParkTimeText(minutesToParkTxt);
                    userTicket.setParkTime(minutesToPark);
                    dataManager.saveUserTicket(userTicket);
                } catch (Exception e) {
                    e.printStackTrace();
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });

        return view;
    }


    @Override
    @UiThread
    public void onNextClicked(final StepperLayout.OnNextClickedCallback callback) {
        callback.getStepperLayout().showProgress("Operation in progress, please wait...");
        //call compute ticket  for the user selection of the user
        //also keep the payable amount.
        UserTicket userTicket = dataManager.getUserTicket();
        //set the ticket value
        if (userTicket != null) {
            userTicket.setAmountToPay(2.3);
        }
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                callback.goToNextStep();
                callback.getStepperLayout().hideProgress();
            }
        }, 2000L);
    }

    @Override
    @UiThread
    public void onCompleteClicked(final StepperLayout.OnCompleteClickedCallback callback) {

    }

    @Override
    @UiThread
    public void onBackClicked(StepperLayout.OnBackClickedCallback callback) {
        callback.goToPrevStep();
    }


    //by getting the maximum parking allowed of the zone we  need to calculate the available option on the time list
    //The time list has values from 15 mins to 24 hours but if the restriction of the zone is eg. on 2 hours then we need
    //to handle the display to the user .
    private void calculateAvailableParkingTime() {
//        if (venueData.getVenueRestrictions() != null) {
//            int zoneLimitTime;
//            if (isExtend) {
//                zoneLimitTime = venueData.getVenueRestrictions().getMaxTimeParkingAllowed() - (int) timeAlreadyParked;
//            } else {
//                zoneLimitTime = venueData.getVenueRestrictions().getMaxTimeParkingAllowed();
//            }
//            //fixing list based on zone time limit
//            for (Integer s : new ArrayList<>(minutes)) {
//                if (s > zoneLimitTime) {
//                    int index = minutes.indexOf(s);
//                    minutes.remove(s);
//                    minutes.indexOf(s);
//                    timesList.remove(index);
//                }
//            }
//        }
    }

    @Override
    public VerificationError verifyStep() {
        return null;
    }

    @Override
    public void onSelected() {

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