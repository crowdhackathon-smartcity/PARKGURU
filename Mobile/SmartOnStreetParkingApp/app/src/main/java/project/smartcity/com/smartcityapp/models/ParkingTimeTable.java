package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

/** A timetable of the ParkingSpot
 * Created by jimpap
 */

public class ParkingTimeTable {
    @SerializedName("Days")
    @Expose
    private Integer days;
    @SerializedName("Start")
    @Expose
    private String start;
    @SerializedName("End")
    @Expose
    private String end;


    public Integer getDays() {
        return days;
    }

    public void setDays(Integer days) {
        this.days = days;
    }

    public String getStart() {
        return start;
    }

    public void setStart(String start) {
        this.start = start;
    }

    public String getEnd() {
        return end;
    }

    public void setEnd(String end) {
        this.end = end;
    }
}
