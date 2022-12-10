using UnityEngine;
using System.Collections;

public class SpectatorSpawner : MonoBehaviour {

	GameObject spectator;

	void Start () {
	
		for (int i = 0; i <= 8; i++) {
			spectator = Instantiate (Resources.Load ("Prefabs/Spectator"), new Vector3 (-12f + (i * 3f), 1f, 4.5f), Quaternion.identity) as GameObject;
			spectator.GetComponent <SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		}

		for (int j = 0; j <= 9; j++) {
			spectator = Instantiate (Resources.Load ("Prefabs/Spectator"), new Vector3 (-13.5f + (j * 3f), 2f, 5f), Quaternion.identity) as GameObject;
			spectator.GetComponent <SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			spectator.GetComponent<SpriteRenderer>().sortingOrder = -9;
		}

		for (int j = 0; j <= 10; j++) {
			spectator = Instantiate (Resources.Load ("Prefabs/Spectator"), new Vector3 (-15f + (j * 3f), 3f, 5.5f), Quaternion.identity) as GameObject;
			spectator.GetComponent <SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			spectator.GetComponent<SpriteRenderer>().sortingOrder = -10;
		}

		for (int j = 0; j <= 9; j++) {
			spectator = Instantiate (Resources.Load ("Prefabs/Spectator"), new Vector3 (-13.5f + (j * 3f), 4f, 6f), Quaternion.identity) as GameObject;
			spectator.GetComponent <SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			spectator.GetComponent<SpriteRenderer>().sortingOrder = -11;
		}

		for (int j = 0; j <= 10; j++) {
			spectator = Instantiate (Resources.Load ("Prefabs/Spectator"), new Vector3 (-15f + (j * 3f), 5f, 6.5f), Quaternion.identity) as GameObject;
			spectator.GetComponent <SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			spectator.GetComponent<SpriteRenderer>().sortingOrder = -12;
		}

	}

	void Update () {
	
	}
}
