package project.smartcity.com.smartcityapp.fragments;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import java.util.ArrayList;

import io.realm.Realm;
import io.realm.RealmResults;
import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.BookingsAdapter;
import project.smartcity.com.smartcityapp.api.RestInterface;
import project.smartcity.com.smartcityapp.api.RestService;
import project.smartcity.com.smartcityapp.models.PaymentResponse;
import project.smartcity.com.smartcityapp.models.Plates;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class BookingHistoryFragment extends Fragment {

    private OnHistoryBookingFragmentListener mListener;

    public BookingHistoryFragment() {
    }

    //the idea is to persist the bookings as well but due to time limitations
    //i am going to just display them through an api call


    private RecyclerView recyclerView;
    BookingsAdapter bookingsAdapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_booking_history, container, false);
        ArrayList<PaymentResponse> paymentResponseArrayList = new ArrayList<>();

        recyclerView = (RecyclerView) view.findViewById(R.id.recycler_view);
        Realm realm = Realm.getDefaultInstance();
        //time is short this should be done with findAllAsync and register a realm listener
        RealmResults<Plates> realmResults = realm.where(Plates.class).findAll();
        ArrayList<Plates> platesArrayList = new ArrayList<Plates>(realmResults);
        final ArrayList<String> platesTxt = new ArrayList<>();
        platesTxt.add("Choose Plates");
        for (Plates plates : platesArrayList) {
            platesTxt.add(plates.getPlates());
        }
        //time is chasing me this is messed up implementation
        //just add a custom title quick
        final Spinner addressSpinner = (Spinner) view.findViewById(R.id.addressList);
        ArrayAdapter<String> spinnerArrayAdapter = new ArrayAdapter<>(getActivity(), android.R.layout.simple_spinner_item, platesTxt);
        spinnerArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        addressSpinner.setAdapter(spinnerArrayAdapter);

        addressSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int pos, long l) {
                try {
                    String platesSelected = addressSpinner.getSelectedItem().toString();
                    RestInterface restInterface = RestService.getRestApiInterface();
                    Call<ArrayList<PaymentResponse> > call = restInterface.getPayments(platesSelected, RestService.API_KEY);
                    call.enqueue(new Callback<ArrayList<PaymentResponse>>() {
                        @Override
                        public void onResponse(Call<ArrayList<PaymentResponse> > call, Response<ArrayList<PaymentResponse> > response) {
                            if (response.isSuccessful()) {
                                bookingsAdapter.setResults(response.body());
                            } else {
                               // resultTextView.setText("Vehicle with plate not available");
                            }
                        }

                        @Override
                        public void onFailure(Call<ArrayList<PaymentResponse>> call, Throwable t) {

                        }
                    });

                } catch (Exception e) {
                    e.printStackTrace();
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });



        bookingsAdapter = new BookingsAdapter(getActivity(), paymentResponseArrayList);
        RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(getActivity());
        recyclerView.setLayoutManager(mLayoutManager);
        recyclerView.setItemAnimator(new DefaultItemAnimator());
        recyclerView.setAdapter(bookingsAdapter);

        return view;
    }

    // TODO: Rename method, update argument and hook method into UI event
    public void onButtonPressed(Uri uri) {
        if (mListener != null) {
        }
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnHistoryBookingFragmentListener) {
            mListener = (OnHistoryBookingFragmentListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnHistoryBookingFragmentListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }


    public interface OnHistoryBookingFragmentListener {

    }
}
