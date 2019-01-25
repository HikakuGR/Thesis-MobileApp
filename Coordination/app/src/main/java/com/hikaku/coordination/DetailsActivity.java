package com.hikaku.coordination;

import android.app.Activity;
import android.app.AlertDialog;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class DetailsActivity extends Activity {
    private TextView jobNameField;
    private TextView jobIDField;
    private TextView jobDescriptionField;
    private Job job;
    private WebServiceHandler webservice;
    private Button requestAssignBtn;
    private Button jobCancelBtn;
    private Button completeBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState); //When we override a method, we have the option of completely replacing the method in our class, or of extending the existing parent class' method. By calling super.onCreate(savedInstanceState);, you tell the Dalvik VM to run your code in addition to the existing code in the onCreate() of the parent class. If you leave out this line, then only your code is run. The existing code is ignored completely.
        setContentView(R.layout.activity_details);
        String serverAddress = Constants.getServerAddress(getApplicationContext().getSharedPreferences(Constants.PREFERENCES_NAME, MODE_PRIVATE));
        webservice = new WebServiceHandler(serverAddress);
        Bundle extras = getIntent().getExtras(); // We take the "job" that was passed through the extras when onclick on marker happened in MapActivity

        if (extras != null && extras.get("job") != null) {

            Integer jobID = (Integer) extras.get("job");
            try {
                job = webservice.GetJobByID(jobID);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }


        if (job!=null){
            jobNameField = (TextView) findViewById(R.id.jobNameField);//show jod data on user
            jobNameField.setText(job.jobName);
            jobDescriptionField = (TextView)findViewById(R.id.jobDescriptionField);
            jobDescriptionField.setText(job.description);
            jobIDField = (TextView) findViewById(R.id.jobIDField);
            jobIDField.setText(job.ID.toString());
            requestAssignBtn = (Button) findViewById(R.id.btnRequestAssign);
            jobCancelBtn = (Button) findViewById(R.id.jobCancel);
            completeBtn = (Button) findViewById(R.id.jobComplete);

            try {
                int jobAssignmentStatus = webservice.JobAssignmentStatus(job.ID,MainActivity.currentUser);// check if job is assigned to user or anyone else
                if(jobAssignmentStatus==0){
                   requestAssignBtn.setEnabled(false);
                   requestAssignBtn.setText("Request Pending");
                }else if (jobAssignmentStatus==1){
                    requestAssignBtn.setVisibility(View.GONE);
                    completeBtn.setVisibility(View.VISIBLE);
                    jobCancelBtn.setVisibility(View.VISIBLE);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }

        }
    }



    public void btnJobComplete_OnClick(View view) throws Exception {

        int result = webservice.JobComplete(job.ID);
        if (result == 1) {
            AlertDialog.Builder builder = new AlertDialog.Builder(
                    view.getContext());
            builder.setMessage("Error");
            AlertDialog dialog = builder.create();
            dialog.show();
        }else{
            AlertDialog.Builder builder = new AlertDialog.Builder(
                    view.getContext());
            builder.setMessage("Job Successfully Completed");
            AlertDialog dialog = builder.create();
            dialog.show();
            finish();
        }
    }
    public void btnJobCancel_OnClick(View view) throws Exception {

        int result = webservice.JobCancel(job.ID, MainActivity.currentUser);
        if (result == 1) {
            AlertDialog.Builder builder = new AlertDialog.Builder(
                    view.getContext());
            builder.setMessage("Error");
            AlertDialog dialog = builder.create();
            dialog.show();
        }else{
            AlertDialog.Builder builder = new AlertDialog.Builder(
                    view.getContext());
            builder.setMessage("Job Successfully Canceled");
            AlertDialog dialog = builder.create();
            dialog.show();
            finish();
        }
    }
    public void btnRequestAssign_OnClick(View view) throws Exception{
        // currentUser

        int result =  webservice.JobAssign(job.ID,MainActivity.currentUser);
        if (result == -1) {
            AlertDialog.Builder builder = new AlertDialog.Builder(
                    view.getContext());
            builder.setMessage("Job Assign FAILED");
            AlertDialog dialog = builder.create();
            dialog.show();
        }
        else{
                AlertDialog.Builder builder = new AlertDialog.Builder(
                        view.getContext());
                builder.setMessage("Job Assign SUCCESS");
                AlertDialog dialog = builder.create();
                dialog.show();
            requestAssignBtn.setEnabled(false);
            requestAssignBtn.setText("Request Pending");
            }
        finish();
        }
    }


