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

	public GameObject camText1;
	public GameObject camText2;
	public GameObject camText3;
	public GameObject camText4;

	public Camera camera1;
	public Camera camera2;
	public Camera camera3;
	public Camera camera4;

	private int deltaFrames = 0;

	private bool helpTextEnabled = false;


	// Use this for initialization
	void Start () {

		camera1.enabled = true;
		camera2.enabled = false;
		camera3.enabled = false;
		camera4.enabled = false;

		camText1.SetActive(false);
		camText2.SetActive(false);
		camText3.SetActive(false);
		camText4.SetActive(false);
		helpTextEnabled = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		++deltaFrames;
		if (Input.GetKey("c") && (deltaFrames > 8)) {
			Debug.Log("Enabing help text");
			if (helpTextEnabled == false) {

				camText1.SetActive(true);
				camText2.SetActive(true);
				camText3.SetActive(true);
				camText4.SetActive(true);
				helpTextEnabled = true;
				deltaFrames = 0;
			}
			else {
				camText1.SetActive(false);
				camText2.SetActive(false);
				camText3.SetActive(false);
				camText4.SetActive(false);
				helpTextEnabled = false;
				deltaFrames = 0;
			}


		}


		if (Input.GetKey("1"))
		{
			Debug.Log("Camera 1 Active");
			camera1.enabled = true;
			camera2.enabled = false;
			camera3.enabled = false;
			camera4.enabled = false;

		}
		if (Input.GetKey("2"))
		{
			Debug.Log("Camera 2 Active");
			camera2.enabled = true;
			camera1.enabled = false;
			camera3.enabled = false;
			camera4.enabled = false;

		}
		if (Input.GetKey("3"))
		{
			Debug.Log("Camera 3 Active");
			camera3.enabled = true;
			camera1.enabled = false;
			camera2.enabled = false;
			camera4.enabled = false;

		}
		if (Input.GetKey("4"))
		{
			Debug.Log("Camera 4 Active");
			camera4.enabled = true;
			camera1.enabled = false;
			camera2.enabled = false;
			camera3.enabled = false;
		}
	}
}
