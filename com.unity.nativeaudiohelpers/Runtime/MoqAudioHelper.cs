using System;
using JetBrains.Annotations;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal class MoqAudioHelper : IAudioHelper
    {
        public void Dispose()
        {
        }

        public bool IsHeadphonesConnected()
        {
            return true;
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