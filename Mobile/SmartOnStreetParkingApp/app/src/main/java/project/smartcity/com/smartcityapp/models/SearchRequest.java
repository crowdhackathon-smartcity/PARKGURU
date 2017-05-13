package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/** Model to construct a search request so we can retrieve ParkingSpots
 *  latitude and longitude is the center of the map when user presses search
 *  duration is the time that user selects to park his vehicle (i am gonna use one hour as default)
 *  search distance is the radius that the search will cover
 *
 * Created by jimpap
 */

public class SearchRequest {
    @SerializedName("Longitude")
    @Expose
    private Double longitude;
    @SerializedName("Latitude")
    @Expose
    private Double latitude;
    @SerializedName("Duration")
    @Expose
    private Integer duration;
    @SerializedName("SearchDistance")
    @Expose
    private Integer searchDistance;
    @SerializedName("VehiclePlate")
    @Expose
    private String vehiclePlates;



    public Double getLongitude() {
        return longitude;
    }

    public void setLongitude(Double longitude) {
        this.longitude = longitude;
    }

    public Double getLatitude() {
        return latitude;
    }

    public void setLatitude(Double latitude) {
        this.latitude = latitude;
    }

    public Integer getDuration() {
        return duration;
    }

    public void setDuration(Integer duration) {
        this.duration = duration;
    }

    public Integer getSearchDistance() {
        return searchDistance;
    }

    public void setSearchDistance(Integer searchDistance) {
        this.searchDistance = searchDistance;
    }

    public String getVehiclePlates() {
        return vehiclePlates;
    }

    public void setVehiclePlates(String vehiclePlates) {
        this.vehiclePlates = vehiclePlates;
    }
}
