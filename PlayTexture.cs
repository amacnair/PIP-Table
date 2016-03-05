using UnityEngine;
using System.Collections;

public class PlayTexture : MonoBehaviour {

	public MovieTexture movTexture;
	public bool loop;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
        movTexture.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
