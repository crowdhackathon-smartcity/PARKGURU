package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.ArrayList;

/** An array of tickets (see Ticket for details)
 * Price is the total Price user pays for Parking
 * Created by jimpap
 */

public class Tickets {
    @SerializedName("Price")
    @Expose
    private Double price;
    @SerializedName("Tickets")
    @Expose
    private ArrayList<Ticket> tickets = null;


    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }

    public ArrayList<Ticket> getTickets() {
        return tickets;
    }

    public void setTickets(ArrayList<Ticket> tickets) {
        this.tickets = tickets;
    }
}
