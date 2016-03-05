using UnityEngine;
using System.Collections;

public class ShiftToFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector3.forward * -1.6f);
		transform.localPosition = new Vector3(transform.localPosition.x, 0.1f, transform.localPosition.z);
	}
}
