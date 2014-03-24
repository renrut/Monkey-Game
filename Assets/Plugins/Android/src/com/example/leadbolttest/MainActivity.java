package com.example.leadbolttest;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.MenuItem;
import android.support.v4.app.NavUtils;

import com.Leadbolt.AdController;

import com.unity3d.player.*;

public class MainActivity extends UnityPlayerActivity {
	private AdController myController;
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
     // super (UnityPlayerActivity) will use setContentView() ..
        //setContentView(R.layout.activity_main);
        
        myController = new AdController(this, "918928393");
        myController.setAsynchTask(true);
        myController.loadAd();
    }

    public void onDestroy() {
	    myController.destroyAd();
	    super.onDestroy();
    }
    
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_main, menu);
        return true;
    }

    
}
