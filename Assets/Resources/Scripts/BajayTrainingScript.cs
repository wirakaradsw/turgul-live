﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class BajayTrainingScript : MonoBehaviour, IPointerDownHandler {

	TrainingScript manager;
	P1TrainingScript p1Script;

	public float speed = 0.1f;

	void Start () {

		manager = GameObject.Find("MainController").GetComponent<TrainingScript> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<P1TrainingScript> ();

		transform.position = new Vector3 (0, transform.position.y, transform.position.z);
		
	}
	
	void Update () {

		if (Time.timeScale != 0) {

			if (transform.position.x > 100f) {
				transform.localScale = new Vector3 (0.8f, 0.8f, 1);
				transform.position = new Vector3 (90f, transform.position.y, transform.position.z);
				manager.bajayStop = false;
			}

			if (transform.position.x < -100f) {
				transform.localScale = new Vector3 (-0.8f, 0.8f, 1);
				transform.position = new Vector3 (-90f, transform.position.y, transform.position.z);
				manager.bajayStop = false;
			}

			if (!manager.bajayStop && manager.player1.transform.position.z == -2 &&
				transform.position.x < manager.player1.transform.position.x + 2f &&
				transform.position.x > manager.player1.transform.position.x - 2f) {

				manager.bajayStop = true;
			}

			if (manager.bajayStop) {
				p1Script.joystick.SetActive (false);
				manager.chat = true;
				manager.screenSrink = true;
				manager.screenEnlarge = false;
				manager.screenShut = false;
			
				manager.panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				manager.panelText.text = "BAJURI:\n\n" +
					"Any place you wanna go?\nJust hop in and I'll drive you there.";
			
				if ((!manager.success && manager.moneyPoint >= 30) || (manager.success && manager.moneyPoint >= 20)) {
					manager.leaveButton.GetComponentInChildren<Text> ().text = "No thanks";
					manager.leaveButton.GetComponentInChildren<Text> ().fontSize = 14;
					manager.leaveButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
					manager.backButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (-140, 6);
				} else if ((!manager.success && manager.moneyPoint < 30) || (manager.success && manager.moneyPoint < 20)) {
					manager.leaveButton.GetComponentInChildren<Text> ().text = "I don't have enough money";
					manager.leaveButton.GetComponentInChildren<Text> ().fontSize = 10;
					manager.leaveButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
				}

				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			} else {

				if (transform.localScale.x == 0.8f) {
					transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
				}

				if (transform.localScale.x == -0.8f) {
					transform.position = new Vector3 (transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
				}
			}

		}
		
	}

    public void OnMouseDown()
    {
        if (!manager.fight)
        {
            manager.player1.transform.position = new Vector3(manager.player1.transform.position.x, manager.player1.transform.position.y, -2f);
            transform.position = new Vector3(manager.player1.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnMouseDown();
    }

}
