using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitScript : MonoBehaviour {

	public Button exitButton;
	public AudioSource buttonSound;
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	public void OnClickedExit (Button exitButton) {

		//buttonSound.Play ();
		Application.LoadLevel(1);
		
	}
}
