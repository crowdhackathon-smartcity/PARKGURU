package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;

/** A realm object to keep the plates
 * Created by jimpap
 */

public class Plates extends RealmObject {

    @PrimaryKey
    @SerializedName("Id")
    @Expose
    private Integer id;

    @SerializedName("Plates")
    @Expose
    private String plates;


    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getPlates() {
        return plates;
    }

    public void setPlates(String plates) {
        this.plates = plates;
    }
}