using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

	GameManager manager;
	Player1Script p1Script;
	PatrickScript patrickScript;

	void Awake(){

		//transform.position = new Vector2 (transform.position.x - (Screen.width - 1920), transform.position.y - (Screen.height - 1080));

	}

	void Start () {

		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();
		patrickScript = GameObject.Find ("Patrick").GetComponent<PatrickScript> ();

	}

	void Update () {

		Image p1HBarFrame = manager.p1HBarFrame;
		Image p2HBarFrame = manager.p2HBarFrame;
		Image p1HBar = manager.p1HBar;
		Image p2HBar = manager.p2HBar;
		Image p1AttBarFrame = manager.p1AttBarFrame;
		Image p2AttBarFrame = manager.p2AttBarFrame;
		Image p1AttBar = manager.p1AttBar;
		Image p2AttBar = manager.p2AttBar;
		Image p1DefBarFrame = manager.p1DefBarFrame;
		Image p2DefBarFrame = manager.p2DefBarFrame;
		Image p1DefBar = manager.p1DefBar;
		Image p2DefBar = manager.p2DefBar;
		Image p1Att1Inactive = manager.p1Att1Inactive;
		Image p1Att2Inactive = manager.p1Att2Inactive;
		Image p1Att3Inactive = manager.p1Att3Inactive;
		Image p1Def1Inactive = manager.p1Def1Inactive;
		Image p1Def2Inactive = manager.p1Def2Inactive;
		Image p2Att1Active = manager.p2Att1Active;
		Image p2Att2Active = manager.p2Att2Active;
		Image p2Att3Active = manager.p2Att3Active;
		Image p2Att1Inactive = manager.p2Att1Inactive;
		Image p2Att2Inactive = manager.p2Att2Inactive;
		Image p2Att3Inactive = manager.p2Att3Inactive;
		Image p2Def1Active = manager.p2Def1Active;
		Image p2Def2Active = manager.p2Def2Active;
		Image p2Def1Inactive = manager.p2Def1Inactive;
		Image p2Def2Inactive = manager.p2Def2Inactive;
		
		Button fightButton = manager.fightButton;
		Button leaveButton = manager.leaveButton;
		Button att1Button = manager.att1Button;
		Button att2Button = manager.att2Button;
		Button att3Button = manager.att3Button;
		Button def1Button = manager.def1Button;
		Button def2Button = manager.def2Button;

		bool fighting = manager.fighting;
	
		if (p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {
			p1HBar.rectTransform.sizeDelta = new Vector2 (0, p1HBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p2HBar.GetComponent<RectTransform> ().rect.width <= 0) {
			p2HBar.rectTransform.sizeDelta = new Vector2 (0, p2HBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p1AttBar.GetComponent<RectTransform> ().rect.width >= 300) {
			p1AttBar.rectTransform.sizeDelta = new Vector2 (300, p1AttBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p2AttBar.GetComponent<RectTransform> ().rect.width >= 300) {
			p2AttBar.rectTransform.sizeDelta = new Vector2 (300, p2AttBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
			p1DefBar.rectTransform.sizeDelta = new Vector2 (200, p1DefBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
			p2DefBar.rectTransform.sizeDelta = new Vector2 (200, p2DefBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p1DefBar.GetComponent<RectTransform> ().rect.width <= 0) {
			p1DefBar.rectTransform.sizeDelta = new Vector2 (0, p1DefBar.GetComponent<RectTransform> ().rect.height);
		}
		if (p2DefBar.GetComponent<RectTransform> ().rect.width <= 0) {
			p2DefBar.rectTransform.sizeDelta = new Vector2 (0, p2DefBar.GetComponent<RectTransform> ().rect.height);
		}

		if (p1AttBar.GetComponent<RectTransform> ().rect.width < 100 && fighting) {
			att1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			att2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			att3Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att3Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		}
		
		if (p1AttBar.GetComponent<RectTransform> ().rect.width >= 100 && p1AttBar.GetComponent<RectTransform> ().rect.width < 200 && fighting) {
			if (manager.tutorialStep == 6) {
				manager.pointerHand[6].SetActive(true);
			}
			att1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			att2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			att3Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att3Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		}
		
		if (p1AttBar.GetComponent<RectTransform> ().rect.width >= 200 && p1AttBar.GetComponent<RectTransform> ().rect.width < 300 && fighting) {
			att1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			att2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			att3Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att3Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		}
		
		if (p1AttBar.GetComponent<RectTransform> ().rect.width >= 300 && fighting) {
			att1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			att2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			att3Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att3Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		}
		
		if (p1DefBar.GetComponent<RectTransform> ().rect.width < 100 && fighting) {
            if (manager.tutorialStep == 7){
                manager.pointerHand[7].SetActive(false);
            }
            def1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			def2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
		}
		
		if (p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && p1DefBar.GetComponent<RectTransform> ().rect.width < 200 && fighting) {
			if (!patrickScript.P2SAttack3){
				def1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			}
			def2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
		}
		
		if (p1DefBar.GetComponent<RectTransform> ().rect.width >= 200 && fighting) {
			if (!patrickScript.P2SAttack3){
				def1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			}
			def2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		}
		
		if (p2AttBar.GetComponent<RectTransform> ().rect.width < 100 && fighting) {
			p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		}
		
		if (p2AttBar.GetComponent<RectTransform> ().rect.width >= 100 && p2AttBar.GetComponent<RectTransform> ().rect.width < 200 && fighting) {
			p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		}
		
		if (p2AttBar.GetComponent<RectTransform> ().rect.width >= 200 && p2AttBar.GetComponent<RectTransform> ().rect.width < 300 && fighting) {
			p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		}
		
		if (p2AttBar.GetComponent<RectTransform> ().rect.width >= 300 && fighting) {
			p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
			p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
			p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		}
		
		if (p2DefBar.GetComponent<RectTransform> ().rect.width < 100 && fighting) {
			p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
		}
		
		if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 100 && p2DefBar.GetComponent<RectTransform> ().rect.width < 200 && fighting) {
			if (!p1Script.SAttack3){
				p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			}
			p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
		}
		
		if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 200 && fighting) {
			if (!p1Script.SAttack3){
				p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			}
			p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
			p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
			p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		}

		if (p1Script.SAttack3){
			p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		}

		if (patrickScript.P2SAttack3){
            if (manager.tutorialStep == 7){
                manager.pointerHand[7].SetActive(false);
            }
            def1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		}

	}
}
