package project.smartcity.com.smartcityapp.models;

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


    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getParkingSpotId() {
        return parkingSpotId;
    }

    public void setParkingSpotId(Integer parkingSpotId) {
        this.parkingSpotId = parkingSpotId;
    }

    public Integer getMemberId() {
        return memberId;
    }

    public void setMemberId(Integer memberId) {
        this.memberId = memberId;
    }

    public String getaPIKey() {
        return aPIKey;
    }

    public void setaPIKey(String aPIKey) {
        this.aPIKey = aPIKey;
    }

    public String getVehiclePlate() {
        return vehiclePlate;
    }

    public void setVehiclePlate(String vehiclePlate) {
        this.vehiclePlate = vehiclePlate;
    }

    public String getStart() {
        return start;
    }

    public void setStart(String start) {
        this.start = start;
    }

    public Integer getDuration() {
        return duration;
    }

    public void setDuration(Integer duration) {
        this.duration = duration;
    }

    public Tickets getTicket() {
        return ticket;
    }

    public void setTicket(Tickets ticket) {
        this.ticket = ticket;
    }
}
