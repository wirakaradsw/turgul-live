using UnityEngine;
using System.Collections;

public class FadeOutThenDestroy2 : MonoBehaviour {

	public float time;

	public float redVal = 1f;
	public float greenVal = 1f;
	public float blueVal = 1f;

	void Start () {
	
		StartCoroutine ("FadeOutDestroy");

	}

	void Update () {

		if (GetComponent<SpriteRenderer> ().color.a == 0) {
			Destroy (gameObject);
		}

	}

	IEnumerator FadeOutDestroy(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
			}
			GetComponent<SpriteRenderer>().color = new Color (redVal, greenVal, blueVal, i);
			yield return new WaitForSeconds(time);
		}
	}
}
