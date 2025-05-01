using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PatrickScript : MonoBehaviour, IPointerDownHandler {

	GameManager manager;
	Player1Script p1Script;

	GameObject player1;
	GameObject superScene;

	float p2SAttInitiationTimer = 40;
	float p2SAttInitiationTimerMax = 40;
	int p2SAttAction = 0;
	float p2SAttackTimer = 100;
	float p2SAttackTimerMax = 100;
	float p2SAttack3Timer = 40;
	float p2SAttack3TimerMax = 40;

	int p2DefAction = 0;
	float comStandUpTimer = 40;
	float comStandUpTimerMax = 40;
	float comWalkTimer = 40;
	float comWalkTimerMax = 40;

	float p2BowEndTimer = 80;
	float p2BowEndTimerMax = 80;

	float defPoint = 20f;
	float attPoint = 8f;
	float sAtt1Damage = 40f;
	float sAtt2Damage = 80f;
	float sAtt3Damage = 120f;

	bool p2SAttack1 = false;
	bool p2SAttack2 = false;
	bool p2SAttack3 = false;
	bool p2SAttackStart = false;
	bool p2SAttack3Start = false;
    bool isSuperBlow = false;

	bool comBlock = false;
	bool comDodge = false;
	bool p2MoveBack = false;
	bool comStandUpStart = false;
	bool comWalkStart = false;

	public bool hitTextFollowPatrick = false;

	bool p2BowEnd = false;

	Animator anim;
	Animator patrickAnim;

	public float P2SAttack3Timer {
		
		get {
			return p2SAttack3Timer;
		}
		set {
			p2SAttack3Timer = value;
            isSuperBlow = false;
		}
	}
	
	public float P2SAttack3TimerMax {
		
		get {
			return p2SAttack3TimerMax;
		}
		set {
			p2SAttack3TimerMax = value;
		}
	}

	public bool P2SAttack3Start {
		
		get {
			return p2SAttack3Start;
		}
		set {
			p2SAttack3Start = value;
		}
	}

	public bool P2SAttack1 {
		
		get {
			return p2SAttack1;
		}
		set {
			p2SAttack1 = value;
		}
	}

	public bool P2SAttack2 {
		
		get {
			return p2SAttack2;
		}
		set {
			p2SAttack2 = value;
		}
	}

	public bool P2SAttack3 {
		
		get {
			return p2SAttack3;
		}
		set {
			p2SAttack3 = value;
		}
	}

	void Start () {
	
		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();

		//transform.position = new Vector3 (-15, 0, -10);

	}

	void Update () {

		player1 = manager.player1;
		superScene = manager.superScene;
		anim = manager.anim;
		patrickAnim = manager.patrickAnim;

		if (Time.timeScale != 0) {
			if (player1.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (1, 1, 1);
			}
		
			if (player1.transform.position.x < transform.position.x) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}
		
			if (player1.transform.position.x < transform.position.x + 3f && player1.transform.position.x > transform.position.x - 3f && player1.transform.position.z == transform.position.z && !manager.fight) {
                ChatOn();
			}

            if (manager.TargetVisible(manager.mainCam, gameObject))
            {
                manager.cloudButton[3].SetActive(false);
            }
            else
            {
                if (transform.position.z == 2f)
                    manager.cloudButton[3].SetActive(true);
            }

            // --- Patrick initiates Super Attacks ---
            if (manager.p2Att1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 32f && manager.fighting) { 

				p2SAttInitiationTimer -= Time.deltaTime * 100f;

			}

			if (p2SAttInitiationTimer <= 0) {
				p2SAttAction = Random.Range (1, 11);
				p2SAttInitiationTimer = p2SAttInitiationTimerMax;
			}

			if (p2SAttAction == 7) {
				manager.fightSound.Play ();
				manager.fighting = false;
				p2SAttack1 = true;
				StartCoroutine ("SuperSceneFadeIn");
				manager.p2AttBar.rectTransform.sizeDelta = new Vector2 (manager.p2AttBar.GetComponent<RectTransform> ().rect.width - 100f, manager.p2AttBar.GetComponent<RectTransform> ().rect.height);
				manager.Initial ();

				manager.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				manager.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);

				if (manager.p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && manager.p1DefBar.GetComponent<RectTransform> ().rect.width < 200) {
					manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				}
			
				if (manager.p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
					manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				}

				p2SAttAction = 0;
			}

			if (p2SAttAction == 3 || p2SAttAction == 6) {
				if (manager.p2Att2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 32f) {
					manager.fightSound.Play ();
					manager.fighting = false;
					p2SAttack2 = true;
					StartCoroutine ("SuperSceneFadeIn");
					manager.p2AttBar.rectTransform.sizeDelta = new Vector2 (manager.p2AttBar.GetComponent<RectTransform> ().rect.width - 200f, manager.p2AttBar.GetComponent<RectTransform> ().rect.height);
					manager.Initial ();
				
					manager.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
					manager.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);

					if (manager.p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && manager.p1DefBar.GetComponent<RectTransform> ().rect.width < 200) {
						manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}
				
					if (manager.p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
						manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
						manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}

					p2SAttAction = 0;
				}
			}

			if (p2SAttAction == 1 || p2SAttAction == 2 || p2SAttAction == 4 || p2SAttAction == 5) {
				if (manager.p2Att3Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 32f) {
					manager.fightSound.Play ();
					manager.fighting = false;
					p2SAttack3 = true;
					StartCoroutine ("SuperSceneFadeIn");
					manager.p2AttBar.rectTransform.sizeDelta = new Vector2 (manager.p2AttBar.GetComponent<RectTransform> ().rect.width - 300f, manager.p2AttBar.GetComponent<RectTransform> ().rect.height);
					manager.Initial ();
				
					manager.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
					manager.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);

					if (manager.p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && manager.p1DefBar.GetComponent<RectTransform> ().rect.width < 200) {
						manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}
				
					if (manager.p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
						manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
						manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}

					p2SAttAction = 0;
				}
			}


			if (superScene.GetComponent<SpriteRenderer> ().color.a > 0.1f && superScene.GetComponent<SpriteRenderer> ().color.a <= 0.8f) { // --- Super Scene
				if (p1Script.SAttack1 || p1Script.SAttack2 || p1Script.SAttack3) {
					anim.SetInteger ("FightMove", 17);
				}
				if (p2SAttack1 || p2SAttack2 || p2SAttack3) {
					patrickAnim.SetInteger ("PatrickFightMove", 17);
				}
			}

			// --- p2 Super Attacks
			if (patrickAnim.GetInteger ("PatrickFightMove") == 17) {
				transform.position = new Vector3 (transform.position.x + ((4f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 17 && transform.position.x > 3.9f) {
				patrickAnim.SetInteger ("PatrickFightMove", 2);
				transform.position = new Vector3 (4f, transform.position.y, transform.position.z);
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 2) {
				if (p2SAttack1 || p2SAttack2 || p2SAttack3) {
					p2SAttackStart = true;
				}
			}
		
			if (p2SAttackStart) {
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				p2SAttackTimer -= Time.deltaTime * 100f;
			}

			if (p2SAttackTimer <= 5f && p2SAttackTimer > 4f) {
				anim.SetInteger ("FightMove", 2);
				manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				manager.p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				manager.p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
			}
		
			if (p2SAttackTimer <= 0) {
				p2SAttackStart = false;
				if (p2SAttack1) {
					patrickAnim.SetInteger ("PatrickFightMove", 10);
					manager.pukulanVoice.Play ();
				}
				if (p2SAttack2) {
					patrickAnim.SetInteger ("PatrickFightMove", 11);
					manager.awurawuranVoice.Play ();
				}
				if (p2SAttack3) {
					patrickAnim.SetInteger ("PatrickFightMove", 12);
					p2SAttack3Start = true;
					manager.sapuJagatVoice.Play ();
				}
				p2SAttackTimer = p2SAttackTimerMax;
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 10 || patrickAnim.GetInteger ("PatrickFightMove") == 11) {
				transform.position = new Vector3 (transform.position.x + ((-0.6f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}

			if (p2SAttack3Start) {
				p2SAttack3Timer -= Time.deltaTime * 100f;
			}

			if (p2SAttack3Timer < 5f && !isSuperBlow) {
                isSuperBlow = true;
				Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x - 3f, -0.2f, transform.position.z), Quaternion.identity);
				manager.swipSound.Play ();
			}

			// --- Patrick Deffend Actions ---
			if (p1Script.SAttackTimer < p1Script.SAttackTimerMax * 0.5f && p1Script.SAttackTimer > ((p1Script.SAttackTimerMax * 0.5f)-1f) ) { 
				if (manager.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == -72f && manager.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 50f) {
					p2DefAction = Random.Range (1, 5);
					if (p2DefAction == 1 || p2DefAction == 3 || (manager.p2HBar.GetComponent<RectTransform> ().rect.width <= 80)) {
						manager.fightSound.Play ();
						comBlock = true;
						comDodge = false;
						manager.p2DefBar.rectTransform.sizeDelta = new Vector2 (manager.p2DefBar.GetComponent<RectTransform> ().rect.width - 100f, manager.p2DefBar.GetComponent<RectTransform> ().rect.height);
						manager.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
					}
				}
				//if (manager.p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition.y == -72f && manager.p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition.y == -72f){
				if (manager.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == -72f) {
					p2DefAction = Random.Range (1, 5);
					if (p2DefAction == 4 || (manager.p2HBar.GetComponent<RectTransform> ().rect.width <= 80)) {
						manager.fightSound.Play ();
						comBlock = false;
						comDodge = true;
						manager.p2DefBar.rectTransform.sizeDelta = new Vector2 (manager.p2DefBar.GetComponent<RectTransform> ().rect.width - 200f, manager.p2DefBar.GetComponent<RectTransform> ().rect.height);
						manager.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
					} else if (p2DefAction == 1 || p2DefAction == 3) {
						if (manager.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == -72f) {
							comBlock = true;
							comDodge = false;
							manager.p2DefBar.rectTransform.sizeDelta = new Vector2 (manager.p2DefBar.GetComponent<RectTransform> ().rect.width - 100f, manager.p2DefBar.GetComponent<RectTransform> ().rect.height);
							manager.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
						}
					}
				}
			}
		
			if (p1Script.SAttackTimer <= 5f && p1Script.SAttackTimer > 4f) {
				patrickAnim.SetInteger ("PatrickFightMove", 2);
				manager.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				manager.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (manager.p2Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
			}

			if (anim.GetInteger ("FightMove") == 10 && player1.transform.position.x > -3f && player1.transform.position.x < -2f) {
				if (comBlock) {
					patrickAnim.SetInteger ("PatrickFightMove", 5); // --- Patrick blocks
					manager.hitSound.Play ();
					manager.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p2HBar.rectTransform.sizeDelta = new Vector2 (manager.p2HBar.GetComponent<RectTransform> ().rect.width - (sAtt1Damage / 2), manager.p2HBar.GetComponent<RectTransform> ().rect.height);
					sAtt1Damage = sAtt1Damage / 2;
					manager.hitText.text = "-" + sAtt1Damage.ToString ();
					hitTextFollowPatrick = true;
					sAtt1Damage = sAtt1Damage * 2;
					comBlock = false;
				} else if (comDodge) {
					patrickAnim.SetInteger ("PatrickFightMove", 4); // --- Patrick dodges
					manager.jumpSound.Play ();
					manager.hitText.text = "Miss";
					hitTextFollowPatrick = true;
					comDodge = false;
				} else {
					patrickAnim.SetInteger ("PatrickFightMove", 13); // --- Patrick got hit
					manager.hitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p2HBar.rectTransform.sizeDelta = new Vector2 (manager.p2HBar.GetComponent<RectTransform> ().rect.width - sAtt1Damage, manager.p2HBar.GetComponent<RectTransform> ().rect.height);
					manager.hitText.text = "-" + sAtt1Damage.ToString ();
					hitTextFollowPatrick = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (anim.GetInteger ("FightMove") == 11 && player1.transform.position.x > -3f && player1.transform.position.x < -2f) {
				if (comBlock) {
					patrickAnim.SetInteger ("PatrickFightMove", 5); // --- Patrick blocks
					manager.hitSound.Play ();
					manager.manyHitSound.Play ();
					manager.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p2HBar.rectTransform.sizeDelta = new Vector2 (manager.p2HBar.GetComponent<RectTransform> ().rect.width - (sAtt2Damage / 2), manager.p2HBar.GetComponent<RectTransform> ().rect.height);
					sAtt2Damage = sAtt2Damage / 2;
					manager.hitText.text = "-" + sAtt2Damage.ToString ();
					hitTextFollowPatrick = true;
					sAtt2Damage = sAtt2Damage * 2;
					comBlock = false;
				} else if (comDodge) {
					patrickAnim.SetInteger ("PatrickFightMove", 4); // --- Patrick dodges
					manager.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					manager.hitText.text = "Miss";
					hitTextFollowPatrick = true;
					comDodge = false;
				} else {
					patrickAnim.SetInteger ("PatrickFightMove", 13); // --- Patrick got hit
					manager.hitSound.Play ();
					manager.manyHitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p2HBar.rectTransform.sizeDelta = new Vector2 (manager.p2HBar.GetComponent<RectTransform> ().rect.width - sAtt2Damage, manager.p2HBar.GetComponent<RectTransform> ().rect.height);
					manager.hitText.text = "-" + sAtt2Damage.ToString ();
					hitTextFollowPatrick = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}

			if (p1Script.SAttack3Timer <= 0) {
				p1Script.SAttack3Start = false;
				if (comBlock) {
					patrickAnim.SetInteger ("PatrickFightMove", 5); // --- Patrick blocks
					manager.hitSound.Play ();
					manager.criticalSound.Play ();
					manager.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p2HBar.rectTransform.sizeDelta = new Vector2 (manager.p2HBar.GetComponent<RectTransform> ().rect.width - (sAtt3Damage / 2), manager.p2HBar.GetComponent<RectTransform> ().rect.height);
					sAtt3Damage = sAtt3Damage / 2;
					manager.hitText.text = "-" + sAtt3Damage.ToString ();
					hitTextFollowPatrick = true;
					sAtt3Damage = sAtt3Damage * 2;
					comBlock = false;
				} else if (comDodge) {
					patrickAnim.SetInteger ("PatrickFightMove", 4); // --- Patrick dodges
					manager.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					manager.hitText.text = "Miss";
					hitTextFollowPatrick = true;
					comDodge = false;
				} else {
					patrickAnim.SetInteger ("PatrickFightMove", 13); // --- Patrick got hit
					manager.hitSound.Play ();
					manager.criticalSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p2HBar.rectTransform.sizeDelta = new Vector2 (manager.p2HBar.GetComponent<RectTransform> ().rect.width - sAtt3Damage, manager.p2HBar.GetComponent<RectTransform> ().rect.height);
					manager.hitText.text = "-" + sAtt3Damage.ToString ();
					hitTextFollowPatrick = true;
				}
				StartCoroutine ("HitTextFadeOut");
				p2MoveBack = true;
				p1Script.SAttack3Timer = p1Script.SAttack3TimerMax;
			}

			if (hitTextFollowPatrick) {
				p1Script.hitTextFollowP1 = false;
				manager.hitText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (transform.position.x * 40, 100);
				//manager.hitText.transform.position = new Vector2 (transform.position.x, transform.position.y + 2f);
			}

			// --- Patrick moves back ---
			if (player1.transform.position.x > 0f && player1.transform.position.x < 0.7f) {
				if (anim.GetInteger ("FightMove") == 10 || anim.GetInteger ("FightMove") == 11) {
					transform.position = new Vector3 (transform.position.x + ((5f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
				}
			}
		
			if (p2MoveBack) {
				transform.position = new Vector3 (transform.position.x + ((5f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 4 && transform.position.x > 4.9f) { // --- Patrick is dodging
				comStandUpStart = true;
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				p2MoveBack = false;
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 5 && transform.position.x > 4.9f) { // --- Patrick is blocking
				if (manager.p2HBar.GetComponent<RectTransform> ().rect.width > 0) {
					comStandUpStart = true;
				} else {
					patrickAnim.SetInteger ("PatrickFightMove", 14);
				}
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				p2MoveBack = false;
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 13 && transform.position.x > 4.9f) { // --- Patrick got hit
				patrickAnim.SetInteger ("PatrickFightMove", 14);
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				p2MoveBack = false;
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 14 && manager.p2HBar.GetComponent<RectTransform> ().rect.width > 0) {
				comStandUpStart = true;
			}
		
			if (comStandUpStart) {
				comStandUpTimer -= Time.deltaTime * 100f;
			}
		
			if (comStandUpTimer <= 0) {
				comStandUpStart = false;
				patrickAnim.SetInteger ("PatrickFightMove", 15); //--- Stand up
				if (p1Script.SAttack3) {
					anim.SetInteger ("FightMove", 2);
				} else {
					anim.SetInteger ("FightMove", 17);
				}
				p1Script.SAttack1 = false;
				p1Script.SAttack2 = false;
				p1Script.SAttack3 = false;
				comStandUpTimer = comStandUpTimerMax;
				comWalkStart = true;
			}
		
			if (comWalkStart) {
				comWalkTimer -= Time.deltaTime * 100f;
			}
		
			if (comWalkTimer <= 0) {
				comWalkStart = false;
				patrickAnim.SetInteger ("PatrickFightMove", 16);
				comWalkTimer = comWalkTimerMax;
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 16) {
				transform.position = new Vector3 (transform.position.x + ((4f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 16 && transform.position.x < 4.1f) {
				patrickAnim.SetInteger ("PatrickFightMove", 2);
				transform.position = new Vector3 (4f, transform.position.y, transform.position.z);
				manager.fightStart = true;
			}

			// --- Patrick wins ---
			if (anim.GetInteger ("FightMove") == 14 && manager.p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				if (p2SAttack1 || p2SAttack2 || p2SAttack3) {
					manager.strollingStart = true;
					if (p2SAttack3) {
						patrickAnim.SetInteger ("PatrickFightMove", 2);
					} else {
						patrickAnim.SetInteger ("PatrickFightMove", 17);
					}
					p2SAttack1 = false;
					p2SAttack2 = false;
					p2SAttack3 = false;
				}
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 2 && transform.position.x == 4f && manager.p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				p2BowEnd = true;
			}
		
			if (p2BowEnd) {
				p2BowEndTimer -= Time.deltaTime * 100f;
			}
		
			if (p2BowEndTimer <= 0) {
				p2BowEnd = false;
				patrickAnim.SetInteger ("PatrickFightMove", 1);

				manager.moneyDynamicPoint = 15;
				manager.moneyPoint += manager.moneyDynamicPoint;

				p2BowEndTimer = p2BowEndTimerMax;
			}

		}

	}

	IEnumerator SuperSceneFadeIn(){
		for (float i = 0f; i <= 1f; i+= 0.1f) {
			superScene.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds(0.05f);
			//yield return null;
		}
	}

	IEnumerator HitTextFadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
			}
			manager.hitText.color = new Color (0.5f, 0, 0, i);
			yield return new WaitForSeconds(0.1f);
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

        if (player1.transform.position.x > transform.position.x)
        {
            player1.transform.position = new Vector3(transform.position.x + 3f, player1.transform.position.y, transform.position.z);
            if (p1Script.transform.localScale.x == 1)
            {
                p1Script.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (player1.transform.position.x < transform.position.x)
        {
            player1.transform.position = new Vector3(transform.position.x - 3f, player1.transform.position.y, transform.position.z);
            if (p1Script.transform.localScale.x == -1)
            {
                p1Script.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (manager.p1HBar.GetComponent<RectTransform>().rect.width < 300 && !manager.moneyChecked)
        {
            manager.panelText.text = "PATRICK:\n" +
                "Aw Bro!\nYou don't look well...\nGet something to eat Bro...";
            if (manager.moneyPoint < 15)
            {
                manager.moneyDynamicPoint = 15 - manager.moneyPoint;
                manager.moneyPoint = manager.moneyPoint + manager.moneyDynamicPoint;
                manager.moneyAppearPlus = true;
                manager.gotSomethingSound.Play();
            }
            manager.moneyChecked = true;
        }
        else
        {
            manager.panelText.text = "PATRICK:\n" +
                "Yo Bro!\nCare to have a sparring match with me?\nIf you WIN, I'll make sure you can enter the TOURNAMENT.\nWell if you LOSE, don't worry, I'll buy you SATAY...";
            manager.fightButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(-140, 6);
            manager.fightButton.GetComponentInChildren<Text>().text = "OK";
            manager.leaveButton.GetComponentInChildren<Text>().text = "No Thanks";
        }
    }

    public void OnMouseDown()
    {
        //Debug.Log("Ron clicked");
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
