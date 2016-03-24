/*

Script: 	TokenTrigger

Author: 	Alex MacNair

Function:	Detects nearby table objects (Tektons) and triggers a call to an 
			effect script on that object.

Usage: 		This script should be applied to the effect object(s) (tokens). 

*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TokenTrigger : MonoBehaviour {

	public float maxDist = 3.0f;
	public float minDist = 1.6f; 
	public string searchTag = "Tekton";
	public enum effects {None, Rotate, Scale, StretchX, StretchY, StretchZ };

	public effects effect = effects.None;

	private float objDist;

	private GameObject[] tektons;
	private List<GameObject> inRange;

	private Transform other;

	private MeshRenderer mesh;



	// Use this for initialization
	void Start () {
		
		tektons = GameObject.FindGameObjectsWithTag("Tekton"); //Populate array with all token objects
		inRange = new List<GameObject>();
			
	}
	
	// Update is called once per frame
	void Update () {
		mesh = GetComponent<MeshRenderer>();

		if (mesh.enabled) { //If the token is active, scan for Tektons
			ScanObjects();
		}

		if (!mesh.enabled) { //If the token is not active, stop it's effect(s)
			stopEffects();
		}
	}



	public void ScanObjects() {

		if (tektons[0] == null) { //Make sure there is at least one object in the array
			Debug.Log("No objects are tagged as tektons!");
			return;
		}

		foreach (GameObject tekton in tektons) {
			//Debug.Log(tekton);
		
			other = tekton.transform;


			if (!other.GetComponent<MeshRenderer>().enabled) {
				//If the current tekton is hidden (off the table) don't bother to check it 
				continue;
			}

			if (tekton.transform) {
				//If the data is valid, calculate the distance between the objects
				objDist = Vector3.Distance(other.position, this.transform.position);
			}
			
			if ( (objDist <= maxDist && objDist >= minDist) && mesh.enabled) { //If object is within the min-max range

				inRange.Add(tekton);

				switch(effect) {
					case effects.None:
						continue;

					case effects.Rotate:
						doRotate();
						continue;

					case effects.Scale:
						doScale(1.5f);
						continue;

					case effects.StretchX:
						doStretchX(2.0f);
						continue;

					case effects.StretchY:
						doStretchY(2.0f);
						continue;

					case effects.StretchZ:
						doStretchZ(2.0f);
						continue;

					default:
						continue;
				}
			}
			
			if ( (objDist > maxDist)) {

				inRange.Remove(tekton);

				stopEffects();
			}
		}
	}


	public void stopEffects() {
		
		foreach (GameObject tekton in inRange) {

			other = tekton.transform;

			switch(effect) {
				case effects.None:
					return;

				case effects.Rotate:
					endRotate();
					return;

				case effects.StretchX:
					endStretchX();
					return;

				case effects.StretchY:
					endStretchY();
					return;

				case effects.StretchZ:
					endStretchZ();
					return;

				case effects.Scale:
					endScale();
					return;
				
				default: 
					return;
			}
		}	
	}

	public void doRotate() { other.GetComponent<RotateEffect>().StartRotation(); }
	public void doScale(float n) { other.GetComponent<ScaleEffect>().Scale(n); }
	public void doStretchX(float n) { other.GetComponent<StretchEffect>().StretchX(n); }
	public void doStretchY(float n) { other.GetComponent<StretchEffect>().StretchY(n); }
	public void doStretchZ(float n) { other.GetComponent<StretchEffect>().StretchZ(n); }


	public void endRotate() { other.GetComponent<RotateEffect>().StopRotation(); }
	public void endScale() { other.GetComponent<ScaleEffect>().ResetScale(); }
	public void endStretchX() { other.GetComponent<StretchEffect>().ResetStretchX(); }
	public void endStretchY() { other.GetComponent<StretchEffect>().ResetStretchY(); }
	public void endStretchZ() { other.GetComponent<StretchEffect>().ResetStretchZ(); }
}

