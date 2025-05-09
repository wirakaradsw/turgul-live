﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CakKumisScript : MonoBehaviour, IPointerDownHandler {
	
	GameManager manager;
	Player1Script p1Script;


	void Start () {
	
		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();

	}

	void Update () {
	
		if (manager.player1.transform.position.x < transform.position.x + 3f && manager.player1.transform.position.x > transform.position.x - 3f && manager.player1.transform.position.z == transform.position.z && !manager.fight && !manager.chatKumis) {
            ChatOn ();
		}

        if (manager.TargetVisible(manager.mainCam, gameObject))
        {
            manager.cloudButton[0].SetActive(false);
            manager.cloudButton[8].SetActive(false);
        }
        else
        {
            if (!manager.fight)
            {
                if (manager.player1.transform.position.x < 0)
                {
                    manager.cloudButton[0].SetActive(true);
                    manager.cloudButton[8].SetActive(false);
                }
                else
                {
                    manager.cloudButton[0].SetActive(false);
                    manager.cloudButton[8].SetActive(true);
                }                   
            }
            else
            {
                manager.cloudButton[0].SetActive(false);
                manager.cloudButton[8].SetActive(false);
            }               
        }

    }

    void ChatOn ()
    {
        p1Script.joystick.SetActive(false);
        manager.ChatOn();
        manager.screenSrink = true;
        manager.screenEnlarge = false;
        manager.screenShut = false;

        if (manager.tutorialStep == 0)
        {
            manager.pointerHand[0].SetActive (false);
            manager.AddTutorialStep();
        }

        manager.panelText.text = "CHAK KUMIS:\n" +
            "Tay... SATAY...!!!\nTen sticks just for $15";

        manager.leaveButton.GetComponentInChildren<Text>().fontSize = 14;

        if (manager.player1.transform.position.x > transform.position.x)
        {
            manager.player1.transform.position = new Vector3(transform.position.x + 3f, manager.player1.transform.position.y, transform.position.z);
            if (p1Script.transform.localScale.x == 1)
            {
                p1Script.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (manager.player1.transform.position.x < transform.position.x)
        {
            manager.player1.transform.position = new Vector3(transform.position.x - 3f, manager.player1.transform.position.y, transform.position.z);
            transform.localScale = new Vector3(-1, 1, 1);
            if (p1Script.transform.localScale.x == -1)
            {
                p1Script.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (manager.p1HBar.GetComponent<RectTransform>().rect.width < 300 && !manager.moneyChecked)
        {
            if (manager.moneyPoint >= 15)
            {
                manager.satayButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(-140, 6);
                manager.leaveButton.GetComponentInChildren<Text>().text = "No Thanks";
            }
            if (manager.moneyPoint < 15)
            {
                manager.leaveButton.GetComponentInChildren<Text>().text = "I don't have enough money";
                manager.leaveButton.GetComponentInChildren<Text>().fontSize = 10;
            }
            manager.moneyChecked = true;
        }
        else
        {
            manager.leaveButton.GetComponentInChildren<Text>().text = "No Thanks";
        }
    }

    public void OnMouseDown()
    {
        if (!manager.fight)
        {
            ChatOn();
        }   
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnMouseDown();
    }

}
