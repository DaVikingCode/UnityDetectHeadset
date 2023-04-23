#if UNITY_ANDROID
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class AndroidAudioHelper : IAudioHelper
    {
        private const string UnityPlayerClassName = "com.unity3d.player.UnityPlayer";
        private const string CurrentActivityName = "currentActivity";
        private const string PluginNamespace = "com.davikingcode.DetectHeadset.DetectHeadset";

        private const string DetectMethodName = "_Detect";

        private AndroidJavaObject androidPlugin;

        public AndroidAudioHelper() => InitializePlugin();

        public void Dispose() => androidPlugin.Dispose();

        public bool IsHeadphonesConnected() => androidPlugin.Call<bool>(DetectMethodName);

        public float GetDeviceVolume() => throw new NotImplementedException();

        public void SetDeviceVolume(float delta) => throw new NotImplementedException();

        private void InitializePlugin()
        {
            using var javaUnityPlayer = new AndroidJavaClass(UnityPlayerClassName);
            using var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>(CurrentActivityName);
            androidPlugin = new AndroidJavaObject(PluginNamespace, currentActivity);
        }
    }
}
#endif