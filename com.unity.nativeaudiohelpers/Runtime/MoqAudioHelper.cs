using System;
using JetBrains.Annotations;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class MoqAudioHelper : IAudioHelper
    {
        private readonly float maxVolume = 1f;
        private float volume = 0.75f;

        public void Dispose()
        {
        }

        public bool IsHeadphonesConnected()
        {
            return true;
        }

        public float GetDeviceVolume()
        {
            return volume;
        }

        public void SetDeviceVolume(float delta)
        {
            volume = delta;
        }

        public float GetDeviceMaxVolume()
        {
            return maxVolume;
        }
    }
}