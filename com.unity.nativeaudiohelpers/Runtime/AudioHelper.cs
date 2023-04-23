using System;
using JetBrains.Annotations;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class AudioHelper : IAudioHelper, IDisposable
    {
        private readonly IAudioHelper nativeAudioHelper;

        public AudioHelper()
        {
            nativeAudioHelper = CreateAudioHelperImplementation();
        }

        public void Dispose()
        {
            nativeAudioHelper.Dispose();
        }

        public bool IsHeadphonesConnected()
        {
            return nativeAudioHelper.IsHeadphonesConnected();
        }

        public float GetDeviceVolume()
        {
            return nativeAudioHelper.GetDeviceVolume();
        }

        public void SetDeviceVolume(float delta)
        {
            nativeAudioHelper.SetDeviceVolume(delta);
        }

        private IAudioHelper CreateAudioHelperImplementation()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return new AndroidAudioHelper();
#elif UNITY_IOS && !UNITY_EDITOR
            return new IOSAudioHelper();
#endif
            return new MoqAudioHelper();
        }
    }
}