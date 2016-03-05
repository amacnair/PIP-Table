using UnityEngine;
using System.Collections;

public class QuitMonitor : MonoBehaviour {

	public enum QuitKey { escape, f1, f2, f3, f4, backspace, delete };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape")) {
            Application.Quit();
        }
	}
}
