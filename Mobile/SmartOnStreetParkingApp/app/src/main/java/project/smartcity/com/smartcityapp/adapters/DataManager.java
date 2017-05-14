package project.smartcity.com.smartcityapp.adapters;

import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.UserTicket;

/** an interface for quick access of data between the fragments
 *
 * Created by jimpap
 */

public  interface DataManager {

    void saveParkingSpot(ParkingSpot data);
    void saveUserTicket(UserTicket userTicket);

    ParkingSpot getParkingSpot();
    UserTicket getUserTicket();

}