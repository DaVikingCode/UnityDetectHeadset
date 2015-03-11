package com.davikingcode.DetectHeadset;

import android.content.Context;
import android.media.AudioManager;
import android.os.Bundle;

import com.unity3d.player.UnityPlayerActivity;

public class DetectHeadset extends UnityPlayerActivity {
	
	static AudioManager myAudioManager;
	
	@Override
	protected void onCreate(Bundle arg0) {
		super.onCreate(arg0);
		
		myAudioManager = (AudioManager)getSystemService(Context.AUDIO_SERVICE);
	}
	
	static public boolean _Detect() {
		
		return myAudioManager.isWiredHeadsetOn();
	}
}
