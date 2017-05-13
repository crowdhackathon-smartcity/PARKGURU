package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/** An array of tickets that needed in order to book the ParkingSpot.
 *  Maybe one or more cause a ParkingSpot may need more than one ticket
 *  based on the duration of the parking (e.g TimeOfParking = 2hours , 1 Hour Ticket = 2 Euros)
 * Created by jimpap
 */

public class Ticket {
    @SerializedName("SN")
    @Expose
    private String sN;
    @SerializedName("Duration")
    @Expose
    private Integer duration;
    @SerializedName("Price")
    @Expose
    private Double price;


    public String getsN() {
        return sN;
    }

    public void setsN(String sN) {
        this.sN = sN;
    }

    public Integer getDuration() {
        return duration;
    }

    public void setDuration(Integer duration) {
        this.duration = duration;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }
}
