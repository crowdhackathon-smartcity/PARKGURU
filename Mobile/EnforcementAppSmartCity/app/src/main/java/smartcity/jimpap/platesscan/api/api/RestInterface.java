package smartcity.jimpap.platesscan.api.api;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;
import smartcity.jimpap.platesscan.models.PaymentResponse;

/**
 * Created by dimitris
 */

public interface RestInterface {


    @GET("Default/CheckPlate")
    Call<PaymentResponse> checkPlate(@Query("VehiclePlate") String vehiclePlate, @Query("APIKey") String apiKey);


}
