using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BouncerScript : MonoBehaviour {

	GameManager manager;
	Player1Script p1Script;
	
	
	void Start () {
		
		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();
		
	}
	
	void Update () {
		
		if (manager.player1.transform.position.x < transform.position.x + 3f && manager.player1.transform.position.x > transform.position.x - 3f && manager.player1.transform.position.z == transform.position.z && !manager.fight) {
			p1Script.joystick.SetActive (false);
			manager.chat = true;
			manager.screenSrink = true;
			manager.screenEnlarge = false;
			manager.screenShut = false;

			manager.leaveButton.GetComponentInChildren<Text> ().text = "Leave";
			manager.leaveButton.GetComponentInChildren<Text> ().fontSize = 14;
			
			manager.panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);

			manager.player1.transform.position = new Vector3 ( transform.position.x - 3f, manager.player1.transform.position.y, manager.player1.transform.position.z);
			if (p1Script.transform.localScale.x == -1){
				p1Script.transform.localScale = new Vector3 (1, 1,1);
			}
			
			if (manager.registered){
				if (manager.p1HBar.GetComponent<RectTransform> ().rect.width >= 300){
					manager.panelText.text = "BOUNCER:\n" +
						"You may ENTER the TOURNAMENT.";
					manager.enterButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, 6);
					manager.leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, 6);
				}
				if (manager.p1HBar.GetComponent<RectTransform> ().rect.width < 300){
					manager.panelText.text = "BOUNCER:\n" +
						"You are not in a good condition to fight.\nYou need to restore your health first.";
					manager.leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, 6);
				}
			}else{
				manager.panelText.text = "BOUNCER:\n" +
					"STOP!\nYou have to REGISTER your self first at the COUNTER to ENTER the TOURNAMENT.";
				manager.leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, 6);
			}
		}
		
	}
}
