/*

Script: 	PlayTexture

Author: 	Alex MacNair

Function:	Used to play a video texture applied to an object and enable looping.

Usage: 		This script should be applied objects with video textures if moving
			images are desired. The movie file must be specified in the objects's
			inspector pane.

*/


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
