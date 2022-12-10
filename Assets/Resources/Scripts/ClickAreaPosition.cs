using UnityEngine;
using System.Collections;

public class ClickAreaPosition : MonoBehaviour {
	
	void Start () {
	


	}

	void Update () {

		GameObject camera1 = GameObject.Find ("MainCamera");
		transform.position = new Vector3 (camera1.transform.position.x, camera1.transform.position.y, -2f);
	
	}
}
