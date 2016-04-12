using UnityEngine;
using System.Collections;

public class MeshSkew : MonoBehaviour {

	public float effectStrength = 1.0f;

	private float objMaxX;
	private float objMaxY;
	private float objMaxZ;

	private bool skewed = false;


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
		skew ();
	}

	public void skew() {
		if (!skewed) {
			Mesh mesh = GetComponent<MeshFilter> ().mesh;
			Vector3[] vertices = mesh.vertices;

			for (int i = 0; i < vertices.Length; i++) {

				vertices [i] += new Vector3 (vertices [i].x + (effectStrength / objMaxY/2) * vertices[i].y, 0.0f, 0.0f);
				i++;
			} 
			mesh.vertices = vertices;
			mesh.RecalculateBounds ();
			skewed = true;
		}
	}
}