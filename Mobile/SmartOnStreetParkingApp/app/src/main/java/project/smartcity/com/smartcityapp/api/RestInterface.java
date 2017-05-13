package project.smartcity.com.smartcityapp.api;

import java.util.ArrayList;

import project.smartcity.com.smartcityapp.models.ParkingSpot;
import project.smartcity.com.smartcityapp.models.SearchRequest;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

/**
 * Created by dimitris
 */

public interface RestInterface {

    @POST("Default/SearchSpots")
    Call<ArrayList<ParkingSpot>> searchParkingSpots(@Body SearchRequest edge);
//
//    @GET("Zone/GetById/{ZoneId}")
//    Call<Zone> getZone(@Header("Authorization") String token, @Path("ZoneId") int zoneId);
//
//    @PUT("Members/Edit")
//    Call<Void> editUserProfile(@Header("Authorization") String token, @Body UserProfile in);
}
