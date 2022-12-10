using UnityEngine;
using System.Collections;

public class MovingScript : MonoBehaviour {

	public float speed = -0.4f;
	
	void Start () {
		
	}
	
	void Update () {
		
		transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		
	}
}
