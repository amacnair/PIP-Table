using UnityEngine;
using System.Collections;

public class 2Sphere : MonoBehaviour {
	//This class causes an object to morph into
	//a sphere
	//Initialise the effect strength
	//1.0 by default
	public float effectStrength = 1.0f;
	//Initialise the objects max vertex values
	//For x, y, and z
	private float objMaxX;
	private float objMaxY;
	private float objMaxZ;

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
		2Sphere ();
	}

	public void 2Sphere() {

		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;

		//Iterate through each vertex
		for (int i=0; i < vertices.Length; i++){
			//The vertex
			Vector3 vertex = vertices[i];
			//The x-value of the vertex
			float x = vertex.x;
			//The y-value of the vertex
			float y = vertex.y;
			//The z-value of the vertex
			float z = vertex.z
			//Non-dimensionalise verticies
			//w.r.t. object dimensions
			x = x/(objMaxX/2.0f)
			y = y/(objMaxY/2.0f)
			z = z/(objMaxZ/2.0f)
			// Map the verticies to a unit sphere via magic:
			xp = x*Mathf.Sqrt(1.0f - (Mathf.Pow(y,2)/2.0f) -(Mathf.Pow(z,2)/2.0f) - ((Mathf.Pow(y,2)*Mathf.Pow(z,2))/3.0f))
			yp = y*Mathf.Sqrt(1.0f - (Mathf.Pow(z,2)/2.0f) -(Mathf.Pow(x,2)/2.0f) - ((Mathf.Pow(z,2)*Mathf.Pow(x,2))/3.0f
			xp = z*Mathf.Sqrt(1.0f - (Mathf.Pow(x,2)/2.0f) -(Mathf.Pow(y,2)/2.0f) - ((Mathf.Pow(x,2)*Mathf.Pow(y,2))/3.0f
			//Dimensionalise and apply the tranformation
			xf = xp * (objMaxX/2.0f)
			yf = yp * (objMaxY/2.0f)
			zf = zp * (objMaxZ/2.0f)
			//Assign new values
			vertices[i] = new Vector3(xf, yf, zf);
		}
	}
}
