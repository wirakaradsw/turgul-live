using UnityEngine;
using System.Collections;

public class SaveValues : MonoBehaviour {

	public int moneyPoint;

	// Use this for initialization
	void Start () {
	
		moneyPoint = PlayerPrefs.GetInt ("moneyPoint");

	}
	
	// Update is called once per frame
	void Update () {

		PlayerPrefs.SetInt ("moneyPoint", moneyPoint);

	}
}
