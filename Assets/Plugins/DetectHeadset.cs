using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class DetectHeadset {

	[DllImport ("__Internal")]
	static private extern bool _Detect();

	#if UNITY_ANDROID
		static AndroidJavaClass androidClass;
	#endif

	static public bool Detect() {

		#if UNITY_IOS
			return _Detect();

		#elif UNITY_ANDROID && !UNITY_EDITOR
			
			if (androidClass == null) {
				AndroidJNI.AttachCurrentThread();
				androidClass = new AndroidJavaClass("com.davikingcode.DetectHeadset.DetectHeadset");
			}

			return androidClass.CallStatic<bool>("_Detect");

		#else
			return false;
		#endif
	}
}
