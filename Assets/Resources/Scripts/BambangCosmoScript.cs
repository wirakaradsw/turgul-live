using UnityEngine;
using System.Collections;

public class BambangCosmoScript : MonoBehaviour {

	TournamentScript tourScript;
	BonangScript bonangScript;
	NKScript nkScript;
	RonScript ronScript;
	RonRageScript ronRageScript;
	KBHScript kbhScript;
	SunWukongScript wukongScript;
	
	int sAttackTimer = 100;
	int sAttackTimerMax = 100;
	//int tourScript.p1SAttack3Timer = 40;
	//int tourScript.p1SAttack3TimerMax = 40;
	
	int standUpTimer = 40;
	int standUpTimerMax = 40;
	int walkTimer = 40;
	int walkTimerMax = 40;
	
	int endingTimer = 80;
	int endingTimerMax = 80;
	
	float defPoint = 20f;
	float attPoint = 8f;
	
	public float sAtt1Damage = 40f;
	public float sAtt2Damage = 80f;
	public float sAtt3Damage = 200f;
	public float sAtt4Damage = 300f;
	
	bool sAttack1 = false;
	bool sAttack2 = false;
	bool sAttack3 = false;
	bool sAttack4 = false;
	bool sAttackStart = false;
	//bool tourScript.p1SAttack3Start = false;
	
	bool block = false;
	bool dodge = false;
	bool moveBack = false;
	bool standUpStart = false;
	bool walkStart = false;
	
	bool ending = false;
	
	//int tourScript.p2SAttack3Timer = 40;
	//int tourScript.p2SAttack3TimerMax = 40;
	float p2SAtt1Damage = 0f;
	float p2SAtt2Damage = 0f;
	float p2SAtt3Damage = 0f;
	float p2SAtt4Damage = 0f;
	
	//bool tourScript.p2SAttack3Start = false;
	
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
	
	public bool SAttack4 {
		
		get {
			return sAttack4;
		}
		set {
			sAttack4 = value;
		}
	}
	
	public bool SAttack3Start {
		
		get {
			return tourScript.p1SAttack3Start;
		}
		set {
			tourScript.p1SAttack3Start = value;
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
	
	public int SAttackTimer {
		
		get {
			return sAttackTimer;
		}
		set {
			sAttackTimer = value;
		}
	}
	
	public int SAttackTimerMax {
		
		get {
			return sAttackTimerMax;
		}
		set {
			sAttackTimerMax = value;
		}
	}
	
	public int SAttack3Timer {
		
		get {
			return tourScript.p1SAttack3Timer;
		}
		set {
			tourScript.p1SAttack3Timer = value;
		}
	}
	
	public int SAttack3TimerMax {
		
		get {
			return tourScript.p1SAttack3TimerMax;
		}
		set {
			tourScript.p1SAttack3TimerMax = value;
		}
	}
	
	void Start () {
		
		tourScript = GameObject.Find("MainController").GetComponent<TournamentScript> ();
		bonangScript = GameObject.Find ("Bonang").GetComponent<BonangScript> ();
		nkScript = GameObject.Find ("NK").GetComponent<NKScript> ();
		ronScript = GameObject.Find ("Ron").GetComponent<RonScript> ();
		ronRageScript = GameObject.Find ("RonRage").GetComponent<RonRageScript> ();
		kbhScript = GameObject.Find ("KBH").GetComponent<KBHScript> ();
		wukongScript = GameObject.Find ("SunWukong").GetComponent<SunWukongScript> ();
		
	}
	
	void Update () {
		
		PlayerActions ();

		if (Time.timeScale != 0) {
		
			// --- P1 Super Attacks ---
			if (tourScript.p1Anim.GetInteger ("FightMove") == 17) {
				transform.position = new Vector3 (transform.position.x + ((-4f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 17 && transform.position.x < -3.9f) {
				tourScript.p1Anim.SetInteger ("FightMove", 2);
				transform.position = new Vector3 (-4f, transform.position.y, transform.position.z);
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 2 && transform.position.x == -4f) {
				if (sAttack1 || sAttack2 || sAttack3 || sAttack4) {
					sAttackStart = true;
				}
			}
		
			if (sAttackStart) {
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				sAttackTimer --;
			}
		
			if (sAttackTimer == 0) {
				sAttackStart = false;
				if (sAttack1) {
					tourScript.p1Anim.SetInteger ("FightMove", 10);
					tourScript.pukulanVoice.Play ();
				}
				if (sAttack2) {
					tourScript.p1Anim.SetInteger ("FightMove", 11);
					tourScript.awurawuranVoice.Play ();
				}
				if (sAttack3) {
					tourScript.p1Anim.SetInteger ("FightMove", 12);
					tourScript.p1SAttack3Start = true;
					tourScript.hihiVoice.Play ();
				}
				if (sAttack4) {
					tourScript.p1Anim.SetInteger ("FightMove", 12);
					tourScript.p1SAttack3Start = true;
					tourScript.sapuJagatVoice.Play ();
				}
				sAttackTimer = sAttackTimerMax;
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 10 || tourScript.p1Anim.GetInteger ("FightMove") == 11) {
				transform.position = new Vector3 (transform.position.x + ((0.6f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 18) {
				transform.position = new Vector3 (transform.position.x + ((0.6f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
				Instantiate (Resources.Load ("Prefabs/DakochanShadowR"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				if (!tourScript.swooshSound.isPlaying) {
					tourScript.swooshSound.Play ();
				}
			}
		
			if (tourScript.p1SAttack3Start) {
				tourScript.p1SAttack3Timer--;

			}
		
			if (tourScript.p1SAttack3Timer == 5) {
				Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x + 3f, -0.2f, transform.position.z), Quaternion.identity);
				tourScript.swipSound.Play ();
			}
		
			// --- P1 Deffend Actions ---
			if (tourScript.p2Anim.GetInteger ("FightMove") == 10 && tourScript.player2.transform.position.x > 2f && tourScript.player2.transform.position.x < 3f) {
				if (block) {
					tourScript.p1Anim.SetInteger ("FightMove", 5); // --- P1 blocks
					tourScript.hitSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width - (p2SAtt1Damage / 8), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
				
					p2SAtt1Damage = p2SAtt1Damage / 8;
					tourScript.hitText.text = "-" + p2SAtt1Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt1Damage = p2SAtt1Damage * 8;
					tourScript.p1Block = false;
				} else if (dodge) {
					tourScript.p1Anim.SetInteger ("FightMove", 4); // --- P1 dodges
					tourScript.jumpSound.Play ();
					tourScript.hitText.text = "Miss";
					tourScript.p1HitTextFollow = true;
					tourScript.p1Dodge = false;
				} else {
					tourScript.p1Anim.SetInteger ("FightMove", 13); // --- P1 got hit
					tourScript.hitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt1Damage / 4), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
				
					p2SAtt1Damage = p2SAtt1Damage / 4;
					tourScript.hitText.text = "-" + p2SAtt1Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt1Damage = p2SAtt1Damage * 4;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 11 && tourScript.player2.transform.position.x > 2f && tourScript.player2.transform.position.x < 3f) {
				if (block) {
					tourScript.p1Anim.SetInteger ("FightMove", 5); // --- P1 blocks
					tourScript.hitSound.Play ();
					tourScript.manyHitSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt2Damage / 8), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
				
					p2SAtt2Damage = p2SAtt2Damage / 8;
					tourScript.hitText.text = "-" + p2SAtt2Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt2Damage = p2SAtt2Damage * 8;
					tourScript.p1Block = false;
				} else if (dodge) {
					tourScript.p1Anim.SetInteger ("FightMove", 4); // --- P1 dodges
					tourScript.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.hitText.text = "Miss";
					tourScript.p1HitTextFollow = true;
					tourScript.p1Dodge = false;
				} else {
					tourScript.p1Anim.SetInteger ("FightMove", 13); // --- P1 got hit
					tourScript.hitSound.Play ();
					tourScript.manyHitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt2Damage / 4), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);

					p2SAtt2Damage = p2SAtt2Damage / 4;
					tourScript.hitText.text = "-" + p2SAtt2Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt2Damage = p2SAtt2Damage * 4;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (tourScript.P2Id == 3) {
			
				if (tourScript.p2SAttack3Timer == 0) {
					tourScript.p2SAttack3Start = false;
					if (!block && !dodge) {
						tourScript.p1Anim.SetInteger ("FightMove", 13); // --- P1 got hit
						tourScript.hitSound.Play ();
						tourScript.criticalSound.Play ();
						Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width - (p2SAtt3Damage / 4), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);

						p2SAtt3Damage = p2SAtt3Damage / 4;
						tourScript.hitText.text = "-" + p2SAtt3Damage.ToString ();
						tourScript.p1HitTextFollow = true;
						p2SAtt3Damage = p2SAtt3Damage * 4;
						StartCoroutine ("HitTextFadeOut");
						moveBack = true;
					}
					tourScript.p1Block = false;
					tourScript.p1Dodge = false;
					tourScript.p2SAttack3Timer = tourScript.p2SAttack3TimerMax;
				}
			
				if (tourScript.p2Anim.GetInteger ("FightMove") == 12 && tourScript.p2SAttack3Timer == 39) {
					if (block) {
						tourScript.p1Anim.SetInteger ("FightMove", 5); // --- P1 blocks
						tourScript.hitSound.Play ();
						tourScript.criticalSound.Play ();
						tourScript.blockSound.Play ();
						Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt3Damage / 8), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
						p2SAtt3Damage = p2SAtt3Damage / 8;
						tourScript.hitText.text = "-" + p2SAtt3Damage.ToString ();
						tourScript.p1HitTextFollow = true;
						p2SAtt3Damage = p2SAtt3Damage * 8;
						StartCoroutine ("HitTextFadeOut");
						moveBack = true;
					} else if (dodge) {
						tourScript.p1Anim.SetInteger ("FightMove", 4); // --- P1 dodges
						tourScript.jumpSound.Play ();
						tourScript.hitText.text = "Miss";
						tourScript.p1HitTextFollow = true;
						StartCoroutine ("HitTextFadeOut");
						moveBack = true;
					}
				}
			
			} else if (tourScript.P2Id == 6) {
			
				if (tourScript.p2Anim.GetInteger ("FightMove") == 12 && tourScript.player2.transform.position.x > 2f && tourScript.player2.transform.position.x < 3f) {
					if (block) {
						tourScript.p1Anim.SetInteger ("FightMove", 5); // --- P1 blocks
						tourScript.hitSound.Play ();
						tourScript.blockSound.Play ();
						Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width - (p2SAtt3Damage / 8), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
					
						p2SAtt3Damage = p2SAtt3Damage / 8;
						tourScript.hitText.text = "-" + p2SAtt3Damage.ToString ();
						tourScript.p1HitTextFollow = true;
						p2SAtt3Damage = p2SAtt3Damage * 8;
						tourScript.p1Block = false;
					} else if (dodge) {
						tourScript.p1Anim.SetInteger ("FightMove", 4); // --- P1 dodges
						tourScript.jumpSound.Play ();
						tourScript.hitText.text = "Miss";
						tourScript.p1HitTextFollow = true;
						tourScript.p1Dodge = false;
					} else {
						tourScript.p1Anim.SetInteger ("FightMove", 13); // --- P1 got hit
						tourScript.hitSound.Play ();
						Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					
						tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt3Damage / 4), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
					
						p2SAtt3Damage = p2SAtt3Damage / 4;
						tourScript.hitText.text = "-" + p2SAtt3Damage.ToString ();
						tourScript.p1HitTextFollow = true;
						p2SAtt3Damage = p2SAtt3Damage * 4;
					}
					StartCoroutine ("HitTextFadeOut");
				}
			
			} else if (tourScript.p2SAttack3Timer == 0) {
				tourScript.p2SAttack3Start = false;
				if (block) {
					tourScript.p1Anim.SetInteger ("FightMove", 5); // --- P1 blocks
					tourScript.hitSound.Play ();
					tourScript.criticalSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt3Damage / 8), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
					p2SAtt3Damage = p2SAtt3Damage / 8;
					tourScript.hitText.text = "-" + p2SAtt3Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt3Damage = p2SAtt3Damage * 8;
					tourScript.p1Block = false;
				} else if (dodge) {
					tourScript.p1Anim.SetInteger ("FightMove", 4); // --- P1 dodges
					tourScript.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					tourScript.hitText.text = "Miss";
					tourScript.p1HitTextFollow = true;
					tourScript.p1Dodge = false;
				} else {
					tourScript.p1Anim.SetInteger ("FightMove", 13); // --- P1 got hit
					tourScript.hitSound.Play ();
					tourScript.criticalSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width - (p2SAtt3Damage / 4), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
					p2SAtt3Damage = p2SAtt3Damage / 4;
					tourScript.hitText.text = "-" + p2SAtt3Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt3Damage = p2SAtt3Damage * 4;
				}
				StartCoroutine ("HitTextFadeOut");
				moveBack = true;
				tourScript.p2SAttack3Timer = tourScript.p2SAttack3TimerMax;
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 18 && tourScript.player2.transform.position.x > 2f && tourScript.player2.transform.position.x < 3f) {
				if (block) {
					tourScript.p1Anim.SetInteger ("FightMove", 5); // --- P1 blocks
					tourScript.hitSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width - (p2SAtt4Damage / 8), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
				
					p2SAtt4Damage = p2SAtt4Damage / 8;
					tourScript.hitText.text = "-" + p2SAtt4Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt4Damage = p2SAtt4Damage * 8;
					tourScript.p1Block = false;
				} else if (dodge) {
					tourScript.p1Anim.SetInteger ("FightMove", 4); // --- P1 dodges
					tourScript.jumpSound.Play ();
					tourScript.hitText.text = "Miss";
					tourScript.p1HitTextFollow = true;
					tourScript.p1Dodge = false;
				} else {
					tourScript.p1Anim.SetInteger ("FightMove", 13); // --- P1 got hit
					if (tourScript.P2Id == 6) {
						tourScript.hitSound.Play ();
						Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
					} else {
						tourScript.hitSound.Play ();
						tourScript.criticalSound.Play ();
						Instantiate (Resources.Load ("Prefabs/SuperBlow2"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
						Instantiate (Resources.Load ("Prefabs/Dark"), new Vector3 (0, 0, 0), Quaternion.identity);
					}
					tourScript.p1HBar.sizeDelta = new Vector2 (tourScript.p1HBar.rect.width - (p2SAtt4Damage / 4), tourScript.p1HBar.GetComponent<RectTransform> ().rect.height);
				
					p2SAtt4Damage = p2SAtt4Damage / 4;
					tourScript.hitText.text = "-" + p2SAtt4Damage.ToString ();
					tourScript.p1HitTextFollow = true;
					p2SAtt4Damage = p2SAtt4Damage * 4;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (tourScript.p1HitTextFollow) {
				tourScript.p2HitTextFollow = false;
				tourScript.hitText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (transform.position.x * 40, 100);
			}
		
			// --- P1 moves back ---
			if (tourScript.player2.transform.position.x < 0f && tourScript.player2.transform.position.x > -0.7f) {
				if (tourScript.p2Anim.GetInteger ("FightMove") == 10 || tourScript.p2Anim.GetInteger ("FightMove") == 11 ||
					tourScript.p2Anim.GetInteger ("FightMove") == 18 || (tourScript.P2Id == 6 && tourScript.p2Anim.GetInteger ("FightMove") == 12)) {
					transform.position = new Vector3 (transform.position.x + ((-5f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
				}
			}
		
			if (moveBack) {
				transform.position = new Vector3 (transform.position.x + ((-5f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 4 && transform.position.x < -4.9f) { // --- P1 is dodging
				standUpStart = true;
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				moveBack = false;
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 5 && transform.position.x < -4.9f) { // --- P1 is blocking
				if (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width > 0) {
					standUpStart = true;
				} else {
					tourScript.p1Anim.SetInteger ("FightMove", 14);
				}
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				moveBack = false;
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 13 && transform.position.x < -4.9f) { // --- P1 got hit
				tourScript.p1Anim.SetInteger ("FightMove", 14);
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				moveBack = false;
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 14 && tourScript.p1HBar.GetComponent<RectTransform> ().rect.width > 0) {
				standUpStart = true;
			}
		
			if (standUpStart) {
				standUpTimer--;
			}
		
			if (standUpTimer == 0) {
				standUpStart = false;
				tourScript.p1Anim.SetInteger ("FightMove", 15); //--- Stand up
			
				if (tourScript.P2Id != 3 && tourScript.P2Id != 6 && tourScript.p2SAttack3) {
					tourScript.p2Anim.SetInteger ("FightMove", 2);
				} else {
					tourScript.p2Anim.SetInteger ("FightMove", 17);
				}
				tourScript.p2SAttack1 = false;
				tourScript.p2SAttack2 = false;
				tourScript.p2SAttack3 = false;
				tourScript.p2SAttack4 = false;
			
				standUpTimer = standUpTimerMax;
				walkStart = true;
			}
		
			if (walkStart) {
				walkTimer--;
			}
		
			if (walkTimer == 0) {
				walkStart = false;
				tourScript.p1Anim.SetInteger ("FightMove", 16);
				walkTimer = walkTimerMax;
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 16) {
				transform.position = new Vector3 (transform.position.x + ((-4f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 16 && transform.position.x > -4.1f) {
				tourScript.p1Anim.SetInteger ("FightMove", 2);
				transform.position = new Vector3 (-4f, transform.position.y, transform.position.z);
				tourScript.fightStart = true;
			}
		
			// --- P1 wins ---
			if (tourScript.p2Anim.GetInteger ("FightMove") == 14 && tourScript.p2HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				if (sAttack1 || sAttack2 || sAttack3 || sAttack4) {
					tourScript.strollingStart = true;
					if (sAttack3) {
						tourScript.p1Anim.SetInteger ("FightMove", 2);
					} else {
						tourScript.p1Anim.SetInteger ("FightMove", 17);
					}
					tourScript.p1SAttack1 = false;
					tourScript.p1SAttack2 = false;
					tourScript.p1SAttack3 = false;
					tourScript.p1SAttack4 = false;
				}
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 2 && transform.position.x == -4f && tourScript.p2HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				if (tourScript.P2Id != 5 || (tourScript.P2Id == 5 && tourScript.p2Raging)) {
					ending = true;
				}
			}
		
			if (ending) {
				endingTimer--;
			}
		
			if (endingTimer == 0) {
				ending = false;
				tourScript.p1Anim.SetInteger ("FightMove", 1);
			
				PlayerPrefs.SetInt ("moneyTournament", 150);
			
				endingTimer = endingTimerMax;
			}
		
			// --- P1 Loses ---
			if (tourScript.p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {

				PlayerPrefs.SetInt ("registered", 0);
				PlayerPrefs.SetInt ("p1Lost", 1);
			
			}

		}
		
	}
	
	void PlayerActions(){
		
		if (tourScript.P1Id == 1) {
			sAttack1 = tourScript.p1SAttack1;
			sAttack2 = tourScript.p1SAttack2;
			sAttack3 = tourScript.p1SAttack3;
			sAttack4 = tourScript.p1SAttack4;
			block = tourScript.p1Block;
			dodge = tourScript.p1Dodge;
		}
		
		if (tourScript.P2Id == 3) {
			//tourScript.p2SAttack3Timer = bonangScript.SAttack3Timer;
			//tourScript.p2SAttack3TimerMax = bonangScript.SAttack3TimerMax;
			p2SAtt1Damage = bonangScript.sAtt1Damage;
			p2SAtt2Damage = bonangScript.sAtt2Damage;
			p2SAtt3Damage = bonangScript.sAtt3Damage;
			
			//tourScript.p2SAttack3Start = bonangScript.SAttack3Start;
		}else if (tourScript.P2Id == 4) {
			//tourScript.p2SAttack3Timer = nkScript.SAttack3Timer;
			//tourScript.p2SAttack3TimerMax = nkScript.SAttack3TimerMax;
			p2SAtt1Damage = nkScript.sAtt1Damage;
			p2SAtt2Damage = nkScript.sAtt2Damage;
			p2SAtt3Damage = nkScript.sAtt3Damage;
			/*p2SAttack1 = nkScript.SAttack1;
			p2SAttack2 = nkScript.SAttack2;
			p2SAttack3 = nkScript.SAttack3;
			tourScript.p2SAttack3Start = nkScript.SAttack3Start;
			tourScript.p2HitTextFollow = nkScript.tourScript.p1HitTextFollow;*/
		}else if (tourScript.P2Id == 5 && !tourScript.p2Raging) {
			
			p2SAtt1Damage = ronScript.sAtt1Damage;
			p2SAtt2Damage = ronScript.sAtt2Damage;
			p2SAtt3Damage = ronScript.sAtt3Damage;
			
		}else if (tourScript.P2Id == 5 && tourScript.p2Raging) {
			
			p2SAtt1Damage = ronRageScript.sAtt1Damage;
			p2SAtt2Damage = ronRageScript.sAtt2Damage;
			p2SAtt3Damage = ronRageScript.sAtt3Damage;
			p2SAtt4Damage = ronRageScript.sAtt4Damage;
			
		}else if (tourScript.P2Id == 6) {
			
			p2SAtt1Damage = kbhScript.sAtt1Damage;
			p2SAtt2Damage = kbhScript.sAtt2Damage;
			p2SAtt3Damage = kbhScript.sAtt3Damage;
			p2SAtt4Damage = kbhScript.sAtt4Damage;
			
		}else if (tourScript.P2Id == 7) {
			
			p2SAtt1Damage = wukongScript.sAtt1Damage;
			p2SAtt2Damage = wukongScript.sAtt2Damage;
			p2SAtt3Damage = wukongScript.sAtt3Damage;
			p2SAtt4Damage = wukongScript.sAtt4Damage;
			
		}
	}
	
	IEnumerator HitTextFadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
			}
			tourScript.hitText.color = new Color (0.5f, 0, 0, i);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
