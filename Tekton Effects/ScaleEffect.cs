using UnityEngine;
using System.Collections;

public class ScaleEffect : MonoBehaviour {

	private int frameSmooth = 2;
	private int smoothCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Scale(float mult) {
		if (smoothCount >= frameSmooth ) {
			transform.localScale = new Vector3(1f*mult, 2f*mult, 1f*mult);
			smoothCount = 0;
		}
		else {
			++smoothCount;
		}
	}

	public void ResetScale(float n) {
		if (smoothCount >= frameSmooth ) {
			transform.localScale = new Vector3(1,2,1);
		}
		else {
			++smoothCount;
		}
	}
}
