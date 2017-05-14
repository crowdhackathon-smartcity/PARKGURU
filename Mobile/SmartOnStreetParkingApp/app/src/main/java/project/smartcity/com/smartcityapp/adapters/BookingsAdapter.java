package project.smartcity.com.smartcityapp.adapters;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Locale;

import io.realm.RealmResults;
import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.models.Booking;
import project.smartcity.com.smartcityapp.models.PaymentResponse;

/**
 * Created by jimpap
 */

public class BookingsAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    private LayoutInflater mInflater;
    private Context mContext;
    private ArrayList<PaymentResponse> mResults;


    public BookingsAdapter(Context context, ArrayList<PaymentResponse> results) {
        mInflater = LayoutInflater.from(context);
        mContext = context;
        setResults(results);
    }


    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext()).inflate(R.layout.booking_list_row, parent, false);
        return new BookingItem(itemView);
    }

    @Override
    public void onBindViewHolder(RecyclerView.ViewHolder holder, int position) {
        final PaymentResponse paymentResponse = mResults.get(position);

        ((BookingItem) holder).timeParked.setText(String.valueOf(paymentResponse.getDuration())+ " Minutes");
        ((BookingItem) holder).amountPayed.setText("€" + " " + String.format(Locale.getDefault(), "%.2f", paymentResponse.getTicket().getPrice()));



    }

    @Override
    public int getItemCount() {
        return mResults.size();
    }

    public void setResults(ArrayList<PaymentResponse> results) {
        mResults = results;
        notifyDataSetChanged();
    }

    public static class BookingItem extends RecyclerView.ViewHolder {
        public TextView timeParked, amountPayed;


        public BookingItem(View view) {
            super(view);

            timeParked = (TextView) view.findViewById(R.id.time_parked);
            amountPayed = (TextView) view.findViewById(R.id.amount_pay);

        }

    }
}
