using UnityEngine;
using System.Collections;

public class MeshTwist : MonoBehaviour {

	public float effectStrength = 1.0f;

	private float objMaxX;
	private float objMaxY;
	private float objMaxZ;

	private bool twisted = false;

	//Maximum twist
	public float twist_max;


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
			if (vertices[i].x < minX) {
				minX = vertices[i].x;
			} 
			if (vertices[i].x > maxX){
				maxX = vertices[i].x;
			}
			if (vertices[i].y < minY) {
				minY = vertices[i].y;
			} 
			if (vertices[i].y > maxY){
				maxY = vertices[i].y;
			}
			if (vertices[i].z < minZ) {
				minZ = vertices[i].z;
			} 
			if (vertices[i].y > maxZ){
				maxZ = vertices[i].z;
			}
		}

		objMaxX = Mathf.Abs (maxX) + Mathf.Abs (minX);
		objMaxY = Mathf.Abs (maxY) + Mathf.Abs (minY);
		objMaxZ = Mathf.Abs (maxZ) + Mathf.Abs (minZ);

	}
	
	// Update is called once per frame
	void Update () {
		twist ();
	}

	public void twist(){
		//Height of the object
		float height = objMaxY;
		//Maximum twist angle in degrees
		float theta_max = twist_max;
		//Maximum twist angle in radians
		float theta_max = theta_max * Mathf.Deg2Rad;
		//Twisting slope
		float slope = theta_max/height;
		//The list of verticies in the object
		Vector3[] vertices = mesh.vertices;
		//For each vertex in the list of verticies
		for (int i=0; i < vertices.Length; i++) {
			//3-dimensional vertex of shape (0,3)
			Vector3 vertex = vertices[i];
			//The horizontal x-value of the vertex
			float x = vertex.x;
			//The vertical y-value of the vertex
			float y = vertex.y;
			//The horizontal z-value of the vertex
			float z = vertex.z;
			//The scaler distance away from the origin
			float d = vertex.magnitude;
			//The amount to twist the point wrt origin [radians]
			float theta = slope*y;
			//The new x-value
			float xf = d*Mathf.Cos(theta);
			//The new z-value
			float zf = d*Mathf.Sin(theta);
			//Assign new x-value
			vertices[i].x = xf;
			//Assign new z-value
			vertices[i].z = zf;
		}
	}
}