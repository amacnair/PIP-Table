using UnityEngine;
using System.Collections;

public class ObjectMirror : MonoBehaviour {

	private MeshRenderer MR;
	private Mesh parentMesh;

	private bool effectActive = false; //Use to check if the effect is already active


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//-----------------------------------------------------------------------------------
	// void Mirror()
	// Creates a duplicate of the object to create a "mirroring" effect along the x-axis
	//-----------------------------------------------------------------------------------
	public void Mirror() {

		if (!effectActive) { //Check that the effect is not already active

			int children = transform.childCount; //We must store the starting number because the number will change as we duplicate

			if (transform.childCount >= 1) { //If there is one or more child we must clone each of them
				Debug.Log(transform.childCount);
				for (int childNum = 0; childNum < children; childNum++) { //Loop over each child
					Debug.Log(transform.childCount);
					GameObject tempChild = transform.GetChild(childNum).gameObject;

					Duplicate(tempChild, 0, 0.0f);
				}
			}

			else {
				Duplicate(gameObject, 0, 0.0f);
			}

			effectActive = true; //Set the effect active flag to true
		}
	}


	//-------------------------------------------------------------
	// void Reset()
	// Stops the mirroring effect by deleting the duplicate object
	//-------------------------------------------------------------
	public void Reset() {
		if (effectActive) {
			//Destroy(Clone);
			effectActive = false;
		}
	}


	//------------------------------------------------------------------------------------
	// GameObject Duplicate(GameObject parent, int axis, float padding)
	// Takes an input GameObject and returns a duplicate copy of it shifted along an axis
	// 		parent: the source GameObject to copy attributes from
	//		axis: 0-2 to specify what axis to shift along
	// 			  0 = X   1 = Y   2 = Z
	//		padding: a floating point distance to leave between the parent and child.
	//------------------------------------------------------------------------------------
	private GameObject Duplicate(GameObject parent, int axis, float padding) {
		
		if (axis < 0 || axis > 2) {	Debug.LogError("Axis value is out of range 0-2!"); } //Check for bad axis value

		GameObject Clone = new GameObject(parent.name + "_clone"); //Create a new GameObject to store the cloned mesh.
		Mesh parentMesh = parent.GetComponent<MeshFilter>().sharedMesh;
		MeshRenderer MR = parent.GetComponent<MeshRenderer>();
					
		//Copy over the transform information from the parent object
		switch(axis) {
			case 0:
				Clone.transform.position = (parent.transform.position + new Vector3(parent.transform.localScale.x + padding, 0, 0)); //Shift the clone along the positive x-axis
				break;
			case 1:
				Clone.transform.position = (parent.transform.position + new Vector3(0, parent.transform.localScale.y + padding, 0)); //Shift the clone along the positive y-axis
				break;
			case 2:
				Clone.transform.position = (parent.transform.position + new Vector3(0, 0, parent.transform.localScale.z + padding)); //Shift the clone along the positive z-axis
				break;
			default:
				Debug.Log("Error axis value out of range 0-2!");
				break;
		}

		Clone.transform.rotation = parent.transform.rotation;
		Clone.transform.localScale = parent.transform.localScale;

		//Copy over the meshes and materials
		Clone.AddComponent<MeshRenderer>().material = MR.materials[0];
		Clone.AddComponent<MeshFilter>().mesh = parentMesh;

		//Set the orignal object as the parent the clones position and roation will follow the original
		Clone.transform.parent = gameObject.transform;
		return Clone;
	}
}
