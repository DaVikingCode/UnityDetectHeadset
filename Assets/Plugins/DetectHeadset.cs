using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class DetectHeadset {

	[DllImport ("__Internal")]
	static private extern bool _Detect();

	static public bool Detect() {

		#if UNITY_IOS
			return _Detect();

		#elif UNITY_ANDROID && !UNITY_EDITOR

			using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

				using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

					using (var androidPlugin = new AndroidJavaObject("com.davikingcode.DetectHeadset.DetectHeadset", currentActivity)) {

						return androidPlugin.Call<bool>("_Detect");
					}
				}
			}

		#else
			return true;
		#endif
	}
}
