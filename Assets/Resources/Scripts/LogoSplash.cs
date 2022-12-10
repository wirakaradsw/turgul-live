using UnityEngine;
using System.Collections;

public class LogoSplash : MonoBehaviour {

	public float time;

	void Start () {

		StartCoroutine ("GoToNextScene");
	}
	
	IEnumerator GoToNextScene () {
		
		yield return new WaitForSeconds(time);
//		Destroy (gameObject);
		Application.LoadLevel(1);
	}
}
