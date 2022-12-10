using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScript : MonoBehaviour {

	public AudioSource bGMusic;

	public Button resetButton;

	void Start () {

		bGMusic.Play ();
	
	}

	void Update () {
	
	}

	public void OnClickedReset (Button resetButton) {
		
		Application.LoadLevel(0);
		
	}
}
