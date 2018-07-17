using UnityEngine;
using System.Collections;

public class ShapableMove : MonoBehaviour {
	private float rotationSpeed = 90f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q)) {
			transform.Rotate(0, rotationSpeed * Time.deltaTime,0);
		}
		if(Input.GetKey(KeyCode.E)) {
			transform.Rotate(0, -rotationSpeed * Time.deltaTime,0);
		}
	}
}
