using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	GameObject blueCube;

	float moveTimer = 0;
	public float moveTimerMax = 100;

	int randSpawn = 0;

	float randX = 0;
	float randY = 0;
	
	void Start () {
		
		moveTimer = moveTimerMax;

		transform.position = new Vector3(Random.Range (-5f, 5f), Random.Range (-5f, 0f), transform.position.z);

		blueCube = Instantiate (Resources.Load ("Prefabs/BlueCube"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		blueCube.transform.Rotate (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f));
	}
	
	void Update () {
		
		moveTimer =- Time.deltaTime;
		
		if (moveTimer <= 0) {
			
			moveTimer = moveTimerMax;
			
			randX = Random.Range (-5f, 5f);
			randY = Random.Range (-5f, 0f);
			randSpawn = Random.Range (1, 4);
			
			transform.position = new Vector3(randX, randY, transform.position.z);

			if (randSpawn == 2){

				blueCube = Instantiate (Resources.Load ("Prefabs/BlueCube"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
				blueCube.transform.Rotate (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f));
			}
			
		}
		
	}
}
