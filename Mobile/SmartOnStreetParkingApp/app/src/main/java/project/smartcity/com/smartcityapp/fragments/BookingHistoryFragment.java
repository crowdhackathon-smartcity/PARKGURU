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

import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.BookingsAdapter;

public class BookingHistoryFragment extends Fragment {

    private OnHistoryBookingFragmentListener mListener;

    public BookingHistoryFragment() {
    }


    private RecyclerView recyclerView;
    BookingsAdapter bookingsAdapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_booking_history, container, false);
        recyclerView = (RecyclerView) view.findViewById(R.id.recycler_view);
        //load realm results on adapter

        bookingsAdapter = new BookingsAdapter(getActivity(), null);
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
