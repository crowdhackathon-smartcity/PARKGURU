package project.smartcity.com.smartcityapp.adapters;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;

import io.realm.RealmResults;
import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.models.Booking;

/**
 * Created by jimpap
 */

public class BookingsAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    private LayoutInflater mInflater;
    private Context mContext;
    private ArrayList<Booking> mResults;


    public BookingsAdapter(Context context, ArrayList<Booking> results) {
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
        final Booking booking = mResults.get(position);



    }

    @Override
    public int getItemCount() {
        return mResults.size();
    }

    public void setResults(ArrayList<Booking> results) {
        mResults = results;
        notifyDataSetChanged();
    }

    public static class BookingItem extends RecyclerView.ViewHolder {
        public TextView zoneName, address, timeParked, amountPayed;


        public BookingItem(View view) {
            super(view);
            zoneName = (TextView) view.findViewById(R.id.zone_name);
            address = (TextView) view.findViewById(R.id.address);
            timeParked = (TextView) view.findViewById(R.id.time_parked);
            amountPayed = (TextView) view.findViewById(R.id.amount_pay);

        }

    }
}
