using UnityEngine;
using System.Collections;

public class BlueCube : MonoBehaviour {

	public float speed = 1f;
	
	void Start () {
		
	}
	
	void Update () {
		
		if (transform.position.z < -4f) {
			Destroy (gameObject);
		}
		
		if (Time.timeScale != 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
		}
	}
}
