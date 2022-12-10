using UnityEngine;
using System.Collections;

public class ParticleSpeed : MonoBehaviour {

	public float speed = 1;

	void Start () {

		//GetComponent<ParticleSystem>().playbackSpeed = speed;
	
	}

	void Update () {
	
		GetComponent<ParticleSystem>().playbackSpeed = speed;

	}
}
