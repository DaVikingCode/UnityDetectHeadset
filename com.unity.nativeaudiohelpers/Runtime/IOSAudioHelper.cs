#if UNITY_IOS
using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class IOSAudioHelper : IAudioHelper
    {
        [DllImport ("__Internal")]
        private static extern bool _Detect();

        public void Dispose()
        {
        }

        public bool IsHeadphonesConnected()
        {
            return _Detect();
        }

        public float GetDeviceVolume()
        {
            throw new NotImplementedException();
        }

        public void SetDeviceVolume(float delta)
        {
            throw new NotImplementedException();
        }
    }
}
#endif