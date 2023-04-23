package com.unity.audiohelpers;

import android.content.Context;
import android.media.AudioDeviceInfo;
import android.media.AudioManager;

public class AudioHelpers
{
    static AudioManager audioManager;

    public AudioHelpers(Context context)
    {
        audioManager = (AudioManager) context.getSystemService(Context.AUDIO_SERVICE);
    }

    public boolean _IsHeadphonesOn()
    {
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.M)
        {
            AudioDeviceInfo[] audioDeviceInfos = audioManager.getDevices(AudioManager.GET_DEVICES_INPUTS);
            for (AudioDeviceInfo audioDeviceInfo : audioDeviceInfos) {
                if (audioDeviceInfo.getType() == AudioDeviceInfo.TYPE_BLUETOOTH_SCO ||
                        audioDeviceInfo.getType() == AudioDeviceInfo.TYPE_WIRED_HEADSET ||
                        audioDeviceInfo.getType() == AudioDeviceInfo.TYPE_WIRED_HEADPHONES)
                    return true;
            }
        }
        else
        {
            return audioManager.isWiredHeadsetOn() || audioManager.isBluetoothA2dpOn();
        }

        return false;
    }

    public float _GetSystemVolume()
    {
        int deviceVolume = audioManager.getStreamVolume(AudioManager.STREAM_MUSIC);

        return (float) (deviceVolume / (float) _GetDeviceMaxVolume());
    }

    public void _SetSystemVolume(float volumeValue)
    {
        int volumeScaled = (int) (volumeValue * (float) _GetDeviceMaxVolume());
        audioManager.setStreamVolume(AudioManager.STREAM_MUSIC, volumeScaled, 1);
    }

    public int _GetDeviceMaxVolume()
    {
        return audioManager.getStreamMaxVolume(AudioManager.STREAM_MUSIC);
    }
}

