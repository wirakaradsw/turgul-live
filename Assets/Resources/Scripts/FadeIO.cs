using UnityEngine;
using System.Collections;

public class FadeIO : MonoBehaviour {

	int startTime = 0;
	public int startTimeMax;
	public float fadeTime;

	bool start = false;
	bool solid = false;
	bool change = false;
	bool selfDestroy = false;
	
	void Start () {

		startTime = startTimeMax;
		start = true;
		GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
		//StartCoroutine ("FadeOutDestroy");
		
	}
	
	void Update () {

		if (start) {
			startTime --;
		}

		if (startTime == 0) {

			StartCoroutine ("FadeIn");
			start = false;
			startTime = startTimeMax;
		}

		if (change) {
			StartCoroutine ("FadeOut");
		}
		
		if (selfDestroy) {
			solid = false;
			Destroy (gameObject);
		}
		
	}
	
	IEnumerator FadeIn(){
		for (float i = 0f; i <= 1f; i+= 0.1f) {
			if (i > 0.9 && !solid){
				i = 1;
				solid = true;
				change = true;
			}
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds(fadeTime);
		}
	}

	IEnumerator FadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
				selfDestroy = true;
			}
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds(fadeTime + 0.3f);
		}
	}
}
