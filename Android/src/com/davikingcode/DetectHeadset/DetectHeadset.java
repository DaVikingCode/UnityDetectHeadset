package com.davikingcode.DetectHeadset;

import android.content.Context;
import android.media.AudioManager;

public class DetectHeadset {
	
	static AudioManager myAudioManager;
	
	public DetectHeadset(Context context) {
		
		myAudioManager = (AudioManager) context.getSystemService(Context.AUDIO_SERVICE);
	}
	
	public boolean _Detect() {
		if(myAudioManager.isWiredHeadsetOn() || myAudioManager.isBluetoothA2dpOn()){
			return true;
		}else return false;
	}
}
