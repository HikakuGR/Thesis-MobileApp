package com.hikaku.coordination;

import java.io.Serializable;
import java.util.ArrayList;


public class Job implements Serializable{
    public Integer ID;
    public Double latitude, longitude;
    public String description, jobName;
    public Boolean completed;
    public ArrayList<JobAssignment> jobAssignments;

    public boolean isRequestPendingByUser(int userID){
        for (JobAssignment jobAssignment: jobAssignments){
            if (jobAssignment.userID==userID && jobAssignment.approved==false){
                return true;
            }
        }
        return false;

    }
    public boolean isAssignedToUser(int userID){
        for (JobAssignment jobAssignment: jobAssignments){
            if (jobAssignment.userID==userID && jobAssignment.approved){
                return true;
            }
        }
        return false;

    }


}
