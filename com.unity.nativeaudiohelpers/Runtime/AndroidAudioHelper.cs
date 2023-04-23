#if UNITY_ANDROID
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class AndroidAudioHelper : IAudioHelper
    {
        private AndroidJavaObject androidPlugin;

        public AndroidAudioHelper()
        {
            InitializePlugin();
        }

        public bool IsHeadphonesConnected()
        {
            return androidPlugin.Call<bool>("_Detect");
        }

        public float GetDeviceVolume()
        {
            throw new NotImplementedException();
        }

        public void SetDeviceVolume(float delta)
        {
            throw new NotImplementedException();
        }

        private void InitializePlugin()
        {
            using var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            using var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            androidPlugin = new AndroidJavaObject("com.davikingcode.DetectHeadset.DetectHeadset", currentActivity);
        }
    }
}
#endif