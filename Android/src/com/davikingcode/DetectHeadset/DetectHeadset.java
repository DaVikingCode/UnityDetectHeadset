package com.davikingcode.DetectHeadset;

import android.content.Context;
import android.media.AudioManager;

public class DetectHeadset {
	
	static AudioManager myAudioManager;
	
	public DetectHeadset(Context context) {
		myAudioManager = (AudioManager) context.getSystemService(Context.AUDIO_SERVICE);
	}
	
	public boolean _Detect() {
		//Added validation for newer api's above 26.
		if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.M) {
		    AudioDeviceInfo[] audioDeviceInfos = myAudioManager.getDevices(AudioManager.GET_DEVICES_INPUTS);
		    for (int i=0;i<audioDeviceInfos.length; i++){
			if(audioDeviceInfos[i].getType() == AudioDeviceInfo.TYPE_BLUETOOTH_SCO ||
				audioDeviceInfos[i].getType() == AudioDeviceInfo.TYPE_WIRED_HEADSET)
			    return true;
		    }
		}else {
		    //This should work as expected for the older api's
		    if(myAudioManager.isWiredHeadsetOn() || myAudioManager.isBluetoothA2dpOn())
			return true;
		}
		return false;
    	}
}
