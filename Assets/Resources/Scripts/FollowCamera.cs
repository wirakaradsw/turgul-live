using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	GameObject camera1;

	void Start () {
	
		camera1 = GameObject.Find ("MainCamera");
	}

	void Update () {
	
		transform.position = new Vector3 (camera1.transform.position.x, transform.position.y, transform.position.z);
	}
}
