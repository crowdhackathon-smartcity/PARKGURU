package project.smartcity.com.smartcityapp.adapters;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.IntRange;
import android.support.annotation.NonNull;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;

import com.stepstone.stepper.Step;
import com.stepstone.stepper.adapter.AbstractFragmentStepAdapter;
import com.stepstone.stepper.viewmodel.StepViewModel;

import project.smartcity.com.smartcityapp.fragments.ZoneInfoFragment;
import project.smartcity.com.smartcityapp.fragments.ChooseTimeFragment;
import project.smartcity.com.smartcityapp.fragments.CompleteBookFragment;

/**
 * Created by jimpap
 */

public class StepperAdapter extends AbstractFragmentStepAdapter {

    public StepperAdapter(FragmentManager fm, Context context) {
        super(fm, context);
    }

    @Override
    public Step createStep(int position) {
        Fragment step;
        Bundle b;
        switch (position) {
            case 0:
                step = new ZoneInfoFragment();
                b = new Bundle();
                b.putInt("stepPosition", position);
                step.setArguments(b);
                return (ZoneInfoFragment) step;
            case 1:
                step = new ChooseTimeFragment();
                b = new Bundle();
                b.putInt("stepPosition", position);
                step.setArguments(b);
                return (ChooseTimeFragment) step;
            case 2:
                step = new CompleteBookFragment();
                b = new Bundle();
                b.putInt("stepPosition", position);
                step.setArguments(b);
                return (CompleteBookFragment) step;
            default:
                return null;
        }


    }

    @Override
    public int getCount() {
        return 3;
    }

    @NonNull
    @Override
    public StepViewModel getViewModel(@IntRange(from = 0) int position) {
        StepViewModel.Builder builder = new StepViewModel.Builder(context);
        switch (position) {
            case 0:
                builder
                        .setNextButtonLabel("Choose Time")
                        .setBackButtonLabel("Cancel")
                        .setTitle("Zone Info")
                        .setBackButtonStartDrawableResId(StepViewModel.NULL_DRAWABLE);

                break;
            case 1:
                builder
                        .setTitle("Choose Time")
                        .setNextButtonLabel("Complete Booking")
                        .setBackButtonLabel("Go back");
                break;
            case 2:
                builder.setTitle("Complete Book")
                        .setNextButtonLabel(null)
                        .setBackButtonLabel("Go back");

                break;
            default:
                throw new IllegalArgumentException("Unsupported position: " + position);
        }
        return builder.create();
    }
}