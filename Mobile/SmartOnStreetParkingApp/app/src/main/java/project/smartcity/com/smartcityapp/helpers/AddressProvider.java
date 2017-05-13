package project.smartcity.com.smartcityapp.helpers;

import android.content.Context;
import android.location.Address;
import android.location.Geocoder;

import com.google.android.gms.maps.model.LatLng;

import java.io.IOException;
import java.util.List;
import java.util.Locale;

/**
 * Created by jimpap
 */

public class AddressProvider {

    private Context mContext;
    //Gets the address from Geocoder ,
    public AddressProvider (Context context){
        this.mContext = context;
    }

    public String getAddress(LatLng latLng) {
        String addressStr = null;
        try {
            Geocoder geocoder = new Geocoder(mContext, Locale.getDefault());
            List<Address> listOfAddresses = null;
            try {
                listOfAddresses = geocoder.getFromLocation(latLng.latitude, latLng.longitude, 1);
            } catch (IOException e) {
                e.printStackTrace();
                return null;
            }
            if (listOfAddresses != null || listOfAddresses.size() > 0) {
                Address address = listOfAddresses.get(0);
                addressStr = address.getAddressLine(0) != null ? address.getAddressLine(0) + "" + "" : "";
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return addressStr;
    }
}
