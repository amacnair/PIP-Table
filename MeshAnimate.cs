using UnityEngine;
using System.Collections;

public class MeshAnimate : MonoBehaviour {

	private int frameCount; //Total number of objects 
	private float time = 0;
	public int activeFrame = 0;
	public bool effectActive = false;
	private bool forward = true;


	public float frameSpeed = 0.25f; //Time delay in seconds between frames
	private GameObject[] frames;

	// Use this for initialization
	void Start () {
		frameCount = transform.childCount;
		frames = new GameObject[frameCount];

		int index = 0;

		foreach (Transform child in transform) {
			frames[index] = child.gameObject;
			++index;
		}

		for (int i = 1; i < frameCount; ++i) {
			frames[i].SetActive(false);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		if (activeFrame == frameCount-1) { forward = false; }
		if (activeFrame == 0) { forward = true; }

		/*if (effectActive) {
			AnimateOut();
		}
		*/

	}

	public void AnimateIn() {
		Debug.Log("AnimateIn!");
		if (activeFrame < frameCount-1) {
			time += Time.deltaTime;
			if (time >= frameSpeed) {
				frames[activeFrame].SetActive(false);
				if (activeFrame >= frameCount-1) {
					activeFrame = 0;
				} 
				else { ++activeFrame; }

				frames[activeFrame].SetActive(true);
				time -= frameSpeed;
			}
		}
	} 

	public void AnimateOut() {
		if (activeFrame > 0) {
			time += Time.deltaTime;
			if (time >= frameSpeed) {
				frames[activeFrame].SetActive(false);
				if (activeFrame <= 0) {
					activeFrame = 0;
				} 
				else { --activeFrame; }

				frames[activeFrame].SetActive(true);
				time -= frameSpeed;
			}
		}
	}

	public void Animate() {
		if (forward) {
			AnimateIn();
		}
		if (!forward) {
			AnimateOut();
		}
	}
}
