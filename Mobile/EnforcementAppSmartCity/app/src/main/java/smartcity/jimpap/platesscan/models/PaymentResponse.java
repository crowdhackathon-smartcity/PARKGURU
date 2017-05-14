package smartcity.jimpap.platesscan.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/**
 * Created by dpapa on 13/5/2017.
 */

public class PaymentResponse {
    @SerializedName("Id")
    @Expose
    private Integer id;
    @SerializedName("ParkingSpotId")
    @Expose
    private Integer parkingSpotId;
    @SerializedName("MemberId")
    @Expose
    private Integer memberId;
    @SerializedName("APIKey")
    @Expose
    private String aPIKey;
    @SerializedName("VehiclePlate")
    @Expose
    private String vehiclePlate;
    @SerializedName("Start")
    @Expose
    private String start;
    @SerializedName("Duration")
    @Expose
    private Integer duration;
    @SerializedName("Ticket")
    @Expose
    private Tickets ticket;
}
