#import <AVFoundation/AVFoundation.h>
#import <MediaPlayer/MediaPlayer.h>

extern "C" {
	bool _IsHeadphonesOn() {
        AVAudioSessionRouteDescription* route = [[AVAudioSession sharedInstance] currentRoute];
        
        for (AVAudioSessionPortDescription* desc in [route outputs]) {
            if ([[desc portType] isEqualToString:AVAudioSessionPortHeadphones])
                return true;
            if ([[desc portType] isEqualToString:AVAudioSessionPortBluetoothHFP])
                return true;
            if ([[desc portType] isEqualToString:AVAudioSessionPortBluetoothA2DP])
                return true;
        }
        
        return false;
	}
	
	float _GetSystemVolume() {
	    float volume = [[AVAudioSession sharedInstance] outputVolume];
	    return volume;
	}
	
	void _SetSystemVolume(float volume)
	{
        MPMusicPlayerController* musicPlayer = [MPMusicPlayerController applicationMusicPlayer];
        musicPlayer.volume = volume;
    }
    
    float _GetDeviceMaxVolume()
    {
        return 1;
    }
}
