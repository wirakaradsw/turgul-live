using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1Script : MonoBehaviour {

	GameManager manager;
	PatrickScript patrickScript;
	ETCJoystick etcJoystick;

	public GameObject joystick;

	public GameObject bajay;

	GameObject patrick;
	GameObject superScene;

	float sAttackTimer = 100;
	float sAttackTimerMax = 100;
	float sAttack3Timer = 40;
	float sAttack3TimerMax = 40;

	float p1StandUpTimer = 40;
	float p1StandUpTimerMax = 40;
	float p1WalkTimer = 40;
	float p1WalkTimerMax = 40;

	float p1BowEndTimer = 80;
	float p1BowEndTimerMax = 80;

	float p1Z = 0f;
	float maxSpeed = 0.08f;

	float defPoint = 20f;
	float attPoint = 8f;
	float sAtt1Damage = 40f;
	float sAtt2Damage = 80f;
	float sAtt3Damage = 120f;

	bool joystickActive = false;

	//bool facingRight = true;
	bool fight;
	bool chat;

	bool p1MoveUpZ = false;
	bool p1MoveDownZ = false;
	bool p1MoveX = false;

	bool sAttack1 = false;
	bool sAttack2 = false;
	bool sAttack3 = false;
	bool sAttackStart = false;
	bool sAttack3Start = false;
    bool isSuperBlow = false;

	bool block = false;
	bool dodge = false;
	bool p1MoveBack = false;
	bool p1StandUpStart = false;
	bool p1WalkStart = false;

	public bool hitTextFollowP1 = false;

	bool p1BowEnd = false;

	Animator anim;
	Animator patrickAnim;

	public bool JoystickActive {
		
		get {
			return joystickActive;
		}
		set {
			joystickActive = value;
		}
	}

	/*public bool FacingRight {
		
		get {
			return facingRight;
		}
		set {
			facingRight = value;
		}
	}*/

	public bool P1MoveUpZ {
		
		get {
			return p1MoveUpZ;
		}
		set {
			p1MoveUpZ = value;
		}
	}

	public bool P1MoveDownZ {
		
		get {
			return p1MoveDownZ;
		}
		set {
			p1MoveDownZ = value;
		}
	}

	public bool P1MoveX {
		
		get {
			return p1MoveX;
		}
		set {
			p1MoveX = value;
		}
	}

	public bool SAttack1 {
		
		get {
			return sAttack1;
		}
		set {
			sAttack1 = value;
		}
	}

	public bool SAttack2 {
		
		get {
			return sAttack2;
		}
		set {
			sAttack2 = value;
		}
	}

	public bool SAttack3 {
		
		get {
			return sAttack3;
		}
		set {
			sAttack3 = value;
		}
	}

	public bool SAttack3Start {
		
		get {
			return sAttack3Start;
		}
		set {
			sAttack3Start = value;
		}
	}

	public bool Block {
		
		get {
			return block;
		}
		set {
			block = value;
		}
	}

	public bool Dodge {
		
		get {
			return dodge;
		}
		set {
			dodge = value;
		}
	}

	public float SAttackTimer {
		
		get {
			return sAttackTimer;
		}
		set {
			sAttackTimer = value;
		}
	}

	public float SAttackTimerMax {
		
		get {
			return sAttackTimerMax;
		}
		set {
			sAttackTimerMax = value;
		}
	}

	public float SAttack3Timer {
		
		get {
			return sAttack3Timer;
		}
		set {
			sAttack3Timer = value;
            isSuperBlow = false;
		}
	}
	
	public float SAttack3TimerMax {
		
		get {
			return sAttack3TimerMax;
		}
		set {
			sAttack3TimerMax = value;
		}
	}

	void Awake () {
	
		manager = GameObject.Find("MainController").GetComponent<GameManager> ();
		patrickScript = GameObject.Find ("Patrick").GetComponent<PatrickScript> ();
		etcJoystick = GameObject.Find ("DynamicJoystick").GetComponent<ETCJoystick> ();
        joystick.SetActive(false);

        transform.position = new Vector3 (0, 0, 0);

	}

	void Update () {

		patrick = manager.patrick;
		superScene = manager.superScene;

		fight = manager.fight;
		chat = manager.chat;

		anim = manager.anim;
		patrickAnim = manager.patrickAnim;

		//joystick.SetActive (false);

		if (Time.timeScale != 0) {

			if (bajay.activeSelf && bajay.transform.position.x < 10f && bajay.transform.position.x > -10f &&
				manager.bajaySound.isPlaying == false && Time.timeScale != 0) {
				manager.bajaySound.Play ();
			}

			// --- P1 strolling mode & movements ---
			if (transform.position.x < -25f) {
				transform.position = new Vector3 (-25f, transform.position.y, transform.position.z);

				joystick.SetActive (false);
				manager.chat = true;
				manager.screenSrink = true;
				manager.screenEnlarge = false;
				manager.screenShut = false;
			
				manager.panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
				manager.panelText.text = "DO YOU WANT TO EXIT TO MAIN MENU?";

				manager.leaveButton.GetComponentInChildren<Text> ().text = "Keep Playing";
				manager.leaveButton.GetComponentInChildren<Text> ().fontSize = 13;

				manager.exitButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (-140, 6);
				manager.leaveButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
			}
		
			if (transform.position.x > 25f) {
				transform.position = new Vector3 (25f, transform.position.y, transform.position.z);
			}
		
			float moveH = Input.GetAxis ("Horizontal");
		
			if (!fight) {
			
				if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
					if (transform.position.z < 2f) {
						p1MoveUpZ = true;
					}
				}
			
				if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
					if (transform.position.z > -2f) {
						p1MoveDownZ = true;
					}
				}
			
				if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
					p1MoveX = true;
					if (!chat) {
						transform.localScale = new Vector3 (1, 1, 1);
					}
				}

				if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
					p1MoveX = true;
					if (!chat) {
						transform.localScale = new Vector3 (-1, 1, 1);
					}
				}
			
				if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) {
					p1MoveX = false;
					anim.SetBool ("Walk", false);
				}
			
				if (p1MoveUpZ && !chat) {
				
					p1MoveDownZ = false;
					if (transform.position.z < 2f) {
						anim.SetBool ("Walk", true);
						p1Z += 0.04f;
						transform.position = new Vector3 (transform.position.x, transform.position.y, p1Z);
					}
				}
			
				if (p1MoveDownZ && !chat) {
				
					p1MoveUpZ = false;
					if (transform.position.z > -2f) {
						anim.SetBool ("Walk", true);
						p1Z -= 0.04f;
						transform.position = new Vector3 (transform.position.x, transform.position.y, p1Z);
					}
				}
			
				if (transform.position.z > -1.1f && transform.position.z < -1f && p1MoveUpZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -1f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z > -0.1f && transform.position.z < 0f && p1MoveUpZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z > 0.9f && transform.position.z < 1f && p1MoveUpZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z > 2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 2f);
					anim.SetBool ("Walk", false);
					p1MoveUpZ = false;
				}
			
				if (transform.position.z < 1.1f && transform.position.z > 1f && p1MoveDownZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 1f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (transform.position.z < 0.1f && transform.position.z > 0f && p1MoveDownZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (transform.position.z < -0.9f && transform.position.z > -1f && p1MoveDownZ) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -1f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (transform.position.z < -2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -2f);
					anim.SetBool ("Walk", false);
					p1MoveDownZ = false;
				}
			
				if (p1MoveX && !chat) {
					anim.SetBool ("Walk", true);
					transform.position = new Vector3 (transform.position.x + (moveH * maxSpeed), transform.position.y, transform.position.z);
				}

				/*if (!p1MoveX){
				anim.SetBool ("Walk", false);
			}*/

				if (joystickActive && etcJoystick.axisX.axisValue == 0 && p1MoveX) {
					joystickActive = false;
					p1MoveX = false;
					anim.SetBool ("Walk", false);
				}

				if (etcJoystick.axisX.axisValue > 0) {
					transform.localScale = new Vector3 (1, 1, 1);
					anim.SetBool ("Walk", true);
				}

				if (etcJoystick.axisX.axisValue < 0) {
					transform.localScale = new Vector3 (-1, 1, 1);
					anim.SetBool ("Walk", true);
				}

			
				/*if (moveH > 0 && !facingRight && !chat) {
				Flip1 ();
			} else if (moveH < 0 && facingRight && !chat) {
				Flip1 ();
			}*/
			}

			// --- p1 Super Attacks ---
			if (anim.GetInteger ("FightMove") == 17) {
				transform.position = new Vector3 (transform.position.x + ((-4f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}

			if (anim.GetInteger ("FightMove") == 17 && transform.position.x < -3.9f) {
				anim.SetInteger ("FightMove", 2);
                patrickAnim.SetInteger("PatrickFightMove", 2);
                transform.position = new Vector3 (-4f, transform.position.y, transform.position.z);
			}

			if (anim.GetInteger ("FightMove") == 2) {
				if (sAttack1 || sAttack2 || sAttack3) {
					sAttackStart = true;
				}
			}

			if (sAttackStart) {
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				sAttackTimer -= Time.deltaTime * 100f;
			}

			if (sAttackTimer <= 0) {
				sAttackStart = false;
				if (sAttack1) {
					anim.SetInteger ("FightMove", 10);
					manager.pukulanVoice.Play ();
				}
				if (sAttack2) {
					anim.SetInteger ("FightMove", 11);
					manager.awurawuranVoice.Play ();
				}
				if (sAttack3) {
					anim.SetInteger ("FightMove", 12);
					sAttack3Start = true;
					manager.sapuJagatVoice.Play ();
				}
				sAttackTimer = sAttackTimerMax;
			}

			if (anim.GetInteger ("FightMove") == 10 || anim.GetInteger ("FightMove") == 11) {
				transform.position = new Vector3 (transform.position.x + ((0.6f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}

			if (sAttack3Start) {
				sAttack3Timer -= Time.deltaTime * 100f;
			}

			if (sAttack3Timer < 5f && !isSuperBlow) {
                isSuperBlow = true;
				Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x + 3f, -0.2f, transform.position.z), Quaternion.identity);
				manager.swipSound.Play ();
			}

			// --- P1 Deffend Actions ---
			if (patrickAnim.GetInteger ("PatrickFightMove") == 10 && patrick.transform.position.x > 2f && patrick.transform.position.x < 3f) {
				if (block) {
					anim.SetInteger ("FightMove", 5); // --- P1 blocks
					manager.hitSound.Play ();
					manager.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p1HBar.rectTransform.sizeDelta = new Vector2 (manager.p1HBar.GetComponent<RectTransform> ().rect.width - (sAtt1Damage / 2), manager.p1HBar.GetComponent<RectTransform> ().rect.height);
					//manager.p1HBarX = (sAtt1Damage / 2) * -1;
					sAtt1Damage = sAtt1Damage / 2;
					manager.hitText.text = "-" + sAtt1Damage.ToString ();
					hitTextFollowP1 = true;
					sAtt1Damage = sAtt1Damage * 2;
					block = false;
				} else if (dodge) {
					anim.SetInteger ("FightMove", 4); // --- P1 dodges
					manager.jumpSound.Play ();
					manager.hitText.text = "Miss";
					hitTextFollowP1 = true;
					dodge = false;
				} else {
					anim.SetInteger ("FightMove", 13); // --- P1 got hit
					manager.hitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p1HBar.rectTransform.sizeDelta = new Vector2 (manager.p1HBar.GetComponent<RectTransform> ().rect.width - sAtt1Damage, manager.p1HBar.GetComponent<RectTransform> ().rect.height);
					//manager.p1HBarX = sAtt1Damage * -1;
					manager.hitText.text = "-" + sAtt1Damage.ToString ();
					hitTextFollowP1 = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (patrickAnim.GetInteger ("PatrickFightMove") == 11 && patrick.transform.position.x > 2f && patrick.transform.position.x < 3f) {
				if (block) {
					anim.SetInteger ("FightMove", 5); // --- P1 blocks
					manager.hitSound.Play ();
					manager.manyHitSound.Play ();
					manager.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p1HBar.rectTransform.sizeDelta = new Vector2 (manager.p1HBar.GetComponent<RectTransform> ().rect.width - (sAtt2Damage / 2), manager.p1HBar.GetComponent<RectTransform> ().rect.height);
					//manager.p1HBarX = (sAtt2Damage / 2) * -1;
					sAtt2Damage = sAtt2Damage / 2;
					manager.hitText.text = "-" + sAtt2Damage.ToString ();
					hitTextFollowP1 = true;
					sAtt2Damage = sAtt2Damage * 2;
					block = false;
				} else if (dodge) {
					anim.SetInteger ("FightMove", 4); // --- P1 dodges
					manager.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					manager.hitText.text = "Miss";
					hitTextFollowP1 = true;
					dodge = false;
				} else {
					anim.SetInteger ("FightMove", 13); // --- P1 got hit
					manager.hitSound.Play ();
					manager.manyHitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p1HBar.rectTransform.sizeDelta = new Vector2 (manager.p1HBar.GetComponent<RectTransform> ().rect.width - sAtt2Damage, manager.p1HBar.GetComponent<RectTransform> ().rect.height);
					manager.hitText.text = "-" + sAtt2Damage.ToString ();
					hitTextFollowP1 = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}

			if (patrickScript.P2SAttack3Timer <= 0) {
				patrickScript.P2SAttack3Start = false;
				if (block) {
					anim.SetInteger ("FightMove", 5); // --- P1 blocks
					manager.hitSound.Play ();
					manager.criticalSound.Play ();
					manager.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p1HBar.rectTransform.sizeDelta = new Vector2 (manager.p1HBar.GetComponent<RectTransform> ().rect.width - (sAtt3Damage / 2), manager.p1HBar.GetComponent<RectTransform> ().rect.height);
					sAtt3Damage = sAtt3Damage / 2;
					manager.hitText.text = "-" + sAtt3Damage.ToString ();
					hitTextFollowP1 = true;
					sAtt3Damage = sAtt3Damage * 2;
					block = false;
				} else if (dodge) {
					anim.SetInteger ("FightMove", 4); // --- P1 dodges
					manager.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					manager.hitText.text = "Miss";
					hitTextFollowP1 = true;
					dodge = false;
				} else {
					anim.SetInteger ("FightMove", 13); // --- P1 got hit
					manager.hitSound.Play ();
					manager.criticalSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					manager.p1HBar.rectTransform.sizeDelta = new Vector2 (manager.p1HBar.GetComponent<RectTransform> ().rect.width - sAtt3Damage, manager.p1HBar.GetComponent<RectTransform> ().rect.height);
					manager.hitText.text = "-" + sAtt3Damage.ToString ();
					hitTextFollowP1 = true;
				}
				StartCoroutine ("HitTextFadeOut");
				p1MoveBack = true;
				patrickScript.P2SAttack3Timer = patrickScript.P2SAttack3TimerMax;
			}

			if (hitTextFollowP1) {
				patrickScript.hitTextFollowPatrick = false;
				manager.hitText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (transform.position.x * 40, 100);
				//manager.hitText.transform.position = new Vector2 (transform.position.x, transform.position.y + 2f);
			}

			// --- P1 moves back ---
			if (patrick.transform.position.x < 0f && patrick.transform.position.x > -0.7f) {
				if (patrickAnim.GetInteger ("PatrickFightMove") == 10 || patrickAnim.GetInteger ("PatrickFightMove") == 11) {
					transform.position = new Vector3 (transform.position.x + ((-5f - transform.position.x) * 6f * Time.deltaTime), transform.position.y, transform.position.z);
				}
			}
		
			if (p1MoveBack) {
				transform.position = new Vector3 (transform.position.x + ((-5f - transform.position.x) * 6f * Time.deltaTime), transform.position.y, transform.position.z);
			}
		
			if (anim.GetInteger ("FightMove") == 4 && transform.position.x < -4.9f) { // --- P1 is dodging
				p1StandUpStart = true;
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				p1MoveBack = false;
			}
		
			if (anim.GetInteger ("FightMove") == 5 && transform.position.x < -4.9f) { // --- P1 is blocking
				if (manager.p1HBar.GetComponent<RectTransform> ().rect.width > 0) {
					p1StandUpStart = true;
				} else {
					anim.SetInteger ("FightMove", 14);
				}
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				p1MoveBack = false;
			}
		
			if (anim.GetInteger ("FightMove") == 13 && transform.position.x < -4.9f) { // --- P1 got hit
				anim.SetInteger ("FightMove", 14);
				superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				p1MoveBack = false;
			}
		
			if (anim.GetInteger ("FightMove") == 14 && manager.p1HBar.GetComponent<RectTransform> ().rect.width > 0) {
				p1StandUpStart = true;
			}
		
			if (p1StandUpStart) {
                p1StandUpTimer -= Time.deltaTime * 100f; 
			}
		
			if (p1StandUpTimer <= 0) {
				p1StandUpStart = false;
				anim.SetInteger ("FightMove", 15); //--- Stand up
				if (patrickScript.P2SAttack3) {
					patrickAnim.SetInteger ("PatrickFightMove", 2);
				} else {
					patrickAnim.SetInteger ("PatrickFightMove", 17);
				}
				patrickScript.P2SAttack1 = false;
				patrickScript.P2SAttack2 = false;
				patrickScript.P2SAttack3 = false;
				p1StandUpTimer = p1StandUpTimerMax;
				p1WalkStart = true;
			}
		
			if (p1WalkStart) {
				p1WalkTimer -= Time.deltaTime * 100f;
			}
		
			if (p1WalkTimer <= 0) {
				p1WalkStart = false;
				anim.SetInteger ("FightMove", 16);
				p1WalkTimer = p1WalkTimerMax;
			}
		
			if (anim.GetInteger ("FightMove") == 16) {
				transform.position = new Vector3 (transform.position.x + ((-4f - transform.position.x) * 6f * Time.deltaTime), transform.position.y, transform.position.z);
			}
		
			if (anim.GetInteger ("FightMove") == 16 && transform.position.x > -4.1f) {
				anim.SetInteger ("FightMove", 2);
				transform.position = new Vector3 (-4f, transform.position.y, transform.position.z);
				manager.fightStart = true;
			}

			// --- P1 wins ---
			if (patrickAnim.GetInteger ("PatrickFightMove") == 14 && manager.p2HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				if (sAttack1 || sAttack2 || sAttack3) {
					manager.strollingStart = true;
					if (sAttack3) {
						anim.SetInteger ("FightMove", 2);
					} else {
						anim.SetInteger ("FightMove", 17);
					}
					sAttack1 = false;
					sAttack2 = false;
					sAttack3 = false;
				}
			}
		
			if (anim.GetInteger ("FightMove") == 2 && transform.position.x == -4f && manager.p2HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				p1BowEnd = true;
			}
		
			if (p1BowEnd) {
				p1BowEndTimer -= Time.deltaTime * 100f;
			}
		
			if (p1BowEndTimer <= 0) {
				p1BowEnd = false;
				anim.SetInteger ("FightMove", 1);

				if (manager.moneyPoint < 115) {
					manager.moneyDynamicPoint = 115 - manager.moneyPoint;
					manager.moneyPoint = manager.moneyPoint + manager.moneyDynamicPoint;
				} else if (manager.moneyPoint >= 115) {
					manager.moneyDynamicPoint = 15;
					manager.moneyPoint += manager.moneyDynamicPoint;
				}

				p1BowEndTimer = p1BowEndTimerMax;
			}

		}

	}

	/*public void Flip1 (){
		
		facingRight = !facingRight;
		Vector3 p1Scale = transform.localScale;
		p1Scale.x *= -1;
		transform.localScale = p1Scale;
		
	}*/

	IEnumerator HitTextFadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
			}
			manager.hitText.color = new Color (0.5f, 0, 0, i);
			yield return new WaitForSeconds(0.1f);
		}
	}

    public void OnMoveLeft (bool isMove)
    {
        if (isMove)
        {
            p1MoveX = true;
            if (!chat)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            p1MoveX = false;
            anim.SetBool("Walk", false);
        }
        
    }

}
