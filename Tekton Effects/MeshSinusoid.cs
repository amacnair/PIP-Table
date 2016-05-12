using UnityEngine;
using System.Collections;

public class MeshSinusoid : MonoBehaviour {
	//This class causes an object to morph into 
	//the shape of a sinusoid.

	private bool effectActive = false; //Use to check if the effect is already active


	//Initialise the objects max vertex values
	//For x, y, and z
	private float objMaxX;
	private float objMaxY;
	private float objMaxZ;

	//Values to be argued
	//The percent of wave amplitude wrt object's width
	//This percentage describes the maximum change of 
	//a vertex's translation position wrt its object's width
	public float amplitude_percentage;

	// Use this for initialization
	void Start () {

		float minX = 0;
		float minY = 0;
		float minZ = 0;
		float maxX = 0;
		float maxY = 0;
		float maxZ = 0;

		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;

		for (int i = 0; i < vertices.Length; i++) {
			if (vertices[i].x < minX) {	minX = vertices[i].x; } 
			if (vertices[i].x > maxX) { maxX = vertices[i].x; }
			if (vertices[i].y < minY) { minY = vertices[i].y; } 
			if (vertices[i].y > maxY) { maxY = vertices[i].y; }
			if (vertices[i].z < minZ) { minZ = vertices[i].z; } 
			if (vertices[i].y > maxZ) { maxZ = vertices[i].z; }
		}

		objMaxX = Mathf.Abs (maxX) + Mathf.Abs (minX);
		objMaxY = Mathf.Abs (maxY) + Mathf.Abs (minY);
		objMaxZ = Mathf.Abs (maxZ) + Mathf.Abs (minZ);

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Sinusoid() {
		if (!effectActive) {
			Mesh mesh = GetComponent<MeshFilter> ().mesh;
			Vector3[] vertices = mesh.vertices;
			//Amplitude percentage of width
			float percent = amplitude_percentage;

			float width = objMaxX; //The width of the object

			//The max vertex translation
			//Absolute amplitude
			float dx_max = width * percent;

			//We want the whole body to resemble
			//one sinusoidal cycle, thus the 
			//positive max y should resemble pi, 
			//and the negative max y should resemble 
			//negative pi, so we should non-dimensoinalise
			//the y-values in the context of this function.
			//The half height of the object:
			float half_height = objMaxY / 2.0f;

			//Thus the sinusoid function can be
			//constructed with the form:
			//dx(y)=dx_max*sin(y)

			//Iterate through each vertex
			for (int i = 0; i < vertices.Length; i++) {
				Vector3 vertex = vertices [i]; //The vertex
				
				float x = vertex.x; //The x-value of the vertex
				float y = vertex.y; //The y-value of the vertex

				float percent_y = y / half_height; //Percent along y wrt half_height
				float phase = percent_y * Mathf.PI; //Cooresponding radian phase representation

				float dx = dx_max * Mathf.Sin (phase); //Amount to shift x accourding to y
				float xf = x + dx; //Instantiate the change to the vertex

				
				vertices [i] = new Vector3 (xf, vertex.y, vertex.z); //Assign new value
				//Both the top and bottom of the object 
				//should appear to be unchanged
			}
			mesh.vertices = vertices;
			effectActive = true;
		}
	}


	public void ResetSinusoid() {
		//TODO: Implement the reverse calculation
		Debug.Log("ResetSinusoid() is being called but has not been written yet! MeshSinusoid.cs");
	}
}