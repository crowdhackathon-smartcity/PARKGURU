package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/** Model that represents the request for tickets
 * The spotId is the id of the parkingSpot
 * Duration the time the user needs to park (in minutes)
 * Created by jimpap
 */

public class CalculateTicketsRequest {
    @SerializedName("SpotId")
    @Expose
    private Integer spotId;
    @SerializedName("Duration")
    @Expose
    private Integer duration;


    public Integer getSpotId() {
        return spotId;
    }

    public void setSpotId(Integer spotId) {
        this.spotId = spotId;
    }

    public Integer getDuration() {
        return duration;
    }

    public void setDuration(Integer duration) {
        this.duration = duration;
    }
}
