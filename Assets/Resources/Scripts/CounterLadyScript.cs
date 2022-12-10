using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CounterLadyScript : MonoBehaviour {

	GameManager manager;
	Player1Script p1Script;
	
	
	void Start () {
		
		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();
		
	}
	
	void Update () {
		
		if (manager.player1.transform.position.x <= transform.position.x + 2f && manager.player1.transform.position.x > transform.position.x - 3f && manager.player1.transform.position.z <= transform.position.z && manager.player1.transform.position.z >= transform.position.z - 1 && !manager.fight) {
			p1Script.joystick.SetActive (false);
			manager.chat = true;
			manager.screenSrink = true;
			manager.screenEnlarge = false;
			manager.screenShut = false;

			manager.leaveButton.GetComponentInChildren<Text> ().fontSize = 14;

			manager.patrickAppear = true;
			
			manager.panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			
			if (manager.player1.transform.position.x > transform.position.x){
				manager.player1.transform.position = new Vector3 ( transform.position.x - 3f, manager.player1.transform.position.y, manager.player1.transform.position.z);
				if (p1Script.transform.localScale.x == -1){
					p1Script.transform.localScale = new Vector3 (1, 1,1);
				}
			}
			if (manager.player1.transform.position.x < transform.position.x){
				manager.player1.transform.position = new Vector3 ( transform.position.x - 3f, manager.player1.transform.position.y, manager.player1.transform.position.z);
				if (p1Script.transform.localScale.x == -1){
					p1Script.transform.localScale = new Vector3 (1, 1,1);
				}
			}
			
			if (!manager.moneyChecked && !manager.registered){
				if (!manager.p1Lost){
					manager.panelText.text = "COUNTER LADY:\n" +
						"Would you like to register for the coming TOURNAMENT?\nThe registration fee is $100";
				}else{
					manager.panelText.text = "COUNTER LADY:\n" +
						"Would you like to register for a REMATCH?\nThe registration fee is $100";
				}
				if (manager.moneyPoint >= 100){
					manager.registerButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, 6);
					manager.leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, 6);
					manager.leaveButton.GetComponentInChildren<Text> ().text = "No Thanks";
				}
				if (manager.moneyPoint < 100){
					manager.leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, 6);
					manager.leaveButton.GetComponentInChildren<Text> ().text = "I don't have enough money";
					manager.leaveButton.GetComponentInChildren<Text> ().fontSize = 10;
				}
				manager.moneyChecked = true;
			}else{
				manager.panelText.text = "COUNTER LADY:\n" +
					"Please follow the RED CARPET to enter the TOURNAMENT.";
				manager.leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, 6);
				manager.leaveButton.GetComponentInChildren<Text> ().text = "OK";
			}
		}

		if (manager.player1.transform.position.x > transform.position.x + 2f && manager.player1.transform.position.x < transform.position.x + 3f && manager.player1.transform.position.z <= transform.position.z && manager.player1.transform.position.z >= transform.position.z - 1) {
			manager.player1.transform.position = new Vector3 ( transform.position.x + 3f, manager.player1.transform.position.y, manager.player1.transform.position.z);
		}
		
	}
}
