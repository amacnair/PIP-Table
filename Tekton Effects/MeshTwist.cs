using UnityEngine;
using System.Collections;

public class MeshTwist : MonoBehaviour {

	private bool effectActive = false; //Use to check if the effect is already active

	private float objMaxX;
	private float objMaxY;
	private float objMaxZ;

	private bool twisted = false;

	//Deafult maximum twist in degrees
	public float twist_max = 25;


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
			if (vertices[i].x < minX) { minX = vertices[i].x; } 
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

	public void Twist(){
		if (!effectActive) {
			
			Mesh mesh = GetComponent<MeshFilter> ().mesh;
			
			float H = objMaxY; //Height of the object
	 		float theta_max = twist_max; //Maximum twist angle in degrees
			theta_max = theta_max * Mathf.Deg2Rad; //Maximum twist angle in radians
			float slope = theta_max/H; //Twisting slope
			
			Vector3[] vertices = mesh.vertices; //The list of verticies in the object
			
			for (int i=0; i < vertices.Length; i++) { //For each vertex in the list of verticies
				
				Vector3 vertex = vertices[i]; //3-dimensional vertex of shape (0,3)
				
				float x = vertex.x; //The horizontal x-value of the vertex
				float y = vertex.y; //The vertical y-value of the vertex
				float z = vertex.z; //The horizontal z-value of the vertex
				
				float theta = theta_max*((y/H)+0.5f); //The amount to twist the point wrt origin [radians]
				
				float xf = x*Mathf.Cos(theta)+z*Mathf.Sin(theta); //The new x-value
				float zf = z*Mathf.Cos(theta)-x*Mathf.Sin(theta); //The new z-value
				
				vertices[i] = new Vector3(xf, y, zf); //Assign new x and y value
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds(); //Recalcuate the bounding volume of the mesh after modification

			effectActive = true;
		}
	}


	//Performs the twisting operation in reverse to return to the orignal mesh state
	public void ResetTwist() {
		if (effectActive) {
			
			Mesh mesh = GetComponent<MeshFilter> ().mesh;
			
			float H = objMaxY; //Height of the object
			float theta_max = twist_max; //Maximum twist angle in degrees
			theta_max = theta_max * Mathf.Deg2Rad; //Maximum twist angle in radians
			float slope = theta_max/H; //Twisting slope
			
			Vector3[] vertices = mesh.vertices; //The list of verticies in the object
			
			for (int i=0; i < vertices.Length; i++) { //For each vertex in the list of verticies
				
				Vector3 vertex = vertices[i]; //3-dimensional vertex of shape (x,y,z)
				
				float x = vertex.x; //The horizontal x-value of the vertex
				float y = vertex.y; //The vertical y-value of the vertex
				float z = vertex.z; //The horizontal z-value of the vertex
				
				float theta = (-1f * theta_max*((y/H)+0.5f)); //The amount to twist the point wrt origin [radians]
				
				float xf = x*Mathf.Cos(theta)+z*Mathf.Sin(theta); //The new x-value
				float zf = z*Mathf.Cos(theta)-x*Mathf.Sin(theta); //The new z-value
				
				vertices[i] = new Vector3(xf, y, zf); //Assign new x and y value
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds(); //Recalcuate the bounding volume of the mesh after modification

			effectActive = false;
		}
	}
}