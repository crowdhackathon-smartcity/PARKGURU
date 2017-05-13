package project.smartcity.com.smartcityapp.models;

/**
 * UserTicket is just a helper model so we can pass
 * data that user selects during the booking process.
 * It is not persisted or used anywhere but during the booking process and
 * until user pays for the parking.
 * Created by jimpap
 */

public class UserTicket {

    private int parkTime; // minutes
    private String parkTimeText; //park time string
    private double amountToPay;
    private String address;
    private String vehiclePlates;


    public int getParkTime() {
        return parkTime;
    }

    public void setParkTime(int parkTime) {
        this.parkTime = parkTime;
    }

    public String getParkTimeText() {
        return parkTimeText;
    }

    public void setParkTimeText(String parkTimeText) {
        this.parkTimeText = parkTimeText;
    }

    public double getAmountToPay() {
        return amountToPay;
    }

    public void setAmountToPay(double amountToPay) {
        this.amountToPay = amountToPay;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getVehiclePlates() {
        return vehiclePlates;
    }

    public void setVehiclePlates(String vehiclePlates) {
        this.vehiclePlates = vehiclePlates;
    }
}
