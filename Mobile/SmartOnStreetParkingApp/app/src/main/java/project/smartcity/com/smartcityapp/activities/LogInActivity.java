package project.smartcity.com.smartcityapp.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import io.realm.Realm;
import project.smartcity.com.smartcityapp.R;
import project.smartcity.com.smartcityapp.models.UserProfile;

public class LogInActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login_act);
        //keep it simple and fast
        //get the values from the fields and request the user

        final EditText username = (EditText) findViewById(R.id.username);
        final EditText password = (EditText) findViewById(R.id.password);

        Button login = (Button) findViewById(R.id.login_btn);
        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String usernameText = username.getText().toString();
                String passwordText = password.getText().toString();
                if (TextUtils.isEmpty(usernameText) || TextUtils.isEmpty(passwordText)) {
                    Toast.makeText(LogInActivity.this, "Please fill username and password", Toast.LENGTH_SHORT).show();
                } else {
                    //you can call your backend to authenticate the user here i am just gonna persist him and move on
                    //this is a simple app to demonstrate other things and not a complete login/register
                    Realm realm = Realm.getDefaultInstance();
                    //just getting the maximum id stored and increase it
                    Number currentId = realm.where(UserProfile.class).max("id");
                    int nextId;
                    if(currentId == null) {
                        nextId = 1;
                    } else {
                        nextId = currentId.intValue() + 1;
                    }
                    //saving to realm
                    UserProfile userProfile = new UserProfile();
                    userProfile.setId(nextId);
                    userProfile.setUsername(usernameText);
                    userProfile.setPassword(passwordText);
                    realm.beginTransaction();
                    realm.copyToRealmOrUpdate(userProfile);
                    realm.commitTransaction();
                    realm.close();

                    Intent i = new Intent(LogInActivity.this, NavigationActivity.class);
                    startActivity(i);
                    finish();
                }
            }
        });
    }


}
