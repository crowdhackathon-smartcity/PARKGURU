package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.ArrayList;

/** All info of the ParkingSpot that SearchRequest returns
 * Created by jimpap
 */

public class ParkingSpot {
    @SerializedName("ProviderId")
    @Expose
    private Integer providerId;
    @SerializedName("ProviderName")
    @Expose
    private String providerName;
    @SerializedName("ProviderLogo")
    @Expose
    private String providerLogo;
    @SerializedName("ZoneId")
    @Expose
    private Integer zoneId;
    @SerializedName("ZoneName")
    @Expose
    private String zoneName;
    @SerializedName("ZoneInfo")
    @Expose
    private String zoneInfo;
    @SerializedName("ZoneIsPaying")
    @Expose
    private Boolean zoneIsPaying;
    @SerializedName("ParkingTimeTable")
    @Expose
    private ArrayList<ParkingTimeTable> parkingTimeTable = null;
    @SerializedName("ParkingMaxDuration")
    @Expose
    private Integer parkingMaxDuration;
    @SerializedName("Id")
    @Expose
    private Integer id;
    @SerializedName("Name")
    @Expose
    private String name;
    @SerializedName("Info")
    @Expose
    private String info;
    @SerializedName("Address")
    @Expose
    private String address;
    @SerializedName("GeometryType")
    @Expose
    private Integer geometryType;
    @SerializedName("GeometryEdges")
    @Expose
    private ArrayList<GeometryEdge> geometryEdges = null;
    @SerializedName("CurrentAvailabilityState")
    @Expose
    private Integer currentAvailabilityState;
    @SerializedName("StreetView")
    @Expose
    private String streetView;
    @SerializedName("Capacity")
    @Expose
    private Integer capacity;
    @SerializedName("AtLocation")
    @Expose
    private Boolean atLocation;
    @SerializedName("NearLocation")
    @Expose
    private Boolean nearLocation;
    @SerializedName("LocationDistance")
    @Expose
    private Double locationDistance;
    @SerializedName("Tickets")
    @Expose
    private Tickets tickets;


    public Integer getProviderId() {
        return providerId;
    }

    public void setProviderId(Integer providerId) {
        this.providerId = providerId;
    }

    public String getProviderName() {
        return providerName;
    }

    public void setProviderName(String providerName) {
        this.providerName = providerName;
    }

    public String getProviderLogo() {
        return providerLogo;
    }

    public void setProviderLogo(String providerLogo) {
        this.providerLogo = providerLogo;
    }

    public Integer getZoneId() {
        return zoneId;
    }

    public void setZoneId(Integer zoneId) {
        this.zoneId = zoneId;
    }

    public String getZoneName() {
        return zoneName;
    }

    public void setZoneName(String zoneName) {
        this.zoneName = zoneName;
    }

    public String getZoneInfo() {
        return zoneInfo;
    }

    public void setZoneInfo(String zoneInfo) {
        this.zoneInfo = zoneInfo;
    }

    public Boolean getZoneIsPaying() {
        return zoneIsPaying;
    }

    public void setZoneIsPaying(Boolean zoneIsPaying) {
        this.zoneIsPaying = zoneIsPaying;
    }

    public ArrayList<ParkingTimeTable> getParkingTimeTable() {
        return parkingTimeTable;
    }

    public void setParkingTimeTable(ArrayList<ParkingTimeTable> parkingTimeTable) {
        this.parkingTimeTable = parkingTimeTable;
    }

    public Integer getParkingMaxDuration() {
        return parkingMaxDuration;
    }

    public void setParkingMaxDuration(Integer parkingMaxDuration) {
        this.parkingMaxDuration = parkingMaxDuration;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getInfo() {
        return info;
    }

    public void setInfo(String info) {
        this.info = info;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public Integer getGeometryType() {
        return geometryType;
    }

    public void setGeometryType(Integer geometryType) {
        this.geometryType = geometryType;
    }

    public ArrayList<GeometryEdge> getGeometryEdges() {
        return geometryEdges;
    }

    public void setGeometryEdges(ArrayList<GeometryEdge> geometryEdges) {
        this.geometryEdges = geometryEdges;
    }

    public Integer getCurrentAvailabilityState() {
        return currentAvailabilityState;
    }

    public void setCurrentAvailabilityState(Integer currentAvailabilityState) {
        this.currentAvailabilityState = currentAvailabilityState;
    }

    public String getStreetView() {
        return streetView;
    }

    public void setStreetView(String streetView) {
        this.streetView = streetView;
    }

    public Integer getCapacity() {
        return capacity;
    }

    public void setCapacity(Integer capacity) {
        this.capacity = capacity;
    }

    public Boolean getAtLocation() {
        return atLocation;
    }

    public void setAtLocation(Boolean atLocation) {
        this.atLocation = atLocation;
    }

    public Boolean getNearLocation() {
        return nearLocation;
    }

    public void setNearLocation(Boolean nearLocation) {
        this.nearLocation = nearLocation;
    }

    public Double getLocationDistance() {
        return locationDistance;
    }

    public void setLocationDistance(Double locationDistance) {
        this.locationDistance = locationDistance;
    }

    public Tickets getTickets() {
        return tickets;
    }

    public void setTickets(Tickets tickets) {
        this.tickets = tickets;
    }
}
