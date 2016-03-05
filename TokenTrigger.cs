/*

Script: 	TokenTrigger

Author: 	Alex MacNair

Function:	Detects nearby table objects (Tektons) and triggers a call to an 
			effect script on that object.

Usage: 		This script should be applied to the effect object(s) (tokens). 

*/


using UnityEngine;
using System.Collections;

public class TokenTrigger : MonoBehaviour {

	public float maxDist = 3.0f;
	public float minDist = 1.6f; 
	public string searchTag = "Tekton";
	public float objDist;

	public GameObject[] tektons;
	private GameObject[] inRange;

	public Transform other;



	// Use this for initialization
	void Start () {
		
		tektons = GameObject.FindGameObjectsWithTag("Tekton"); //Populate array with all token objects
			
	}
	
	// Update is called once per frame
	void Update () {

		ScanObjects();

	}

	public void ScanObjects() {

		if (tektons[0] == null) { //Make sure there is at least one object in the array
			Debug.Log("No objects are tagged as tektons!");
			return;
		}

		MeshRenderer mesh = GetComponent<MeshRenderer>();

		foreach (GameObject tekton in tektons) {
			//Debug.Log(tekton);
		
			other = tekton.transform;

			if (tekton.transform) {
				objDist = Vector3.Distance(other.position, transform.position);
				//print("Distance to other: " + objDist);
			if ( (objDist <= maxDist && objDist >= minDist) && mesh.enabled) { //If object is within the min-max range
				other.GetComponent<ScaleEffect>().Scale(1.5f);
			}
			else {
				other.GetComponent<ScaleEffect>().ResetScale(1);
			}
		}
		}
	}
}
