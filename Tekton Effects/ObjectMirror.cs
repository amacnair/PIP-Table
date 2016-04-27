using UnityEngine;
using System.Collections;

public class ObjectMirror : MonoBehaviour {

	private GameObject Clone;
	private MeshRenderer MR;
	private Mesh mesh;

	private bool isMirrored = false; //Use to check if the effect is already active


	// Use this for initialization
	void Start () {
		//Grab the object mesh and store it for future use
		mesh = GetComponent<MeshFilter>().sharedMesh;
		MR = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//-----------------------------------------------------------------------------------
	// void Mirror()
	// Creates a duplicate of the object to create a "mirroring" effect along the x-axis
	//-----------------------------------------------------------------------------------
	public void Mirror() {

		if (!isMirrored) {
			for (int submesh = 0; submesh < mesh.subMeshCount; ++submesh) { //Loop over any/all of the submeshes that may make up the object
				
				Clone = new GameObject("Clone " + submesh); //Create a new GameObject to store the cloned mesh.
				
				//Copy over all of the transform information from the parent object
				Clone.transform.position = (transform.position + new Vector3(transform.localScale.x, 0, 0)); //Shift the clone along the positive x-axis
				Clone.transform.rotation = transform.rotation;
				Clone.transform.localScale = transform.localScale;

				//Copy over the meshes and materials
				Clone.AddComponent<MeshRenderer>().material = MR.materials[submesh];
				Clone.AddComponent<MeshFilter>().mesh = mesh;

				//Set the orignal object as the parent the clones position and roation will follow the original
				Clone.transform.parent = gameObject.transform;
			}

			isMirrored = true; //Set the Mirrored flag to true
		}
	}

	//-------------------------------------------------------------
	// void Reset()
	// Stops the mirroring effect by deleting the duplicate object
	//-------------------------------------------------------------
	public void Reset() {
		if (isMirrored) {
			Destroy(Clone);
			isMirrored = false;
		}
	}
}
