package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;

/**
 * This model is persisted and contains vital info
 * on the booking.
 *
 * Created by jimpap
 */

public class Booking extends RealmObject {

    @PrimaryKey
    @SerializedName("Id")
    @Expose
    private Integer id;
}
