package project.smartcity.com.smartcityapp.activities;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;

import io.realm.Realm;
import project.smartcity.com.smartcityapp.models.UserProfile;

/**
 * An example full-screen activity that shows and hides the system UI (i.e.
 * status bar and navigation/system bar) with user interaction.
 */
public class SplashScreenActivity extends AppCompatActivity {

    private static int SPLASH_TIME_OUT = 1000;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //just a splash screen


        new Handler().postDelayed(new Runnable() {

            @Override
            public void run() {
                //just look if there is a user available otherwise prompt a login
                Realm realm = Realm.getDefaultInstance();
                UserProfile userProfile = realm.where(UserProfile.class).findFirst();
                if (userProfile != null && userProfile.isValid()) {
                    Intent i = new Intent(SplashScreenActivity.this, NavigationActivity.class);
                    startActivity(i);
                } else {
                    Intent i = new Intent(SplashScreenActivity.this, LogInActivity.class);
                    startActivity(i);
                }

                realm.close();
                finish();


            }
        }, SPLASH_TIME_OUT);
    }


}

