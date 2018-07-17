using UnityEngine;
using System.Collections;

public class ShapableBehaviour : MonoBehaviour {
	public GameObject model;
	public GameObject tool;


	private float myRadius = 1f;
	private float myScale = 50f;
	private float offset = 0.01f;


	private Mesh modelMesh;
	private SphereCollider toolCollider;

	void Start () {
		modelMesh = model.GetComponent<MeshFilter>().mesh;
		toolCollider = tool.GetComponent<SphereCollider>();
	}


	private Vector3 cur; // Current mesh vector
	private Vector3 dir; // Direction vector
	private Vector3 myPos; // Current position

	private Vector3[] meshVectors;
	void Reform() {
		meshVectors = modelMesh.vertices;
		myPos = model.transform.position;
		//bool[] smoothingRequired = new bool[meshVectors.Length]; // smoothing required?
		
		for(int i = 0; i < meshVectors.Length; i++) {
			cur = model.transform.TransformPoint(meshVectors[i]);
			dir = cur - tool.transform.position;
			if(dir.magnitude < toolCollider.radius) {
				cur = tool.transform.position + dir.normalized * toolCollider.radius + dir.normalized * offset;
				//smoothingRequired[i] = true;
			}
			meshVectors[i] = model.transform.InverseTransformPoint(cur);
		}
		//modelMesh.vertices = SmoothFilter.laplacianFilter(meshVectors, modelMesh.triangles, smoothingRequired);
		modelMesh.vertices = meshVectors;
	}
	private Vector3 toolPos;
	private Vector3 clo; // Closest point to tool
	void Reform2() {
		meshVectors = modelMesh.vertices;
		myPos = model.transform.position;
		toolPos = tool.transform.position;

		for(int i = 0; i < meshVectors.Length; i++) {
			cur = model.transform.TransformPoint(meshVectors[i]);
			dir = (cur - myPos).normalized;

			if((cur-toolPos).magnitude < toolCollider.radius) {
				clo = (myPos)-Vector3.Dot((myPos-toolPos),dir)*dir;
				float s = Mathf.Sqrt((toolCollider.radius*toolCollider.radius) + ((clo-toolPos).magnitude*(clo-toolPos).magnitude));
				//Debug.Log(s);
				cur = clo - (s + offset) * dir;
				//smoothingRequired[i] = true;
			}
			meshVectors[i] = model.transform.InverseTransformPoint(cur);
		}
		//modelMesh.vertices = SmoothFilter.laplacianFilter(meshVectors, modelMesh.triangles, smoothingRequired);
		modelMesh.vertices = meshVectors;
	}

	// Update is called once per frame
	void Update () {
		Reform();
	}
}
