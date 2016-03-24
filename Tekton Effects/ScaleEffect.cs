using UnityEngine;
using System.Collections;

public class ScaleEffect : MonoBehaviour {

	private int frameSmooth = 2;
	private int smoothCount = 0;
	private bool scaled;
	private float xStart;
	private float yStart;
	private float zStart;

	//private bool scaled = false;

	// Use this for initialization
	void Start () {
		xStart = this.transform.localScale.x;
		yStart = this.transform.localScale.y;
		zStart = this.transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (!scaled) {
			xStart = this.transform.localScale.x;
			yStart = this.transform.localScale.y;
			zStart = this.transform.localScale.z;
		}
	
	}

	public void Scale(float mult) {
		if (smoothCount >= frameSmooth ) {
			transform.localScale = new Vector3(xStart*mult, yStart*mult, zStart*mult);
			scaled = true;
			smoothCount = 0;
		}
		else {
			++smoothCount;
		}
	}

	public void ResetScale() {
		if (smoothCount >= frameSmooth ) {
			transform.localScale = new Vector3(xStart,yStart,zStart);
			scaled = false;
		}
		else {
			++smoothCount;
		}
	}
}
