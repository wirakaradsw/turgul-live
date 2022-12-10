using UnityEngine;
using System.Collections;

public class shadowFollows : MonoBehaviour {

	public GameObject character;
	
	void Start () {
	


	}

	void Update () {
	
		transform.position = new Vector3 (character.transform.position.x + 0.2f, transform.position.y, transform.position.z);
		transform.localScale = new Vector3 (-0.6f * ((10 - character.transform.position.y) / 10), 0.25f * ((10 - character.transform.position.y) / 10), 1);

	}
}
