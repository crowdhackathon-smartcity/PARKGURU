package project.smartcity.com.smartcityapp.fragments;

import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.google.android.gms.maps.model.LatLng;
import com.squareup.picasso.Picasso;
import com.stepstone.stepper.Step;
import com.stepstone.stepper.VerificationError;

import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.adapters.DataManager;
import project.smartcity.com.smartcityapp.helpers.AddressProvider;
import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.UserTicket;

/**
 * Created by jimpap
 */

public class ZoneInfoFragment extends Fragment implements Step {


    private DataManager dataManager;
    AddressProvider addressProvider;
    TextView addressInput, zoneName, zoneInfo;
    ImageView zoneImage;


    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        addressProvider = new AddressProvider(getActivity());
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.step_first_fr_info, container, false);
        addressInput = (TextView) view.findViewById(R.id.address_input);
        zoneName = (TextView) view.findViewById(R.id.zone_name);
        zoneInfo = (TextView) view.findViewById(R.id.zone_info);
        zoneImage = (ImageView) view.findViewById(R.id.zone_image);
        return view;
    }

    @Override
    public VerificationError verifyStep() {
        //return null if the user can go to the next step, create a new VerificationError instance otherwise
        return null;
    }

    @Override
    public void onSelected() {
        //update UI when selected
        final ParkingSpot data = dataManager.getParkingSpot();
        zoneName.setText(data.getZoneName());
        zoneInfo.setText(data.getZoneInfo());
        String logo = data.getProviderLogo();
        if (logo != null) {
            Picasso.with(getActivity()).load(logo).fit().centerCrop().error(R.drawable.sos_parking).into(zoneImage);
        }
        //load address in another thread (this should be done on an background thread)
        //but Geocoder doesn't take too much to respond so we are ok for now.
        Thread thread = new Thread(new Runnable() {
            @Override
            public void run() {
                LatLng latLng = new LatLng(data.getGeometryEdges().get(0).getLatitude(),data.getGeometryEdges().get(0).getLongitude());
                String address = addressProvider.getAddress(latLng);
                handler.sendMessage(Message.obtain(handler, 100, address));
            }
        });
        thread.start();


    }

    @Override
    public void onError(@NonNull VerificationError error) {
        //handle error inside of the fragment, e.g. show error on EditText
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


    @SuppressWarnings("unchecked")
    private Handler handler = new Handler() {
        @Override
        public void handleMessage(Message msg) {
            String addressString = (String) msg.obj;
            UserTicket userTicket = dataManager.getUserTicket();
            if (userTicket == null) {
                userTicket = new UserTicket();
            }
            if (addressString != null) {
                userTicket.setAddress(addressString);
                dataManager.saveUserTicket(userTicket);
                addressInput.setText(addressString);
            }
        }
    };

}