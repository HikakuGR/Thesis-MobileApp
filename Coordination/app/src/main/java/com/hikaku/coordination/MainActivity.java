package com.hikaku.coordination;



import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.location.LocationManager;
import android.os.Bundle;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.widget.TextView;


public class MainActivity extends Activity {

	public Thread LocationSendThread;
	private CharSequence mTitle;
	private EditText txtUsername, txtPassword;
	private Button btnLogin;

	private LocationManager locationManager;
	private String provider;
	private volatile Location lastKnownLocation;
	public static int currentUser = -1;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);



		// Get the location manager
		locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		provider = LocationManager.GPS_PROVIDER;
		LocationListener locationListener = new LocationListener() {
			public void onLocationChanged(Location location) {


				lastKnownLocation = location;

			}

			public void onStatusChanged(String provider, int status,
					Bundle extras) {
			}

			public void onProviderEnabled(String provider) {
			}

			public void onProviderDisabled(String provider) {
			}
		};
		locationManager.requestLocationUpdates(provider, 0, 0, locationListener);
		lastKnownLocation = locationManager.getLastKnownLocation(provider);
		// Initialize the location fields


		mTitle = getTitle();
		txtUsername = (EditText) findViewById(R.id.txtUsername);
		txtPassword = (EditText) findViewById(R.id.txtPassword);
		btnLogin = (Button) findViewById(R.id.btnLogin);
	}

	/* Request updates at startup */
	@Override
	protected void onResume() {
		super.onResume();
		// locationManager.requestLocationUpdates(provider, 400, 1, this);
	}

	/* Remove the locationlistener updates when Activity is paused */
	@Override
	protected void onPause() {
		super.onPause();
		// locationManager.removeUpdates(this);
	}


	public void btnOptions_OnClick(View view) {
		Intent intent = new Intent(this, OptionsActivity.class);
		startActivity(intent);

	}

	public void btnRegister_OnClick(View view) {
		Intent intent = new Intent(this, RegisterActivity.class);
		startActivity(intent);
	}

	public void btnLogin_OnClick(View view) {

		String userName = txtUsername.getText().toString();
		String password = txtPassword.getText().toString();
		String serverAddress = Constants.getServerAddress(getApplicationContext().getSharedPreferences(Constants.PREFERENCES_NAME, MODE_PRIVATE));
		if (serverAddress == null){
			AlertDialog.Builder builder = new AlertDialog.Builder(
					view.getContext());
			builder.setMessage("Server Address is EMPTY");
			AlertDialog dialog = builder.create();
			dialog.show();
			return;
		}
		final WebServiceHandler webservice = new WebServiceHandler(serverAddress);

		try {

			int userID = webservice.Login(userName, password);
			if (userID == -1) {
				//failed Login
				AlertDialog.Builder builder = new AlertDialog.Builder(
						view.getContext());
				builder.setMessage("User NOT found");
				AlertDialog dialog = builder.create();
				dialog.show();
			} else {
				//successful Login
				currentUser=userID;
				LocationSendThread = new Thread(new Runnable() {
					public void run() {
						while (true) {
							try {
								if (lastKnownLocation != null && currentUser != -1) {
									webservice.SendLastKnownLocation(lastKnownLocation, currentUser);
								}

							} catch (Exception e) {
								e.printStackTrace();
							}
							try{
							Thread.sleep(10000);
							} catch (Exception e) {
								e.printStackTrace();
							}
						}
					}
				});
				LocationSendThread.start();

				Intent intent = new Intent(this, MapActivity.class);
				startActivity(intent);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
