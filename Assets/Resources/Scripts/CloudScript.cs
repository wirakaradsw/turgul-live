using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	public float speed = 0.01f;

	void Start () {
	
	}

	void Update () {
	
		if (transform.position.x > 80f) {
			transform.position = new Vector3 (-80f, transform.position.y, transform.position.z);
		}

		if (Time.timeScale != 0) {
			transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		}
	}
}
