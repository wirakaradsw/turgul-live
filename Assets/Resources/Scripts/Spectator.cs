using UnityEngine;
using System.Collections;

public class Spectator : MonoBehaviour {

	int specRan = 0;
	int specTime = 20;
	int specTimeMax = 120;
	
	Animator specAnim;
	
	void Start () {
		
		//specTime = specTimeMax;
		specAnim = GetComponent<Animator> ();
		
	}
	
	void Update () {
		
		specTime --;
		
		/*if (specTime == 60) {
			specAnim.SetInteger ("SpecMove", 0);
		}*/
		
		if (specTime == 0) {
			specRan = Random.Range (0, 7);
			if (specRan == 0){
				specAnim.SetInteger ("SpecMove", 0);
			}
			if (specRan == 1){
				specAnim.SetInteger ("SpecMove", 1);
			}
			if (specRan == 2){
				specAnim.SetInteger ("SpecMove", 2);
			}
			if (specRan == 3){
				specAnim.SetInteger ("SpecMove", 3);
			}
			if (specRan == 4){
				specAnim.SetInteger ("SpecMove", 4);
			}
			if (specRan == 5){
				specAnim.SetInteger ("SpecMove", 0);
			}
			if (specRan == 6){
				specAnim.SetInteger ("SpecMove", 0);
			}
			specTime = specTimeMax;
		}
		
	}
}
