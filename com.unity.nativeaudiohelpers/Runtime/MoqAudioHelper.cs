using System;
using JetBrains.Annotations;

namespace NativeAudioHelper
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class MoqAudioHelper : IAudioHelper
    {
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