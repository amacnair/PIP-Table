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

		//camera1.GetComponent<GUIText>().enabled = true;
		//camera2.GetComponent<GUIText>().enabled = false;
		//camera3.GetComponent<GUIText>().enabled = false;
		//camera4.GetComponent<GUIText>().enabled = false;

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

			//camera1.GetComponent<GUIText>().enabled = true;
			//camera2.GetComponent<GUIText>().enabled = false;
			//camera3.GetComponent<GUIText>().enabled = false;
			//camera4.GetComponent<GUIText>().enabled = false;

		}
		if (Input.GetKey("f2"))
		{
			Debug.Log("Camera 2 Active");
			camera2.enabled = true;
			camera1.enabled = false;
			camera3.enabled = false;
			camera4.enabled = false;

			//camera2.GetComponent<GUIText>().enabled = true;
			//camera1.GetComponent<GUIText>().enabled = false;
			//camera3.GetComponent<GUIText>().enabled = false;
			//camera4.GetComponent<GUIText>().enabled = false;
		}
		if (Input.GetKey("f3"))
		{
			Debug.Log("Camera 3 Active");
			camera3.enabled = true;
			camera1.enabled = false;
			camera2.enabled = false;
			camera4.enabled = false;

			//camera3.GetComponent<GUIText>().enabled = true;
			//camera1.GetComponent<GUIText>().enabled = false;
			//camera2.GetComponent<GUIText>().enabled = false;
			//camera4.GetComponent<GUIText>().enabled = false;
		}
		if (Input.GetKey("f4"))
		{
			Debug.Log("Camera 4 Active");
			camera4.enabled = true;
			camera1.enabled = false;
			camera2.enabled = false;
			camera3.enabled = false;

			//camera4.GetComponent<GUIText>().enabled = true;
			//camera1.GetComponent<GUIText>().enabled = false;
			//camera2.GetComponent<GUIText>().enabled = false;
			//camera3.GetComponent<GUIText>().enabled = false;
			
			
		}
	}
}
