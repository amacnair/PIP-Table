using UnityEngine;
using System.Collections;

public class CameraTextToggle : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Camera>().enabled) {
			GetComponent<GUIText>().enabled = true;
		}
		else {
			GetComponent<GUIText>().enabled = false;
		}
	}
}
