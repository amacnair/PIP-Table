using UnityEngine;
using System.Collections;

public class ProximyTrigger : MonoBehaviour {

	public float maxDist = 3.0f;
	public float minDist = 1.6f; 
	public string searchTag = "Token";
	public float objDist;

	private GameObject[] tokens;
	private GameObject[] inRange;

	public Transform other;


	// Use this for initialization
	void Start () {
		if (tokens == null) { //Check if the tokens array is empty
			tokens = GameObject.FindGameObjectsWithTag("Token"); //Populate array with all token objects
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (other) {
			objDist = Vector3.Distance(other.position, transform.position);
			print("Distance to other: " + objDist);
			if (objDist <= maxDist && objDist >= minDist) { //If object is within the min-max range
				other.GetComponent<ScaleEffect>().Scale(2);
			}
			else {
				other.GetComponent<ScaleEffect>().ResetScale(1);
			}
		}
	}

	/*
	void ScanObjects() {

		//if (tokens.size == 0) {
		//	Debug.Log("No objects are labeled as Tokens!");
		//}
		foreach (GameObject token in tokens) {

		}
	}
	*/
}
