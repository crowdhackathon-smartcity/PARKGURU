package project.smartcity.com.smartcityapp.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;

import com.google.gson.Gson;
import com.stepstone.stepper.StepperLayout;
import com.stepstone.stepper.VerificationError;

import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.DataManager;
import project.smartcity.com.smartcityapp.adapters.StepperAdapter;
import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.UserTicket;

public class BookTicketActivity extends AppCompatActivity implements StepperLayout.StepperListener,DataManager {


    private StepperLayout mStepperLayout;
    private ParkingSpot parkingSpot;
    private UserTicket userTicket;
    private static String SelectedParkingSpotKey = "pSKey";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_book_ticket);
        getSupportActionBar().setTitle("Park on Street");

        Intent intent = getIntent();
        String selectedParkingSpotPassData = intent.getStringExtra(SelectedParkingSpotKey);
        Gson gson = new Gson();
        parkingSpot = gson.fromJson(selectedParkingSpotPassData, ParkingSpot.class);

        // i ll use this for stepper
        //https://github.com/stepstone-tech/android-material-stepper#stepperlayout-attributes
        mStepperLayout = (StepperLayout) findViewById(R.id.stepperLayout);
        mStepperLayout.setAdapter(new StepperAdapter(getSupportFragmentManager(), this));

    }

    @Override
    public void onCompleted(View completeButton) {

    }

    @Override
    public void onError(VerificationError verificationError) {

    }

    @Override
    public void onStepSelected(int newStepPosition) {

    }

    @Override
    public void onReturn() {

    }


    @Override
    public void saveParkingSpot(ParkingSpot data) {
        parkingSpot = data;
    }

    @Override
    public void saveUserTicket(UserTicket userTicketValue) {
        userTicket = userTicketValue;
    }



    @Override
    public ParkingSpot getParkingSpot() {
        return parkingSpot;
    }

    @Override
    public UserTicket getUserTicket() {
        return userTicket;
    }
}
