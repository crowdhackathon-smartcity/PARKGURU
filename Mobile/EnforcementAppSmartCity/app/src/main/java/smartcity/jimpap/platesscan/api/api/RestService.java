package smartcity.jimpap.platesscan.api.api;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Just creating the rest interface so we can have access to api methods
 * I ll use retrofit for the calls
 * Created by dimitris
 */

public class RestService {

    private static final String API_URL = "https://smartonstreetparkingapi.azurewebsites.net/api/";
    public static final String API_KEY = "b82e61fa-8f2c-4fcd-900b-115aed5fe393";
    private static RestInterface restInterface;


    public static RestInterface getRestApiInterface() {
        if (restInterface == null) {
            createRestApiInterface();
        }
        return restInterface;
    }

    private static void createRestApiInterface() {
        Retrofit adapter = new Retrofit.Builder()
                .addConverterFactory(GsonConverterFactory.create())
                .baseUrl(API_URL).build();
        restInterface = adapter.create(RestInterface.class);
    }

}

