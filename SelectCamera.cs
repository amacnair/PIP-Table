/*

Script: 	SelectCamera

Author: 	Alex MacNair

Function:	Used to switch the viewpoint between cameras by enabling / disabling
			each camera. Camera 1 the default 
			starting camera.

Usage: 		This script should be applied to a single object in the scene. The 
			Main Camera is suggested. Each of the four audience perspective 
			cameras must be specified in the inspector pane.
			The function keys f1-f4 are used to select the active camera.

*/


using UnityEngine;
using System.Collections;

public class SelectCamera : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;
	public Camera camera3;
	public Camera camera4;


	// Use this for initialization
	void Start () {
		camera1.enabled = true;
		camera2.enabled = false;
		camera3.enabled = false;
		camera4.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("f1"))
		{
			Debug.Log("Camera 1 Active");
			camera1.enabled = true;
			camera2.enabled = false;
			camera3.enabled = false;
			camera4.enabled = false;

		}
		if (Input.GetKey("f2"))
		{
			Debug.Log("Camera 2 Active");
			camera2.enabled = true;
			camera1.enabled = false;
			camera3.enabled = false;
			camera4.enabled = false;

		}
		if (Input.GetKey("f3"))
		{
			Debug.Log("Camera 3 Active");
			camera3.enabled = true;
			camera1.enabled = false;
			camera2.enabled = false;
			camera4.enabled = false;

		}
		if (Input.GetKey("f4"))
		{
			Debug.Log("Camera 4 Active");
			camera4.enabled = true;
			camera1.enabled = false;
			camera2.enabled = false;
			camera3.enabled = false;
		}
	}
}
