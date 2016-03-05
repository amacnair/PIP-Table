/*

Script: 	ProximityTrigger

Author: 	Alex MacNair

Function:	Detects an object's proximity to another predefined object.
			This script is only capable of checking the distance between 
			two specific objects. 

Usage: 		This script should be applied to one object, and a second object
			should be set in the object's Inspector pane for this script.
			Script will trigger when within the range: minDist <= dist <= maxDist

*/


using UnityEngine;
using System.Collections;

public class ProximyTrigger : MonoBehaviour {

	public float maxDist = 3.0f; //Furthest distance allowed to trigger
	public float minDist = 1.6f; //Shortest distance allowed to trigger
	//Script will trigger when within the range: minDist <= dist <= maxDist

	public Transform other; //Second object to look for

	private float objDist; //Variable to store the distance between the two objects

	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (other) {
			objDist = Vector3.Distance(other.position, transform.position);
			print("Distance to other: " + objDist);
			if (objDist <= maxDist && objDist >= minDist) { //If object is within the min-max range
				other.GetComponent<ScaleEffect>().Scale(1.5f);
			}
			else {
				other.GetComponent<ScaleEffect>().ResetScale(1);
			}
		}
	}
}
