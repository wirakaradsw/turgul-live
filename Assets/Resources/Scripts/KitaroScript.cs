using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class KitaroScript : MonoBehaviour, IPointerDownHandler {

	GameManager manager;
	Player1Script p1Script;
	
	
	void Start () {
		
		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();
		
	}
	
	void Update () {
		
		if (manager.player1.transform.position.x < transform.position.x + 3f && manager.player1.transform.position.x > transform.position.x - 3f && manager.player1.transform.position.z == transform.position.z && !manager.fight) {

            ChatOn();
		}

        if (manager.TargetVisible(manager.mainCam, gameObject))
        {
            manager.cloudButton[5].SetActive(false);
        }
        else
        {
            if (transform.position.z == 2f && !manager.fight)
                manager.cloudButton[5].SetActive(true);
        }

    }

    void ChatOn()
    {
        p1Script.joystick.SetActive(false);
        manager.ChatOn();
        manager.screenSrink = true;
        manager.screenEnlarge = false;
        manager.screenShut = false;

        manager.leaveButton.GetComponentInChildren<Text>().text = "Leave";
        manager.leaveButton.GetComponentInChildren<Text>().fontSize = 14;

        manager.player1.transform.position = new Vector3(transform.position.x + 3f, manager.player1.transform.position.y, transform.position.z);
        manager.mainCam.transform.position = new Vector3(-18f, manager.mainCam.transform.position.y, manager.mainCam.transform.position.z);
        if (p1Script.transform.localScale.x == 1)
        {
            p1Script.transform.localScale = new Vector3(-1, 1, 1);
        }

        manager.panelText.text = "KITARO:\n\n" +
            "I am a REAL SUPER HERO who doesn't need to hide his TRUE IDENTITY.";
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
