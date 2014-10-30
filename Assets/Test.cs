using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	bool headsetConnected = false;

	void Start () {
	
	}
	
	void OnGUI() {

		GUI.Label(new Rect(10, Screen.height - 40, 500, 50), "headset connected:" + headsetConnected.ToString());

		if (GUI.Button(new Rect(Screen.width - 150, 150, 150, 50), "Detect"))
			headsetConnected = DetectHeadset.Detect();

	}
}
