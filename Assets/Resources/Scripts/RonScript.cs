using UnityEngine;
using System.Collections;

public class RonScript : MonoBehaviour {

	TournamentScript tourScript;
	BambangScript bambangScript;
	BambangRageScript bambangRageScript;
	BambangCosmoScript bambangCosmoScript;
	
	int p2SAttInitiationTimer = 40;
	int p2SAttInitiationTimerMax = 40;
	int p2SAttAction = 0;
	int sAttackTimer = 100;
	int sAttackTimerMax = 100;
	
	int p2DefAction = 0;
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
	public float sAtt3Damage = 120f;

	bool sAttackStart = false;
	
	bool block = false;
	bool dodge = false;
	bool moveBack = false;
	bool standUpStart = false;
	bool walkStart = false;
	
	bool ending = false;
	
	int p1SAttackTimer = 100;
	int p1SAttackTimerMax = 100;

	float p1SAtt1Damage = 0f;
	float p1SAtt2Damage = 0f;
	float p1SAtt3Damage = 0f;
	float p1SAtt4Damage = 0f;
	
	public bool SAttack1 {
		
		get {
			return tourScript.p2SAttack1;
		}
		set {
			tourScript.p2SAttack1 = value;
		}
	}
	
	public bool SAttack2 {
		
		get {
			return tourScript.p2SAttack2;
		}
		set {
			tourScript.p2SAttack2 = value;
		}
	}
	
	public bool SAttack3 {
		
		get {
			return tourScript.p2SAttack3;
		}
		set {
			tourScript.p2SAttack3 = value;
		}
	}
	
	public bool SAttack3Start {
		
		get {
			return tourScript.p2SAttack3Start;
		}
		set {
			tourScript.p2SAttack3Start = value;
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
			return tourScript.p2SAttack3Timer;
		}
		set {
			tourScript.p2SAttack3Timer = value;
		}
	}
	
	public int SAttack3TimerMax {
		
		get {
			return tourScript.p2SAttack3TimerMax;
		}
		set {
			tourScript.p2SAttack3TimerMax = value;
		}
	}
	
	void Start () {
		
		tourScript = GameObject.Find("MainController").GetComponent<TournamentScript> ();
		bambangScript = GameObject.Find ("Bambang").GetComponent<BambangScript> ();
		bambangRageScript = GameObject.Find ("BambangRage").GetComponent<BambangRageScript> ();
		bambangCosmoScript = GameObject.Find ("BambangCosmo").GetComponent<BambangCosmoScript> ();
		
	}
	
	void Update () {
		
		Player1SetUp ();

		if (Time.timeScale != 0) {
		
			// --- P2 initiates Super Attacks ---
			if (tourScript.p2Att1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 32f && tourScript.fighting) { 
			
				p2SAttInitiationTimer--;
			
			}
		
			if (p2SAttInitiationTimer == 0) {
				p2SAttAction = Random.Range (1, 11);
				p2SAttInitiationTimer = p2SAttInitiationTimerMax;
			}
		
			if (p2SAttAction == 7) {
				tourScript.fightSound.Play ();
				tourScript.fighting = false;
				tourScript.p2SAttack1 = true;
				StartCoroutine ("SuperSceneFadeIn");
				tourScript.p2AttBar.sizeDelta = new Vector2 (tourScript.p2AttBar.GetComponent<RectTransform> ().rect.width - 100f, tourScript.p2AttBar.GetComponent<RectTransform> ().rect.height);
				tourScript.Initial ();
			
				tourScript.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				tourScript.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
			
				if (tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width < 200) {
					tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				}
			
				if (tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
					tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				}
			
				p2SAttAction = 0;
			}
		
			if (p2SAttAction == 3 || p2SAttAction == 6) {
				if (tourScript.p2Att2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 32f) {
					tourScript.fightSound.Play ();
					tourScript.fighting = false;
					tourScript.p2SAttack2 = true;
					StartCoroutine ("SuperSceneFadeIn");
					tourScript.p2AttBar.sizeDelta = new Vector2 (tourScript.p2AttBar.GetComponent<RectTransform> ().rect.width - 200f, tourScript.p2AttBar.GetComponent<RectTransform> ().rect.height);
					tourScript.Initial ();
				
					tourScript.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
					tourScript.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				
					if (tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width < 200) {
						tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}
				
					if (tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
						tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
						tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}
				
					p2SAttAction = 0;
				}
			}
		
			if (p2SAttAction == 1 || p2SAttAction == 2 || p2SAttAction == 4 || p2SAttAction == 5) {
				if (tourScript.p2Att3Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 32f) {
					tourScript.fightSound.Play ();
					tourScript.fighting = false;
					tourScript.p2SAttack3 = true;
					StartCoroutine ("SuperSceneFadeIn");
					tourScript.p2AttBar.sizeDelta = new Vector2 (tourScript.p2AttBar.GetComponent<RectTransform> ().rect.width - 300f, tourScript.p2AttBar.GetComponent<RectTransform> ().rect.height);
					tourScript.Initial ();
				
					tourScript.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
					tourScript.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				
					if (tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width >= 100 && tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width < 200) {
						tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}
				
					if (tourScript.p1DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
						tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
						tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
					}
				
					p2SAttAction = 0;
				}
			}
		
			// --- P2 Super Attacks ---
			if (tourScript.p2Anim.GetInteger ("FightMove") == 17) {
				transform.position = new Vector3 (transform.position.x + ((4f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 17 && transform.position.x > 3.9f) {
				tourScript.p2Anim.SetInteger ("FightMove", 2);
				transform.position = new Vector3 (4f, transform.position.y, transform.position.z);
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 2 && transform.position.x == 4f) {
				if (tourScript.p2SAttack1 || tourScript.p2SAttack2 || tourScript.p2SAttack3) {
					sAttackStart = true;
				}
			}
		
			if (sAttackStart) {
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				sAttackTimer --;
			}
		
			if (sAttackTimer == 5) {
				tourScript.p1Anim.SetInteger ("FightMove", 2);
				tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def1Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.def2Button.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				tourScript.p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				tourScript.p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
			}
		
			if (sAttackTimer == 0) {
				sAttackStart = false;
				if (tourScript.p2SAttack1) {
					tourScript.p2Anim.SetInteger ("FightMove", 10);
					tourScript.oYouCanVoice.Play ();
				}
				if (tourScript.p2SAttack2) {
					tourScript.p2Anim.SetInteger ("FightMove", 11);
					tourScript.ketketbuketVoice.Play ();
				}
				if (tourScript.p2SAttack3) {
					tourScript.p2Anim.SetInteger ("FightMove", 12);
					tourScript.p2SAttack3Start = true;
					tourScript.abuketVoice.Play ();
				}
				sAttackTimer = sAttackTimerMax;
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 10 || tourScript.p2Anim.GetInteger ("FightMove") == 11) {
				transform.position = new Vector3 (transform.position.x + ((-0.6f - transform.position.x) * 0.4f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p2SAttack3Start) {
				tourScript.p2SAttack3Timer--;
			}
		
			if (tourScript.p2SAttack3Timer == 0) {
				Instantiate (Resources.Load ("Prefabs/ElectroBall"), new Vector3 (transform.position.x - 3f, -0.2f, transform.position.z), Quaternion.identity);
				tourScript.swipSound.Play ();
			}
		
			// --- P2 Deffend Actions ---
			if (p1SAttackTimer == p1SAttackTimerMax * 0.5f) { 
				if (tourScript.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == -72f && tourScript.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == 50f) {
					p2DefAction = Random.Range (1, 5);
					if (p2DefAction == 1 || p2DefAction == 3 || (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width <= 80)) {
						tourScript.fightSound.Play ();
						block = true;
						dodge = false;
						tourScript.p2DefBar.sizeDelta = new Vector2 (tourScript.p2DefBar.GetComponent<RectTransform> ().rect.width - 100f, tourScript.p2DefBar.GetComponent<RectTransform> ().rect.height);
						tourScript.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
					}
				}

				if (tourScript.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == -72f) {
					p2DefAction = Random.Range (1, 5);
					if (p2DefAction == 4 || (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width <= 80)) {
						tourScript.fightSound.Play ();
						block = false;
						dodge = true;
						tourScript.p2DefBar.sizeDelta = new Vector2 (tourScript.p2DefBar.GetComponent<RectTransform> ().rect.width - 200f, tourScript.p2DefBar.GetComponent<RectTransform> ().rect.height);
						tourScript.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
					} else if (p2DefAction == 1 || p2DefAction == 3) {
						if (tourScript.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.y == -72f) {
							block = true;
							dodge = false;
							tourScript.p2DefBar.sizeDelta = new Vector2 (tourScript.p2DefBar.GetComponent<RectTransform> ().rect.width - 100f, tourScript.p2DefBar.GetComponent<RectTransform> ().rect.height);
							tourScript.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
						}
					}
				}
			}
		
			if (p1SAttackTimer == 5) {
				tourScript.p2Anim.SetInteger ("FightMove", 2);
				tourScript.p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
				tourScript.p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (tourScript.p2Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, 50f);
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 10 && tourScript.player1.transform.position.x > -3f && tourScript.player1.transform.position.x < -2f) {

				if (block) {
					tourScript.p2Anim.SetInteger ("FightMove", 5); // --- P2 blocks
					tourScript.hitSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - (p1SAtt1Damage / 2), tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
				
					p1SAtt1Damage = p1SAtt1Damage / 2;
					tourScript.hitText.text = "-" + p1SAtt1Damage.ToString ();
					tourScript.p2HitTextFollow = true;
					p1SAtt1Damage = p1SAtt1Damage * 2;
					block = false;
				} else if (dodge) {
					tourScript.p2Anim.SetInteger ("FightMove", 4); // --- P2 dodges
					tourScript.jumpSound.Play ();
					tourScript.hitText.text = "Miss";
					tourScript.p2HitTextFollow = true;
					dodge = false;
				} else {
					tourScript.p2Anim.SetInteger ("FightMove", 13); // --- P2 got hit
					tourScript.hitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - p1SAtt1Damage, tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
				
					tourScript.hitText.text = "-" + p1SAtt1Damage.ToString ();
					tourScript.p2HitTextFollow = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 11 && tourScript.player1.transform.position.x > -3f && tourScript.player1.transform.position.x < -2f) {

				if (block) {
					tourScript.p2Anim.SetInteger ("FightMove", 5); // --- P2 blocks
					tourScript.hitSound.Play ();
					tourScript.manyHitSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - (p1SAtt2Damage / 2), tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
				
					p1SAtt2Damage = p1SAtt2Damage / 2;
					tourScript.hitText.text = "-" + p1SAtt2Damage.ToString ();
					tourScript.p2HitTextFollow = true;
					p1SAtt2Damage = p1SAtt2Damage * 2;
					block = false;
				} else if (dodge) {
					tourScript.p2Anim.SetInteger ("FightMove", 4); // --- P2 dodges
					tourScript.jumpSound.Play ();
					//				Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.hitText.text = "Miss";
					tourScript.p2HitTextFollow = true;
					dodge = false;
				} else {
					tourScript.p2Anim.SetInteger ("FightMove", 13); // --- P2 got hit
					tourScript.hitSound.Play ();
					tourScript.manyHitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - p1SAtt2Damage, tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
					tourScript.hitText.text = "-" + p1SAtt2Damage.ToString ();
					tourScript.p2HitTextFollow = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (tourScript.p1Anim.GetInteger ("FightMove") == 18 && tourScript.player1.transform.position.x > -3f && tourScript.player1.transform.position.x < -2f) {
			
				if (block) {
					tourScript.p2Anim.SetInteger ("FightMove", 5); // --- P2 blocks
					tourScript.hitSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - (p1SAtt4Damage / 2), tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
				
					p1SAtt4Damage = p1SAtt4Damage / 2;
					tourScript.hitText.text = "-" + p1SAtt4Damage.ToString ();
					tourScript.p2HitTextFollow = true;
					p1SAtt4Damage = p1SAtt4Damage * 2;
					block = false;
				} else if (dodge) {
					tourScript.p2Anim.SetInteger ("FightMove", 4); // --- P2 dodges
					tourScript.jumpSound.Play ();
					tourScript.hitText.text = "Miss";
					tourScript.p2HitTextFollow = true;
					dodge = false;
				} else {
					tourScript.p2Anim.SetInteger ("FightMove", 13); // --- P2 got hit
					tourScript.hitSound.Play ();
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Dark"), new Vector3 (0, 0, 0), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - p1SAtt4Damage, tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
				
					tourScript.hitText.text = "-" + p1SAtt4Damage.ToString ();
					tourScript.p2HitTextFollow = true;
				}
				StartCoroutine ("HitTextFadeOut");
			}
		
			if (tourScript.p1SAttack3Timer == 0) {
				tourScript.p1SAttack3Start = false;
				if (block) {
					tourScript.p2Anim.SetInteger ("FightMove", 5); // --- P2 blocks
					tourScript.hitSound.Play ();
					tourScript.criticalSound.Play ();
					tourScript.blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - (p1SAtt3Damage / 2), tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
					p1SAtt3Damage = p1SAtt3Damage / 2;
					tourScript.hitText.text = "-" + p1SAtt3Damage.ToString ();
					tourScript.p2HitTextFollow = true;
					p1SAtt3Damage = p1SAtt3Damage * 2;
					block = false;
				} else if (dodge) {
					tourScript.p2Anim.SetInteger ("FightMove", 4); // --- P2 dodges
					tourScript.jumpSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					tourScript.hitText.text = "Miss";
					tourScript.p2HitTextFollow = true;
					dodge = false;
				} else {
					tourScript.p2Anim.SetInteger ("FightMove", 13); // --- P2 got hit
					tourScript.hitSound.Play ();
					tourScript.criticalSound.Play ();
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (transform.position.x, -0.2f, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
					tourScript.p2HBar.sizeDelta = new Vector2 (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width - p1SAtt3Damage, tourScript.p2HBar.GetComponent<RectTransform> ().rect.height);
					tourScript.hitText.text = "-" + p1SAtt3Damage.ToString ();
					tourScript.p2HitTextFollow = true;
				}
				StartCoroutine ("HitTextFadeOut");
				moveBack = true;
				tourScript.p1SAttack3Timer = tourScript.p1SAttack3TimerMax;
			}
		
			if (tourScript.p2HitTextFollow) {
				tourScript.p1HitTextFollow = false;
				tourScript.hitText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (transform.position.x * 40, 100);
			}
		
			// --- P2 moves back ---
			if (tourScript.player1.transform.position.x > 0f && tourScript.player1.transform.position.x < 0.7f) {
				if (tourScript.p1Anim.GetInteger ("FightMove") == 10 || tourScript.p1Anim.GetInteger ("FightMove") == 11 || tourScript.p1Anim.GetInteger ("FightMove") == 18) {
					transform.position = new Vector3 (transform.position.x + ((5f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
				}
			}
		
			if (moveBack) {
				transform.position = new Vector3 (transform.position.x + ((5f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 4 && transform.position.x > 4.9f) { // --- P2 is dodging
				standUpStart = true;
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				moveBack = false;
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 5 && transform.position.x > 4.9f) { // --- P2 is blocking
				if (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width > 0) {
					standUpStart = true;
				} else {
					tourScript.p2Anim.SetInteger ("FightMove", 14);
				}
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				moveBack = false;
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 13 && transform.position.x > 4.9f) { // --- P2 got hit
				tourScript.p2Anim.SetInteger ("FightMove", 14);
				tourScript.superScene.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				moveBack = false;
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 14 && tourScript.p2HBar.GetComponent<RectTransform> ().rect.width > 0) {
				standUpStart = true;
			}
		
			if (standUpStart) {
				standUpTimer--;
			}
		
			if (standUpTimer == 0) {
				standUpStart = false;
				tourScript.p2Anim.SetInteger ("FightMove", 15); //--- Stand up
				if (tourScript.p1SAttack3) {
					tourScript.p1Anim.SetInteger ("FightMove", 2);
				} else {
					tourScript.p1Anim.SetInteger ("FightMove", 17);
				}
				tourScript.p1SAttack1 = false;
				tourScript.p1SAttack2 = false;
				tourScript.p1SAttack3 = false;
				tourScript.p1SAttack4 = false;
				standUpTimer = standUpTimerMax;
				walkStart = true;
			}
		
			if (walkStart) {
				walkTimer--;
			}
		
			if (walkTimer == 0) {
				walkStart = false;
				tourScript.p2Anim.SetInteger ("FightMove", 16);
				walkTimer = walkTimerMax;
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 16) {
				transform.position = new Vector3 (transform.position.x + ((4f - transform.position.x) * 0.06f), transform.position.y, transform.position.z);
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 16 && transform.position.x < 4.1f) {
				tourScript.p2Anim.SetInteger ("FightMove", 2);
				transform.position = new Vector3 (4f, transform.position.y, transform.position.z);
				tourScript.fightStart = true;
			}
		
			// --- P2 wins ---
			if (tourScript.p1Anim.GetInteger ("FightMove") == 14 && tourScript.p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				if (tourScript.p2SAttack1 || tourScript.p2SAttack2 || tourScript.p2SAttack3) {
					tourScript.strollingStart = true;
					tourScript.p2Anim.SetInteger ("FightMove", 17);

					tourScript.p2SAttack1 = false;
					tourScript.p2SAttack2 = false;
					tourScript.p2SAttack3 = false;
				}
			}
		
			if (tourScript.p2Anim.GetInteger ("FightMove") == 2 && transform.position.x == 4f && tourScript.p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {
				if (!tourScript.rageMode || (tourScript.rageMode && tourScript.p1Raging)) {
					ending = true;
				}
			}
		
			if (ending) {
				endingTimer--;
			}
		
			if (endingTimer == 0) {
				ending = false;
				tourScript.p2Anim.SetInteger ("FightMove", 1);
			
				PlayerPrefs.SetInt ("moneyTournament", 0);
			
				endingTimer = endingTimerMax;
			}
		
			// --- P2 Loses ---
			if (tourScript.p2HBar.GetComponent<RectTransform> ().rect.width <= 0) {
	//			if (tourScript.tournamentNumb == 2){
	//				tourScript.matchNumb = 0;
	//				PlayerPrefs.SetInt ("registered", 0);
	//			} else if (tourScript.tournamentNumb == 3 || tourScript.tournamentNumb == 4){
	//				if (tourScript.matchNumb != 0) {
	//					tourScript.matchNumb = 4;
	//				}
	//			}
			}

		}
		
	}
	
	void Player1SetUp(){
		
		if (tourScript.P1Id == 1) {
			if (!tourScript.p1Raging && !tourScript.cosmo.activeSelf){
				p1SAttackTimer = bambangScript.SAttackTimer;
				p1SAttackTimerMax = bambangScript.SAttackTimerMax;
				tourScript.p1SAttack3Timer = bambangScript.SAttack3Timer;
				tourScript.p1SAttack3TimerMax = bambangScript.SAttack3TimerMax;
				p1SAtt1Damage = bambangScript.sAtt1Damage;
				p1SAtt2Damage = bambangScript.sAtt2Damage;
				p1SAtt3Damage = bambangScript.sAtt3Damage;
			}else if (tourScript.p1Raging){
				p1SAttackTimer = bambangRageScript.SAttackTimer;
				p1SAttackTimerMax = bambangRageScript.SAttackTimerMax;
				tourScript.p1SAttack3Timer = bambangRageScript.SAttack3Timer;
				tourScript.p1SAttack3TimerMax = bambangRageScript.SAttack3TimerMax;
				p1SAtt1Damage = bambangRageScript.sAtt1Damage;
				p1SAtt2Damage = bambangRageScript.sAtt2Damage;
				p1SAtt3Damage = bambangRageScript.sAtt3Damage;
				p1SAtt4Damage = bambangRageScript.sAtt4Damage;
			}else if (tourScript.cosmo.activeSelf){
				p1SAttackTimer = bambangCosmoScript.SAttackTimer;
				p1SAttackTimerMax = bambangCosmoScript.SAttackTimerMax;
				tourScript.p1SAttack3Timer = bambangCosmoScript.SAttack3Timer;
				tourScript.p1SAttack3TimerMax = bambangCosmoScript.SAttack3TimerMax;
				p1SAtt1Damage = bambangCosmoScript.sAtt1Damage;
				p1SAtt2Damage = bambangCosmoScript.sAtt2Damage;
				p1SAtt3Damage = bambangCosmoScript.sAtt3Damage;
				p1SAtt4Damage = bambangCosmoScript.sAtt4Damage;
			}
			
			//tourScript.p1SAttack3Start = bambangScript.SAttack3Start;
		}
		
	}
	
	IEnumerator SuperSceneFadeIn(){
		for (float i = 0f; i <= 1f; i+= 0.1f) {
			tourScript.superScene.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds(0.05f);
			//yield return null;
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
