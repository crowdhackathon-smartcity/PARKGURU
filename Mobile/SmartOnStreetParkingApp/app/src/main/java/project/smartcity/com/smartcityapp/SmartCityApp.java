package project.smartcity.com.smartcityapp;

import android.app.Application;

import io.realm.Realm;
import io.realm.RealmConfiguration;
import io.realm.exceptions.RealmMigrationNeededException;

/**
 * Created by jimpap
 */

public class SmartCityApp extends Application {


    @Override
    public void onCreate() {
        super.onCreate();
        //init realm , we ll use realm to persist the bookings
        RealmConfiguration realmConfiguration = null;
        try {
            Realm.init(this);
            realmConfiguration = new RealmConfiguration.Builder().deleteRealmIfMigrationNeeded().build();
            Realm.setDefaultConfiguration(realmConfiguration);
        } catch (RealmMigrationNeededException e) {
            try {
                Realm.deleteRealm(realmConfiguration);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
