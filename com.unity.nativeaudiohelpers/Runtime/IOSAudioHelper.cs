#if UNITY_IOS
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class IOSAudioHelper : IAudioHelper
    {
        [DllImport("__Internal")]
        private static extern bool _IsHeadphonesOn();

        [DllImport("__Internal")]
        private static extern float _GetSystemVolume();

        [DllImport("__Internal")]
        private static extern void _SetSystemVolume(float volume);

        [DllImport("__Internal")]
        private static extern float _GetDeviceMaxVolume();

        public void Dispose()
        {
        }

        public bool IsHeadphonesConnected() => _IsHeadphonesOn();

        public float GetDeviceVolume() => _GetSystemVolume();

        public void SetDeviceVolume(float volume) => _SetSystemVolume(volume);

        public float GetDeviceMaxVolume() => _GetDeviceMaxVolume();
    }
}

#endif