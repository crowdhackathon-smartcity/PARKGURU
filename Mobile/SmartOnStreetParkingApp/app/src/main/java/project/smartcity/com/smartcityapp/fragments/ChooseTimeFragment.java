package project.smartcity.com.smartcityapp.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.UiThread;
import android.support.v4.app.Fragment;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.stepstone.stepper.BlockingStep;
import com.stepstone.stepper.StepperLayout;
import com.stepstone.stepper.VerificationError;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import io.realm.Realm;
import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.DataManager;
import project.smartcity.com.smartcityapp.api.RestInterface;
import project.smartcity.com.smartcityapp.api.RestService;
import project.smartcity.com.smartcityapp.models.CalculateTicketsRequest;
import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.Plates;
import project.smartcity.com.smartcityapp.models.Tickets;
import project.smartcity.com.smartcityapp.models.UserTicket;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * Created by jimpap
 */

public class ChooseTimeFragment extends Fragment implements BlockingStep {

    private DataManager dataManager;

    List<String> availableTimeList;

    List<Integer> minutes;
    TextView allowedTime;
    EditText plateNumber;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.step_sec_fr_select, container, false);
        //getting the time for display purposes
        availableTimeList = new ArrayList<>(Arrays.asList(getResources().getStringArray(R.array.timeList)));

        allowedTime = (TextView) view.findViewById(R.id.allowed_time);

        plateNumber = (EditText) view.findViewById(R.id.plates);

        //creating an array of integers representing the time list
        Integer[] timeListOnMinutes = {15, 60, 120, 180, 360, 720, 1440};
        minutes = new ArrayList<>(Arrays.asList(timeListOnMinutes));
        //setting up view and listeners
        final Spinner timeList = (Spinner) view.findViewById(R.id.time_list);
        ArrayAdapter<String> spinnerArrayAdapter = new ArrayAdapter<>(getActivity(), android.R.layout.simple_spinner_item, availableTimeList);
        spinnerArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        timeList.setAdapter(spinnerArrayAdapter);

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
        String plateNumberTxt = plateNumber.getText().toString();
        if (TextUtils.isEmpty(plateNumberTxt)) {
            plateNumber.setError("Empty Plates");
        } else {
            callback.getStepperLayout().showProgress("Complete Book  please wait...");
            UserTicket userTicket = dataManager.getUserTicket();
            userTicket.setVehiclePlates(plateNumberTxt);
            dataManager.saveUserTicket(userTicket);
            //continue
            Realm realm = Realm.getDefaultInstance();
            realm.beginTransaction();
            Plates plates = new Plates();
            plates.setPlates(plateNumberTxt);
            realm.copyToRealmOrUpdate(plates);
            realm.commitTransaction();

            //call compute ticket  for the user selection of the user
            //also keep the payable amount.
            RestInterface restInterface = RestService.getRestApiInterface();
            CalculateTicketsRequest calculateTicketsRequest = new CalculateTicketsRequest();
            calculateTicketsRequest.setDuration(dataManager.getUserTicket().getParkTime());
            calculateTicketsRequest.setSpotId(dataManager.getParkingSpot().getId());
            calculateTicketsRequest.setVehiclePlates(plates.getPlates());

            realm.close();
            Call<Tickets> call = restInterface.calculateTickets(calculateTicketsRequest);
            call.enqueue(new Callback<Tickets>() {
                @Override
                public void onResponse(Call<Tickets> call, Response<Tickets> response) {
                    if (response.isSuccessful()) {
                        ParkingSpot parkingSpot = dataManager.getParkingSpot();
                        //update the ticket to parking spot
                        parkingSpot.setTickets(response.body());
                        dataManager.saveParkingSpot(parkingSpot);
                        callback.getStepperLayout().hideProgress();
                        callback.goToNextStep();

                    } else {
                        callback.getStepperLayout().hideProgress();
                    }

                }

                @Override
                public void onFailure(Call<Tickets> call, Throwable t) {
                    callback.getStepperLayout().hideProgress();
                }
            });
        }

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
        int parkingTimeRestriction = dataManager.getParkingSpot().getParkingMaxDuration();
        //fixing list based on zone time limit
        for (Integer s : new ArrayList<>(minutes)) {
            if (s > parkingTimeRestriction) {
                int index = minutes.indexOf(s);
                minutes.remove(s);
                minutes.indexOf(s);
                availableTimeList.remove(index);
            }
        }

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
        String allowedTimeTxt = Integer.toString(dataManager.getParkingSpot().getParkingMaxDuration()) + " Minutes";
        allowedTime.setText(allowedTimeTxt);
        calculateAvailableParkingTime();
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