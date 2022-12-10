using UnityEngine;
using System.Collections;

public class StarBlinking : MonoBehaviour {

	int starRan = 0;
	int starBlinkTime = 0;
	int starBlinkTimeMax = 100;

	public Animator starAnim;
	
	void Start () {

		starBlinkTime = starBlinkTimeMax;
	
	}

	void Update () {

		starBlinkTime --;

		if (starBlinkTime == 60) {
			starAnim.SetInteger ("StarBlink", 0);
		}

		if (starBlinkTime == 0) {
			starRan = Random.Range (0, 5);
			if (starRan == 3){
				starAnim.SetInteger ("StarBlink", 1);
			}
			starBlinkTime = starBlinkTimeMax;
		}

	}
}
