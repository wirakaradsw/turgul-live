using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

	GameManager manager;

	GameObject player1;

	void Start () {

		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
	
	}

	void Update () {

		player1 = manager.player1;
	
		if ((player1.transform.position.x < -5f && player1.transform.position.x > -19.9f) || (player1.transform.position.x > 5f && player1.transform.position.x < 19.9f) || (player1.transform.position.x > -0.5f && player1.transform.position.x < 0.5f)) {
			transform.position = new Vector3 (transform.position.x + ((player1.transform.position.x - transform.position.x) * 0.1f) , transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}

	}
}
