using UnityEngine;
using System.Collections;

public class SphereMove : MonoBehaviour {
	private float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)) {
			transform.Translate(-1 * speed * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.Translate( 1 * speed * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.W)) {
			transform.Translate(0, 1 * speed * Time.deltaTime,0);
		}
		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(0, -1 * speed * Time.deltaTime,0);
		}
	}
}
