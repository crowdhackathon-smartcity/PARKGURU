package project.smartcity.com.smartcityapp.api;

import java.util.ArrayList;

import project.smartcity.com.smartcityapp.models.CalculateTicketsRequest;
import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.PaymentRequest;
import project.smartcity.com.smartcityapp.models.PaymentResponse;
import project.smartcity.com.smartcityapp.models.SearchRequest;
import project.smartcity.com.smartcityapp.models.Tickets;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Query;

/**
 * Created by dimitris
 */

public interface RestInterface {

    @POST("Default/SearchSpots")
    Call<ArrayList<ParkingSpot>> searchParkingSpots(@Body SearchRequest edge);


    @POST("Default/CalcSpotTickets")
    Call<Tickets> calculateTickets(@Body CalculateTicketsRequest ticketsRequest);

    @POST("Default/Pay")
    Call<PaymentResponse> createPayment(@Body PaymentRequest paymentRequest);

    @GET("Default/GetPayments")
    Call<ArrayList<PaymentResponse>> getPayments(@Query("VehiclePlate") String vehiclePlate, @Query("APIKey") String apiKey);



//    @GET("Zone/GetById/{ZoneId}")
//    Call<Zone> getZone(@Header("Authorization") String token, @Path("ZoneId") int zoneId);
//
//    @PUT("Members/Edit")
//    Call<Void> editUserProfile(@Header("Authorization") String token, @Body UserProfile in);
}
