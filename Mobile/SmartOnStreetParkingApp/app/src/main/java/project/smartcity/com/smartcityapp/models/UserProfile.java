package project.smartcity.com.smartcityapp.models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import io.realm.RealmObject;
import io.realm.annotations.PrimaryKey;

/**
 * Created by jimpap
 */

public class UserProfile extends RealmObject {

    @PrimaryKey
    @SerializedName("Id")
    @Expose
    private Integer id;

    @SerializedName("Username")
    @Expose
    private String username;

    @SerializedName("Password")
    @Expose
    private String password;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
