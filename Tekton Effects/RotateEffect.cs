using UnityEngine;
using System.Collections;


public class RotateEffect : MonoBehaviour {

	private bool rotate = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate) {
			Debug.Log("Rotating!");
			transform.Rotate(Vector3.right * Time.deltaTime);
		}
	}


	public void StartRotation(){
		rotate = true;
	}

	public void StopRotation() {
		rotate = false;
	}
}
