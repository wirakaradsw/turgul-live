using UnityEngine;
using System.Collections;

public class FadeOutThenDestroy : MonoBehaviour {

	public float time;

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
			GetComponent<SpriteRenderer>().color = new Color (0.5f, 0, 0, i);
			yield return new WaitForSeconds(time);
		}
	}
}
