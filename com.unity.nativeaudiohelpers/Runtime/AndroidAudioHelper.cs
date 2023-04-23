#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class AndroidAudioHelper : IAudioHelper
    {
        private const string UnityPlayerClassName = "com.unity3d.player.UnityPlayer";
        private const string CurrentActivityName = "currentActivity";
        private const string PluginNamespace = "com.unity.audiohelpers.AudioHelpers";

        private const string IsHeadphonesOnMethodName = "_IsHeadphonesOn";
        private const string GetSystemVolumeMethodName = "_GetSystemVolume";
        private const string SetSystemVolumeMethodName = "_SetSystemVolume";
        private const string GetDeviceMaxVolumeMethodName = "_GetDeviceMaxVolume";

        private AndroidJavaObject androidPlugin;

        public AndroidAudioHelper() => InitializePlugin();

        public void Dispose() => androidPlugin.Dispose();

        public bool IsHeadphonesConnected() => androidPlugin.Call<bool>(IsHeadphonesOnMethodName);

        public float GetDeviceVolume() => androidPlugin.Call<float>(GetSystemVolumeMethodName);

        public void SetDeviceVolume(float volume) => androidPlugin.Call(SetSystemVolumeMethodName, volume);

        public float GetDeviceMaxVolume() =>androidPlugin.Call<float>(GetDeviceMaxVolumeMethodName);

        private void InitializePlugin()
        {
            using var javaUnityPlayer = new AndroidJavaClass(UnityPlayerClassName);
            using var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>(CurrentActivityName);
            androidPlugin = new AndroidJavaObject(PluginNamespace, currentActivity);
        }
    }
}
#endif