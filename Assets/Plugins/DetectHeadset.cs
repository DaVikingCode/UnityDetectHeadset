using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class DetectHeadset {

	[DllImport ("__Internal")]
	static private extern bool _Detect();

	static public bool Detect() {

		if (Application.platform == RuntimePlatform.IPhonePlayer)
			return _Detect();

		else
			return true;
	}
}
