namespace NativeAudioHelper
{
    public interface IAudioHelper
    {
        public bool IsHeadphonesConnected();
        public float GetDeviceVolume();
        public void SetDeviceVolume(float delta);
    }
}