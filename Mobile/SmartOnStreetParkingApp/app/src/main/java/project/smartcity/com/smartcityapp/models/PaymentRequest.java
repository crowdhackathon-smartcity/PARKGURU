package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/**
 * Created by dpapa on 13/5/2017.
 */

public class PaymentRequest {
    @SerializedName("SpotId")
    @Expose
    private Integer spotId;

    @SerializedName("SpotTickets")
    @Expose
    private Tickets tickets;

    @SerializedName("VehiclePlate")
    @Expose
    private String vehiclePlates;

    @SerializedName("APIkey")
    @Expose
    private String apiKey;


    public Integer getSpotId() {
        return spotId;
    }

    public void setSpotId(Integer spotId) {
        this.spotId = spotId;
    }

    public Tickets getTickets() {
        return tickets;
    }

    public void setTickets(Tickets tickets) {
        this.tickets = tickets;
    }

    public String getVehiclePlates() {
        return vehiclePlates;
    }

    public void setVehiclePlates(String vehiclePlates) {
        this.vehiclePlates = vehiclePlates;
    }

    public String getApiKey() {
        return apiKey;
    }

    public void setApiKey(String apiKey) {
        this.apiKey = apiKey;
    }
}
