package com.hikaku.coordination;

import android.content.SharedPreferences;

public class Constants {

    public static String SERVER_ADDRESS = "ServerAddress";
    public static String PREFERENCES_NAME = "SavedPreferences";
    public static String getServerAddress(SharedPreferences preferences){
        String serverAddress = preferences.getString(Constants.SERVER_ADDRESS,null);
        if (serverAddress==null)
        {
            return null;
        }
        else
        {
            return serverAddress + "/AndroidService.asmx";
        }
    }}
