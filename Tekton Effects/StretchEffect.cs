using UnityEngine;
using System.Collections;

public class StretchEffect : MonoBehaviour {


	private int frameSmooth = 2;
	private int smoothCount = 0;

	public bool stretchedX = false;
	public bool stretchedY = false;
	public bool stretchedZ = false;

	private float xStart;
	private float yStart;
	private float zStart; 

	// Use this for initialization
	void Start () {
		xStart = this.transform.localScale.x; //Store the inital scale to be reverted to
		yStart = this.transform.localScale.y; //Store the inital scale to be reverted to
		zStart = this.transform.localScale.z; //Store the inital scale to be reverted to
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StretchX(float mult) {
		
		if (!stretchedX) { //Check that the effect isn't already being applied on this axis
			if (smoothCount >= frameSmooth) {
				transform.localScale = new Vector3(mult*transform.localScale.x, transform.localScale.y, transform.localScale.z);
				stretchedX = true;
				smoothCount = 0;
			} else { ++smoothCount; }
		}
	}

	public void StretchY(float mult) {
		
		if (!stretchedY) { //Check that the effect isn't already being applied on this axis
			if (smoothCount >= frameSmooth) {
				transform.localScale = new Vector3(transform.localScale.x, mult*transform.localScale.y, transform.localScale.z);
				stretchedY = true;
				smoothCount = 0;
			} else { ++smoothCount; }
		}
	}

	public void StretchZ(float mult) {
		
		if (!stretchedZ) { //Check that the effect isn't already being applied on this axis
			if (smoothCount >= frameSmooth) {
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, mult*transform.localScale.z);
				stretchedZ = true;
				smoothCount = 0;
			} else { ++smoothCount; }
		}
	}



	public void ResetStretchX() {
		if (stretchedX) {
			if (smoothCount >= frameSmooth ) {
				transform.localScale = new Vector3(xStart, transform.localScale.y, transform.localScale.z);
				stretchedX = false;
				smoothCount = 0;
			}
			else {
				++smoothCount;
			}
		}
	}

	public void ResetStretchY() {
		if (stretchedY) {
			if (smoothCount >= frameSmooth ) {
				transform.localScale = new Vector3(transform.localScale.x, yStart, transform.localScale.z);
				stretchedY = false;
				smoothCount = 0;
			}
			else {
				++smoothCount;
			}
		}
	}

	public void ResetStretchZ() {
		if (stretchedZ) {
			if (smoothCount >= frameSmooth ) {
				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, zStart);
				stretchedZ = false;
				smoothCount = 0;
			}
			else {
				++smoothCount;
			}
		}
	}
}
