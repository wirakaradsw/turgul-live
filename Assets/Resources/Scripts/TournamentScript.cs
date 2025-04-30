using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TournamentScript : MonoBehaviour {

	BambangScript bambangScript;
	BonangScript bonangScript;
	NKScript nkScript;
	BambangRageScript bambangRageScript;
	RonScript ronScript;
	BambangCosmoScript bambangCosmoScript;

	[HideInInspector] public GameObject player1;
	[HideInInspector] public GameObject player2;
	[HideInInspector] public GameObject bambang;
	[HideInInspector] public GameObject bonang;
	[HideInInspector] public GameObject nk;
	[HideInInspector] public GameObject ron;
	[HideInInspector] public GameObject kbh;
	[HideInInspector] public GameObject sunWukong;
	[HideInInspector] public GameObject bambangRage;
	[HideInInspector] public GameObject ronRage;
	[HideInInspector] public GameObject kbhRage;
	[HideInInspector] public GameObject bambangCosmo;
	GameObject blackTop;
	GameObject blackBottom;
	[HideInInspector] public GameObject superScene;
	[HideInInspector] public GameObject cosmo;
	
	[HideInInspector] public RectTransform p1HBarFrame;
	[HideInInspector] public RectTransform p2HBarFrame;
	[HideInInspector] public RectTransform p1HBar;
	[HideInInspector] public RectTransform p2HBar;
	[HideInInspector] public RectTransform p1AttBarFrame;
	[HideInInspector] public RectTransform p1AttBarFrame2;
	[HideInInspector] public RectTransform p2AttBarFrame;
	[HideInInspector] public RectTransform p2AttBarFrame2;
	[HideInInspector] public RectTransform p1AttBar;
	[HideInInspector] public RectTransform p1AttBar2;
	[HideInInspector] public RectTransform p2AttBar;
	[HideInInspector] public RectTransform p2AttBar2;
	[HideInInspector] public RectTransform p1DefBarFrame;
	[HideInInspector] public RectTransform p2DefBarFrame;
	[HideInInspector] public RectTransform p1DefBar;
	[HideInInspector] public RectTransform p2DefBar;
	[HideInInspector] public RectTransform p1Att1Inactive;
	[HideInInspector] public RectTransform p1Def1Inactive;
	[HideInInspector] public RectTransform p1Def2Inactive;
	[HideInInspector] public RectTransform p2Att1Active;
	[HideInInspector] public RectTransform p2Att2Active;
	[HideInInspector] public RectTransform p1Att3Inactive;
	[HideInInspector] public RectTransform p1Att3aInactive;
	[HideInInspector] public RectTransform p1Att4Inactive;
	[HideInInspector] public RectTransform p1Att2Inactive;
	[HideInInspector] public RectTransform p2Att3Active;
	[HideInInspector] public RectTransform p2Att3aActive;
	[HideInInspector] public RectTransform p2Att4Active;
	[HideInInspector] public RectTransform p2Att1Inactive;
	[HideInInspector] public RectTransform p2Att2Inactive;
	[HideInInspector] public RectTransform p2Att3Inactive;
	[HideInInspector] public RectTransform p2Att3aInactive;
	[HideInInspector] public RectTransform p2Att4Inactive;
	[HideInInspector] public RectTransform p2Def1Active;
	[HideInInspector] public RectTransform p2Def2Active;
	[HideInInspector] public RectTransform p2Def1Inactive;
	[HideInInspector] public RectTransform p2Def2Inactive;

    public GameObject hitFxPool;
    public GameObject[] hitFx;

    public AudioSource bGMusic;
	public AudioSource attack1Voice;
	public AudioSource attack2Voice;
	public AudioSource attack3Voice;
	public AudioSource attack4Voice;
	public AudioSource attack5Voice;
	public AudioSource attack6Voice;
	public AudioSource attack7Voice;
	public AudioSource attack8Voice;
	public AudioSource pukulanVoice;
	public AudioSource awurawuranVoice;
	public AudioSource sapuJagatVoice;
	public AudioSource wataVoice;
	public AudioSource wawaVoice;
	public AudioSource wuuVoice;
	public AudioSource nightStrikeVoice;
	public AudioSource nightNightVoice;
	public AudioSource nightSurpriseVoice;
	public AudioSource punchSound;
	public AudioSource blockSound;
	public AudioSource jumpSound;
	public AudioSource hitSound;
	public AudioSource manyHitSound;
	public AudioSource swipSound;
	public AudioSource swooshSound;
	public AudioSource criticalSound;
	public AudioSource gongSound;
	public AudioSource fightSound;
	public AudioSource hihiVoice;
	public AudioSource waahVoice;
	public AudioSource ronAtt1Voice;
	public AudioSource ronAtt2Voice;
	public AudioSource abuketVoice;
	public AudioSource ketketbuketVoice;
	public AudioSource oYouCanVoice;
	public AudioSource waah2Voice;
	public AudioSource kbhAtt1Voice;
	public AudioSource kbhAtt2Voice;
	public AudioSource pukulanMautVoice;
	public AudioSource tendanganMautVoice;
	public AudioSource roboVoice;
	public AudioSource bioVoice;
	public AudioSource mantraVoice;
	public AudioSource brubahVoice;
	public AudioSource wukongAtt1Voice;
	public AudioSource wukongAtt2Voice;
	public AudioSource hawaVoice;
	public AudioSource buttonSound;

	public Image pausePanel;
	public Text pauseText;

	public Text p1Text;
	public Text p2Text;
	public Text hitText;

	[HideInInspector] public RectTransform att1Button;
	[HideInInspector] public RectTransform att2Button;
	[HideInInspector] public RectTransform att3Button;
	[HideInInspector] public RectTransform att3aButton;
	[HideInInspector] public RectTransform att4Button;
	[HideInInspector] public RectTransform def1Button;
	[HideInInspector] public RectTransform def2Button;
	[HideInInspector] public RectTransform cosmoButton;
	[HideInInspector] public RectTransform resumeButton;
	[HideInInspector] public RectTransform quitButton;
	
	//public AudioSource bGMusic;

	public int tournamentNumb;
	public int matchNumb;

	public bool rageMode = false;
	public bool p1Raging = false;
	public bool p2Raging = false;

	int p1Id = 0;
	int p2Id = 0;

	float readyToFightTimer = 80;
    float readyToFightTimerMax = 80;
    float fightStartTimer = 40;
    float fightStartTimerMax = 40;
    float p2ActionTimer = 40;
    float p2ActionTimerInit = 40;
    float addDefBarTimer = 100;
    float addDefBarTimerInit = 100;
	int p1RanAttack = 0;
	int p2RanAttack = 0;

    float strollingTimer = 200;
    float strollingTimerMax = 200;

	int attackVoice1 = 0;
	int attackVoice2 = 0;

	[HideInInspector] public float p1SAttack3Timer = 40;
	[HideInInspector] public float p1SAttack3TimerMax = 40;
	[HideInInspector] public float p2SAttack3Timer = 40;
	[HideInInspector] public float p2SAttack3TimerMax = 40;
	
	float p1HBarTrnmtX;
	
	float defPoint = 20f;
	float attPoint = 8f;
	float sAtt1Damage = 40f;
	float sAtt2Damage = 80f;
	float sAtt3Damage = 120f;
	

	[HideInInspector] public bool fight = false;
	[HideInInspector] public bool screenSrink = false;
	[HideInInspector] public bool screenEnlarge = false;
	[HideInInspector] public bool screenShut = false;
	bool opening = false;
	[HideInInspector] public bool fightStart = false;
	[HideInInspector] public bool fighting = false;
	bool p1MoveFwd = false;
	bool p2Movefwd = false;

	[HideInInspector] public bool p1SAttack1 = false;
	[HideInInspector] public bool p1SAttack2 = false;
	[HideInInspector] public bool p1SAttack3 = false;
	[HideInInspector] public bool p1SAttack4 = false;
	[HideInInspector] public bool p2SAttack1 = false;
	[HideInInspector] public bool p2SAttack2 = false;
	[HideInInspector] public bool p2SAttack3 = false;
	[HideInInspector] public bool p2SAttack4 = false;
	[HideInInspector] public bool p1Block = false;
	[HideInInspector] public bool p1Dodge = false;
	[HideInInspector] public bool p1HitTextFollow = false;
	[HideInInspector] public bool p2HitTextFollow = false;

	[HideInInspector] public bool p1SAttack3Start = false;
	[HideInInspector] public bool p2SAttack3Start = false;

	[HideInInspector] public bool strollingStart = false;

	
	RaycastHit hit;
	
	[HideInInspector] public Animator p1Anim;
	[HideInInspector] public Animator p2Anim;
	
	public GameObject loadingScene;
	public Image loadingBar;
	public Text loadingText;

	public int P1Id {
		
		get {
			return p1Id;
		}
		set {
			p1Id = value;
		}
	}

	public int P2Id {
		
		get {
			return p2Id;
		}
		set {
			p2Id = value;
		}
	}

	void Start () {

		matchNumb = PlayerPrefs.GetInt ("matchNumb");
		tournamentNumb = PlayerPrefs.GetInt ("tournamentNumb");
		rageMode = PlayerPrefs.GetInt ("rageMode") > 0;
//		p1Raging = PlayerPrefs.GetInt ("p1Raging") > 0;
//		p2Raging = PlayerPrefs.GetInt ("p2Raging") > 0;

		fight = true;
		opening = true;

		bGMusic.Play ();

		p1HBarTrnmtX = 300;
		
		loadingScene.SetActive (false);
		
		bambangScript= GameObject.Find ("Bambang").GetComponent<BambangScript> ();
		bonangScript = GameObject.Find ("Bonang").GetComponent<BonangScript> ();
		nkScript = GameObject.Find ("NK").GetComponent<NKScript> ();
		bambangRageScript = GameObject.Find ("BambangRage").GetComponent<BambangRageScript> ();
		ronScript = GameObject.Find ("Ron").GetComponent<RonScript> ();
		bambangCosmoScript = GameObject.Find ("BambangCosmo").GetComponent<BambangCosmoScript> ();
		
		LoadResources ();
		Initial ();

		cosmo.SetActive (false);

		hitText.text = " ";
		
		superScene.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
		
		//bambangAnim.SetBool ("Walk", false);
		
		p1HBar.sizeDelta = new Vector2 (p1HBarTrnmtX, p1HBar.rect.height);
		p2HBar.sizeDelta = new Vector2 (300, p2HBar.rect.height);
		p1AttBar.sizeDelta = new Vector2 (0, p1AttBar.rect.height);
		p1AttBar2.sizeDelta = new Vector2 (0, p1AttBar2.rect.height);
		p2AttBar.sizeDelta = new Vector2 (0, p2AttBar.rect.height);
		p2AttBar2.sizeDelta = new Vector2 (0, p2AttBar2.rect.height);
		p1DefBar.sizeDelta = new Vector2 (0, p1DefBar.rect.height);
		p2DefBar.sizeDelta = new Vector2 (0, p2DefBar.rect.height);

		if (tournamentNumb == 1) {
			if (matchNumb == 1) {
				FightersInactive ();
				bonang.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "BUDI";
				p1Id = 1;
				p2Id = 3;
				bonang.transform.position = new Vector3 (4, 0, 0);
			} else if (matchNumb == 2) {
				FightersInactive ();
				nk.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "NIGHT KNIGHT";
				p1Id = 1;
				p2Id = 4;
			} else {
				FightersInactive ();
				p1Text.text = "BAMBANG";
				p2Text.text = "???";
				p1Id = 1;
				p2Id = 0;
			}
		} else if (tournamentNumb == 2) {
			if (matchNumb == 1) {
				FightersInactive ();
				bonang.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "BUDI";
				p1Id = 1;
				p2Id = 3;
				bonang.transform.position = new Vector3 (4, 0, 0);
			} else if (matchNumb == 2) {
				FightersInactive ();
				nk.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "NIGHT KNIGHT";
				p1Id = 1;
				p2Id = 4;
			} else if (matchNumb == 3) {
				FightersInactive ();
				ron.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "RON";
				p1Id = 1;
				p2Id = 5;
				ron.transform.position = new Vector3 (4, 0, 0);
			} else {
				FightersInactive ();
				p1Text.text = "BAMBANG";
				p2Text.text = "???";
				p1Id = 1;
				p2Id = 0;
			}
		} else if (tournamentNumb == 3) {
			if (matchNumb == 1) {
				FightersInactive ();
				bonang.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "BUDI";
				p1Id = 1;
				p2Id = 3;
				bonang.transform.position = new Vector3 (4, 0, 0);
			} else if (matchNumb == 2) {
				FightersInactive ();
				nk.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "NIGHT KNIGHT";
				p1Id = 1;
				p2Id = 4;
			} else if (matchNumb == 3) {
				FightersInactive ();
				ron.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "RON";
				p1Id = 1;
				p2Id = 5;
				ron.transform.position = new Vector3 (4, 0, 0);
			} else if (matchNumb == 4) {
				FightersInactive ();
				kbh.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "KBH";
				p1Id = 1;
				p2Id = 6;
				kbh.transform.position = new Vector3 (4, 0, 0);
				p2Raging = true;
				mantraVoice.Play ();
			} else {
				FightersInactive ();
				p1Text.text = "BAMBANG";
				p2Text.text = "???";
				p1Id = 1;
				p2Id = 0;
			}
		} else if (tournamentNumb == 4) {
			if (matchNumb == 1) {
				FightersInactive ();
				bonang.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "BUDI";
				p1Id = 1;
				p2Id = 3;
				bonang.transform.position = new Vector3 (4, 0, 0);
			} else if (matchNumb == 2) {
				FightersInactive ();
				nk.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "NIGHT KNIGHT";
				p1Id = 1;
				p2Id = 4;
			} else if (matchNumb == 3) {
				FightersInactive ();
				ron.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "RON";
				p1Id = 1;
				p2Id = 5;
				ron.transform.position = new Vector3 (4, 0, 0);
			} else if (matchNumb == 4) {
				FightersInactive ();
				kbh.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "KBH";
				p1Id = 1;
				p2Id = 6;
				kbh.transform.position = new Vector3 (4, 0, 0);
				p2Raging = true;
				mantraVoice.Play ();
			} else if (matchNumb == 5) {
				FightersInactive ();
				sunWukong.SetActive (true);
				p1Text.text = "BAMBANG";
				p2Text.text = "SUN WUKONG";
				p1Id = 1;
				p2Id = 7;
			} else {
				FightersInactive ();
				p1Text.text = "BAMBANG";
				p2Text.text = "???";
				p1Id = 1;
				p2Id = 0;
			}
		} else {
			FightersInactive ();
			p1Text.text = "BAMBANG";
			p2Text.text = "???";
			p1Id = 1;
			p2Id = 0;
		}

		LoadPlayers ();

		blackTop.transform.position = new Vector3 (blackTop.transform.position.x, 4.3f, blackTop.transform.position.z);
		blackBottom.transform.position = new Vector3 (blackBottom.transform.position.x, -4.3f, blackBottom.transform.position.z);

		screenEnlarge = true;

		gongSound.Play ();
		
	}
	
	void Update () {

		print ("Tournament " + tournamentNumb);
		print ("p2Id " + p2Id);

		//LoadActions ();

		//FightScene ();

		LoadPlayers ();
		
		PlayerPrefs.SetInt ("matchNumb", matchNumb);
		PlayerPrefs.SetInt ("tournamentNumb", tournamentNumb);
		PlayerPrefs.SetFloat ("p1HBarX", p1HBar.rect.width);
		PlayerPrefs.SetInt ("rageMode", rageMode ? 1 : 0);
//		PlayerPrefs.SetInt ("p1Raging", p1Raging ? 1 : 0);
//		PlayerPrefs.SetInt ("p2Raging", p2Raging ? 1 : 0);
		//PlayerPrefs.SetInt ("registered", registered ? 1 : 0);
		
		//p1HBar.sizeDelta = new Vector2 (p1HBarX, p1HBar.rect.height);
		
		if (Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale = 0;
			resumeButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, 0);
			quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -50f);
			pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			pauseText.text = "PAUSE";
			
		}

		if (Time.timeScale != 0) {

			if (superScene.GetComponent<SpriteRenderer> ().color.a > 0.1f && superScene.GetComponent<SpriteRenderer> ().color.a <= 0.8f) { // --- Super Scene
				if (p1SAttack1 || p1SAttack2 || p1SAttack3 || p1SAttack4) {
					p1Anim.SetInteger ("FightMove", 17);
				}
				if (p2SAttack1 || p2SAttack2 || p2SAttack3 || p2SAttack4) {
					p2Anim.SetInteger ("FightMove", 17);
				}
			}
		
			if (blackTop.transform.position.y < 4.3f && blackTop.transform.position.y > 4.2f) {

				blackTop.transform.position = new Vector3 (blackTop.transform.position.x, 4.2f, blackTop.transform.position.z);
				blackBottom.transform.position = new Vector3 (blackBottom.transform.position.x, -4.2f, blackBottom.transform.position.z);

				if ((p2Id == 4 && PlayerPrefs.GetInt ("p1Lost") == 0 && PlayerPrefs.GetInt ("tournamentNumb") == 1) || 
					(p2Id == 5 && PlayerPrefs.GetInt ("p1Lost") == 0 && PlayerPrefs.GetInt ("tournamentNumb") == 2) || 
					(p2Id == 6 && PlayerPrefs.GetInt ("p1Lost") == 0 && PlayerPrefs.GetInt ("tournamentNumb") == 3) || 
					(p2Id == 7 && PlayerPrefs.GetInt ("p1Lost") == 0 && PlayerPrefs.GetInt ("tournamentNumb") == 4)) {
					LoadLevelNext ();
				} else {
					LoadLevel ();
					PlayerPrefs.SetInt ("patrickAppear", 1);
					PlayerPrefs.SetInt ("fromTour", 1);
				}
			
			}
		
			if (screenSrink) {
				ScreenSrinking ();
			}
		
			if (screenEnlarge) {
				ScreenEnlarging ();
			}
		
			if (screenShut) {
				ScreenShutting ();
			}

			// --- Fight Opening ---
			if (opening) {
                readyToFightTimer -= Time.deltaTime * 80f;

				if (p1Id == 1) {
					p1Anim.SetInteger ("FightMove", 1);
				}
				if (p2Id != 4) {
					p2Anim.SetInteger ("FightMove", 1);
				} else if (p2Id == 4) {
					p2Anim.SetInteger ("FightMove", 19);
					player2.transform.position = new Vector3 (4f, player2.transform.position.y + (0 - player2.transform.position.y) * 0.1f, 0);

					if (jumpSound.isPlaying == false) {
						jumpSound.Play ();
					}

					if (player2.transform.position.y < 0.8f) {
						player2.transform.position = new Vector3 (4f, 0, 0);
					}
				}

				p2HBar.sizeDelta = new Vector2 (300, p2HBar.rect.height);
				p1AttBar.sizeDelta = new Vector2 (0, p1AttBar.rect.height);
				p1AttBar2.sizeDelta = new Vector2 (0, p1AttBar2.rect.height);
				p2AttBar.sizeDelta = new Vector2 (0, p2AttBar.rect.height);
				p1DefBar.sizeDelta = new Vector2 (0, p1DefBar.rect.height);
				p2DefBar.sizeDelta = new Vector2 (0, p2DefBar.rect.height);
			}

			if (readyToFightTimer <= 60f && readyToFightTimer > 50f) {

				if (p2Id == 4) {
					p2Anim.SetInteger ("FightMove", 1);
				}
			}
		
			if (readyToFightTimer <= 0) {
				opening = false;
				readyToFightTimer = readyToFightTimerMax;

				p1Anim.SetInteger ("FightMove", 2);
				p2Anim.SetInteger ("FightMove", 2);
				fightStart = true;
                hitFxPool.SetActive(true);
            }
		
			if (fightStart) {
                fightStartTimer -= Time.deltaTime * 80f;
			
				FightScene ();
			}
		
			if (fightStartTimer <= 0) {
				fightStart = false;
				fightStartTimer = fightStartTimerMax;
				p1MoveFwd = true;
			}

			if (p1MoveFwd) {
				player1.transform.position = new Vector3 (player1.transform.position.x + ((-1f - player1.transform.position.x) * 0.4f), player1.transform.position.y, player1.transform.position.z);
				player2.transform.position = new Vector3 (player2.transform.position.x + ((1f - player2.transform.position.x) * 0.4f), player2.transform.position.y, player2.transform.position.z);
				p1Anim.SetInteger ("FightMove", 3);
				p2Anim.SetInteger ("FightMove", 3);
			}
		
			if (player1.transform.position.x > -1.1f && p1MoveFwd) {
				Instantiate (Resources.Load ("Prefabs/PunchClash1"), new Vector3 (0, -1, 0), Quaternion.identity);
				punchSound.Play ();
				p1AttBar.sizeDelta = new Vector2 (p1AttBar.rect.width + attPoint, p1AttBar.rect.height);
				p2AttBar.sizeDelta = new Vector2 (p2AttBar.rect.width + attPoint, p2AttBar.rect.height);
				p1DefBar.sizeDelta = new Vector2 (p1DefBar.rect.width + defPoint, p1DefBar.rect.height);
				p2DefBar.sizeDelta = new Vector2 (p2DefBar.rect.width + defPoint, p2DefBar.rect.height);
			
				player1.transform.position = new Vector3 (-1.95f, player1.transform.position.y, player1.transform.position.z);
				player2.transform.position = new Vector3 (1.95f, player2.transform.position.y, player2.transform.position.z);
			
				p1Anim.SetInteger ("FightMove", 2);
				p2Anim.SetInteger ("FightMove", 2);
				p1MoveFwd = false;
				fighting = true;
			}
		
			if (p2ActionTimer <= (p2ActionTimerInit - 10) && p2ActionTimer > (p2ActionTimerInit - 11) && fighting) {
				p1Anim.SetInteger ("FightMove", 2);
				p2Anim.SetInteger ("FightMove", 2);
				player1.transform.position = new Vector3 (player1.transform.position.x + ((-2f - player1.transform.position.x) * 0.5f), player1.transform.position.y, player1.transform.position.z);
				player2.transform.position = new Vector3 (player2.transform.position.x + ((2f - player2.transform.position.x) * 0.5f), player2.transform.position.y, player2.transform.position.z);
			}
		
			if (fighting) {

                p2ActionTimer -= Time.deltaTime * 80f;
                addDefBarTimer -= Time.deltaTime * 80f;

                if (addDefBarTimer <= 0) {
					p1DefBar.sizeDelta = new Vector2 (p1DefBar.rect.width + defPoint, p1DefBar.rect.height);
					p2DefBar.sizeDelta = new Vector2 (p2DefBar.rect.width + defPoint, p2DefBar.rect.height);
					addDefBarTimer = addDefBarTimerInit;
				}
			
				if (p2ActionTimer <= 0) {
					p1Anim.SetInteger ("FightMove", 5);
					if (!p2Raging && p2Id != 7) {
						p2Anim.SetInteger ("FightMove", Random.Range (6, 10));
					} else if (p2Raging || p2Id == 7) {
						p2Anim.SetInteger ("FightMove", Random.Range (6, 8));
					}

					attackVoice2 = Random.Range (1, 3);

					if (p2Id == 3) {
						if (attackVoice2 == 1 && attack3Voice.isPlaying == false) {
							attack3Voice.Play ();
						}
						if (attackVoice2 == 2 && attack4Voice.isPlaying == false) {
							attack4Voice.Play ();
						}
					} else if (p2Id == 4) {
						if (p2Anim.GetInteger ("FightMove") == 6 && attack5Voice.isPlaying == false) {
							attack5Voice.Play ();
						}
						if (p2Anim.GetInteger ("FightMove") == 7 && attack6Voice.isPlaying == false) {
							attack6Voice.Play ();
						}
						if (p2Anim.GetInteger ("FightMove") == 8 && attack7Voice.isPlaying == false) {
							attack7Voice.Play ();
						}
						if (p2Anim.GetInteger ("FightMove") == 9 && attack8Voice.isPlaying == false) {
							attack8Voice.Play ();
						}
					} else if (p2Id == 5) {
						if (attackVoice2 == 1 && ronAtt1Voice.isPlaying == false) {
							ronAtt1Voice.Play ();
						}
						if (attackVoice2 == 2 && ronAtt2Voice.isPlaying == false) {
							ronAtt2Voice.Play ();
						}
					} else if (p2Id == 6) {
						if (attackVoice2 == 1 && kbhAtt1Voice.isPlaying == false) {
							kbhAtt1Voice.Play ();
						}
						if (attackVoice2 == 2 && kbhAtt2Voice.isPlaying == false) {
							kbhAtt2Voice.Play ();
						}
					} else if (p2Id == 7) {
						if (attackVoice2 == 1 && wukongAtt1Voice.isPlaying == false) {
							wukongAtt1Voice.Play ();
						}
						if (attackVoice2 == 2 && wukongAtt2Voice.isPlaying == false) {
							wukongAtt2Voice.Play ();
						}
					}

					blockSound.Play ();

					if (p2Id == 4 && p2Anim.GetInteger ("FightMove") == 8) {
						p1DefBar.sizeDelta = new Vector2 (p1DefBar.rect.width - (defPoint), p1DefBar.rect.height);
					} else {
						p1DefBar.sizeDelta = new Vector2 (p1DefBar.rect.width - (defPoint / 2), p1DefBar.rect.height);
					}
					if (!p2Raging && p2Id != 7) {
						p2AttBar.sizeDelta = new Vector2 (p2AttBar.rect.width + attPoint, p2AttBar.rect.height);
					} else if (p2Raging || p2Id == 7) {
						p2AttBar2.sizeDelta = new Vector2 (p2AttBar2.rect.width + attPoint, p2AttBar2.rect.height);
					}
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-1f - player1.transform.position.x) * 0.5f), player1.transform.position.y, Random.Range (-0.01f, 0.02f));
					player2.transform.position = new Vector3 (player2.transform.position.x + ((1f - player2.transform.position.x) * 0.5f), player2.transform.position.y, Random.Range (-0.01f, 0.02f));
					Instantiate (Resources.Load ("Prefabs/PunchClash2"), new Vector3 (0, -1, 0), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (-1, -1, 0), Quaternion.identity);
					p2ActionTimer = p2ActionTimerInit;
				}
			
				if (Input.GetMouseButtonDown (0)) {
				
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                    for (int i = 0; i < hitFx.Length; i++)
                    {
                        if (!hitFx[i].GetComponent<Animation>().isPlaying)
                        {
                            hitFx[i].transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                            hitFx[i].GetComponent<Animation>().Play();
                            break;
                        }
                    }

                    if (Physics.Raycast (ray, out hit)) {
						if (hit.collider.gameObject.name == ("ClickArea")) {
						
							p2ActionTimer = p2ActionTimerInit;
							if (!p1Raging && !cosmo.activeSelf) {
								p1RanAttack = Random.Range (6, 10);
							} else {
								p1RanAttack = Random.Range (6, 8);
							}
							p2RanAttack = Random.Range (5, 10);
						
							if (p2RanAttack == 5) {
								p2RanAttack = Random.Range (1, 3);
								if (p2RanAttack == 1) {
									p2RanAttack = 5;
								} else {
									p2RanAttack = Random.Range (5, 10);
								}
							}
						
							p1Anim.SetInteger ("FightMove", p1RanAttack);
							p2Anim.SetInteger ("FightMove", p2RanAttack);

							if (!p1Raging) {
								attackVoice1 = Random.Range (1, 3);
								attackVoice2 = Random.Range (1, 3);

								if (attackVoice1 == 1 && attack1Voice.isPlaying == false) {
									attack1Voice.Play ();
								}
								if (attackVoice1 == 2 && attack2Voice.isPlaying == false) {
									attack2Voice.Play ();
								}
							}

							if (p2Id == 3) {
								if (attackVoice2 == 1 && attack3Voice.isPlaying == false) {
									attack3Voice.Play ();
								}
								if (attackVoice2 == 2 && attack4Voice.isPlaying == false) {
									attack4Voice.Play ();
								}
							} else if (p2Id == 4) {
								if (p2Anim.GetInteger ("FightMove") == 6 && attack5Voice.isPlaying == false) {
									attack5Voice.Play ();
								}
								if (p2Anim.GetInteger ("FightMove") == 7 && attack6Voice.isPlaying == false) {
									attack6Voice.Play ();
								}
								if (p2Anim.GetInteger ("FightMove") == 8 && attack7Voice.isPlaying == false) {
									attack7Voice.Play ();
								}
								if (p2Anim.GetInteger ("FightMove") == 9 && attack8Voice.isPlaying == false) {
									attack8Voice.Play ();
								}
							} else if (p2Id == 5) {
								if (attackVoice2 == 1 && ronAtt1Voice.isPlaying == false) {
									ronAtt1Voice.Play ();
								}
								if (attackVoice2 == 2 && ronAtt2Voice.isPlaying == false) {
									ronAtt2Voice.Play ();
								}
							} else if (p2Id == 6) {
								if (attackVoice2 == 1 && kbhAtt1Voice.isPlaying == false) {
									kbhAtt1Voice.Play ();
								}
								if (attackVoice2 == 2 && kbhAtt2Voice.isPlaying == false) {
									kbhAtt2Voice.Play ();
								}
							} else if (p2Id == 7) {
								if (attackVoice2 == 1 && wukongAtt1Voice.isPlaying == false) {
									wukongAtt1Voice.Play ();
								}
								if (attackVoice2 == 2 && wukongAtt2Voice.isPlaying == false) {
									wukongAtt2Voice.Play ();
								}
							}

							player1.transform.position = new Vector3 (player1.transform.position.x + ((-1f - player1.transform.position.x) * 0.5f), player1.transform.position.y, Random.Range (-0.01f, 0.02f));
							player2.transform.position = new Vector3 (player2.transform.position.x + ((1f - player2.transform.position.x) * 0.5f), player2.transform.position.y, Random.Range (-0.01f, 0.02f));
						
							p1AttBar.sizeDelta = new Vector2 (p1AttBar.rect.width + attPoint, p1AttBar.rect.height);
							p1AttBar2.sizeDelta = new Vector2 (p1AttBar2.rect.width + attPoint, p1AttBar2.rect.height);
						
							if (p2RanAttack > 5 && p2RanAttack < 10) {
								if (!p2Raging && p2Id != 7) {
									p2AttBar.sizeDelta = new Vector2 (p2AttBar.rect.width + attPoint, p2AttBar.rect.height);
								} else  if (p2Raging || p2Id == 7) {
									p2AttBar2.sizeDelta = new Vector2 (p2AttBar2.rect.width + attPoint, p2AttBar2.rect.height);
								}
								punchSound.Play ();
							}
						
							if (p2RanAttack == 5) {
								p2DefBar.sizeDelta = new Vector2 (p2DefBar.rect.width - (defPoint / 2), p2DefBar.rect.height);
								Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (1, -1, 0), Quaternion.identity);
								blockSound.Play ();
							}

							if (!p1Raging && p2Id == 4 && p2RanAttack == 8 && p1HBar.GetComponent<RectTransform> ().rect.width >= 10 &&
								!cosmo.activeSelf) {
								p1Anim.SetInteger ("FightMove", 13);
								p1HBar.sizeDelta = new Vector2 (p1HBar.rect.width - 2, p1HBar.rect.height);
							}

							if (p1Raging && p2RanAttack != 5 && p2HBar.GetComponent<RectTransform> ().rect.width >= 10 &&
								!cosmo.activeSelf) {
								if ((p2Id == 4 && p2RanAttack == 8) || p2Raging || p2Id == 7) {
									p2HBar.sizeDelta = new Vector2 (p2HBar.rect.width, p2HBar.rect.height);
								} else {
									p2Anim.SetInteger ("FightMove", 13);
									p2HBar.sizeDelta = new Vector2 (p2HBar.rect.width - 2, p2HBar.rect.height);
								}
							}

							if (!p1Raging && p2Raging && p2Id != 6 && p1HBar.GetComponent<RectTransform> ().rect.width >= 10 &&
								!cosmo.activeSelf) {
								p1Anim.SetInteger ("FightMove", 13);
								p1HBar.sizeDelta = new Vector2 (p1HBar.rect.width - 2, p1HBar.rect.height);
							}

							if (cosmo.activeSelf && p2RanAttack != 5 && p2Id != 6 && p2Id != 7 && p2HBar.GetComponent<RectTransform> ().rect.width >= 10) {
								p2Anim.SetInteger ("FightMove", 13);
								p2HBar.sizeDelta = new Vector2 (p2HBar.rect.width - 2, p2HBar.rect.height);
							}

							if (p2Id == 7 && !cosmo.activeSelf) {
								p1Anim.SetInteger ("FightMove", 13);
								p1HBar.sizeDelta = new Vector2 (p1HBar.rect.width - 2, p1HBar.rect.height);
							}
						
						}
					}
				
				}
		
				if (Input.GetMouseButtonUp (0)) {
					Instantiate (Resources.Load ("Prefabs/PunchClash2"), new Vector3 (0, -1, 0), Quaternion.identity);
					p1Anim.SetInteger ("FightMove", 2);
					p2Anim.SetInteger ("FightMove", 2);
				
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-2f - player1.transform.position.x) * 0.5f), player1.transform.position.y, player1.transform.position.z);
					player2.transform.position = new Vector3 (player2.transform.position.x + ((2f - player2.transform.position.x) * 0.5f), player2.transform.position.y, player2.transform.position.z);
				}

			}

			if (p1HBar.rect.width <= 0) {
				p1HBar.sizeDelta = new Vector2 (0, p1HBar.rect.height);
			}
			if (p2HBar.rect.width <= 0) {
				p2HBar.sizeDelta = new Vector2 (0, p2HBar.rect.height);
			}
			if (p1AttBar.rect.width >= 300) {
				p1AttBar.sizeDelta = new Vector2 (300, p1AttBar.rect.height);
			}
			if (p1AttBar2.rect.width >= 200) {
				p1AttBar2.sizeDelta = new Vector2 (200, p1AttBar2.rect.height);
			}
			if (p2AttBar2.rect.width >= 200) {
				p2AttBar2.sizeDelta = new Vector2 (200, p2AttBar2.rect.height);
			}
			if (p2AttBar.rect.width >= 300) {
				p2AttBar.sizeDelta = new Vector2 (300, p2AttBar.rect.height);
			}
			if (p1DefBar.rect.width >= 200) {
				p1DefBar.sizeDelta = new Vector2 (200, p1DefBar.rect.height);
			}
			if (p2DefBar.rect.width >= 200) {
				p2DefBar.sizeDelta = new Vector2 (200, p2DefBar.rect.height);
			}
			if (p1DefBar.rect.width <= 0) {
				p1DefBar.sizeDelta = new Vector2 (0, p1DefBar.rect.height);
			}
			if (p2DefBar.rect.width <= 0) {
				p2DefBar.sizeDelta = new Vector2 (0, p2DefBar.rect.height);
			}

			if (p1Raging) {
				p1AttBarFrame.anchoredPosition = new Vector2 (p1AttBarFrame.anchoredPosition.x, -70f);
				att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, -50f);
				att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, -50f);
				att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, -50f);
				p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, -50f);
				p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, -50f);
				p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, -50f);
			}

			if (cosmo.activeSelf) {
				p1AttBarFrame.anchoredPosition = new Vector2 (p1AttBarFrame.anchoredPosition.x, -10f);
				att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, -50f);
				att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, -50f);
				att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, -50f);
				att3aButton.anchoredPosition = new Vector2 (att3aButton.anchoredPosition.x, -50f);
				p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, -50f);
				p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, -50f);
				p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, -50f);
				p1Att3aInactive.anchoredPosition = new Vector2 (p1Att3aInactive.anchoredPosition.x, -50f);
			}

			if (p2Raging) {
				p2AttBarFrame.anchoredPosition = new Vector2 (p2AttBarFrame.anchoredPosition.x, -70f);
				p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, -50f);
				p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, -50f);
				p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, -50f);
				p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, -50f);
				p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, -50f);
				p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, -50f);
			}

			if (p2Id == 7) {
				p2AttBarFrame.anchoredPosition = new Vector2 (p2AttBarFrame.anchoredPosition.x, -70f);
				p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, -50f);
				p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, -50f);
				p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, -50f);
				p2Att3aActive.anchoredPosition = new Vector2 (p2Att3aActive.anchoredPosition.x, -50f);
				p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, -50f);
				p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, -50f);
				p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, -50f);
				p2Att3aInactive.anchoredPosition = new Vector2 (p2Att3aInactive.anchoredPosition.x, -50f);
			}
		
			if (p1AttBar.rect.width < 100 && fighting && !p1Raging && !cosmo.activeSelf) {
				att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, -50f);
				att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, -50f);
				att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, -50f);
				p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, 32f);
				p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, 32f);
				p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, 32f);
			}
		
			if (p1AttBar.rect.width >= 100 && p1AttBar.rect.width < 200 && fighting && !p1Raging && !cosmo.activeSelf) {
				att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, 32f);
				att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, -50f);
				att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, -50f);
				p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, -50f);
				p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, 32f);
				p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, 32f);
			}
		
			if (p1AttBar.rect.width >= 200 && p1AttBar.rect.width < 300 && fighting && !p1Raging && !cosmo.activeSelf) {
				att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, 32f);
				att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, 32f);
				att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, -50f);
				p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, -50f);
				p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, -50f);
				p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, 32f);
			}
		
			if (p1AttBar.rect.width >= 300 && fighting && !p1Raging && !cosmo.activeSelf) {
				att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, 32f);
				att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, 32f);
				att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, 32f);
				p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, -50f);
				p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, -50f);
				p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, -50f);
			}

			if (p1AttBar2.rect.width < 100 && fighting && p1Raging) {
				att3aButton.anchoredPosition = new Vector2 (att3aButton.anchoredPosition.x, -50f);
				att4Button.anchoredPosition = new Vector2 (att4Button.anchoredPosition.x, -50f);
				p1Att3aInactive.anchoredPosition = new Vector2 (p1Att3aInactive.anchoredPosition.x, 32f);
				p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, 32f);
			}

			if (p1AttBar2.rect.width >= 100 && p1AttBar2.rect.width < 200 && fighting && p1Raging) {
				att3aButton.anchoredPosition = new Vector2 (att3aButton.anchoredPosition.x, 32f);
				att4Button.anchoredPosition = new Vector2 (att4Button.anchoredPosition.x, -50f);
				p1Att3aInactive.anchoredPosition = new Vector2 (p1Att3aInactive.anchoredPosition.x, -50f);
				p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, 32f);
			}

			if (p1AttBar2.rect.width >= 200 && fighting && p1Raging) {
				att3aButton.anchoredPosition = new Vector2 (att3aButton.anchoredPosition.x, 32f);
				att4Button.anchoredPosition = new Vector2 (att4Button.anchoredPosition.x, 32f);
				p1Att3aInactive.anchoredPosition = new Vector2 (p1Att3aInactive.anchoredPosition.x, -50f);
				p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, -50f);
			}

			if (p1AttBar2.rect.width < 200 && fighting && cosmo.activeSelf) {
				att4Button.anchoredPosition = new Vector2 (att4Button.anchoredPosition.x, -50f);
				p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, 32f);
			}
		
			if (p1AttBar2.rect.width >= 200 && fighting && cosmo.activeSelf) {
				att4Button.anchoredPosition = new Vector2 (att4Button.anchoredPosition.x, 32f);
				p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, -50f);
			}
		
			if (p1DefBar.rect.width < 100 && fighting) {
				def1Button.anchoredPosition = new Vector2 (def1Button.anchoredPosition.x, 50f);
				def2Button.anchoredPosition = new Vector2 (def2Button.anchoredPosition.x, 50f);
				p1Def1Inactive.anchoredPosition = new Vector2 (p1Def1Inactive.anchoredPosition.x, -72f);
				p1Def2Inactive.anchoredPosition = new Vector2 (p1Def2Inactive.anchoredPosition.x, -72f);
			}
		
			if (p1DefBar.rect.width >= 100 && p1DefBar.rect.width < 200 && fighting) {
				if (!p2SAttack3) {
					def1Button.anchoredPosition = new Vector2 (def1Button.anchoredPosition.x, -72f);
				}
				def2Button.anchoredPosition = new Vector2 (def2Button.anchoredPosition.x, 50f);
				p1Def1Inactive.anchoredPosition = new Vector2 (p1Def1Inactive.anchoredPosition.x, 50f);
				p1Def2Inactive.anchoredPosition = new Vector2 (p1Def2Inactive.anchoredPosition.x, -72f);
			}
		
			if (p1DefBar.rect.width >= 200 && fighting) {
				if (!p2SAttack3) {
					def1Button.anchoredPosition = new Vector2 (def1Button.anchoredPosition.x, -72f);
				}
				def2Button.anchoredPosition = new Vector2 (def2Button.anchoredPosition.x, -72f);
				p1Def1Inactive.anchoredPosition = new Vector2 (p1Def1Inactive.anchoredPosition.x, 50f);
				p1Def2Inactive.anchoredPosition = new Vector2 (p1Def2Inactive.anchoredPosition.x, 50f);
			}
		
			if (p2AttBar.rect.width < 100 && fighting && !p2Raging && p2Id != 7) {
				p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, -50f);
				p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, -50f);
				p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, -50f);
				p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, 32f);
				p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, 32f);
				p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, 32f);
			}
		
			if (p2AttBar.rect.width >= 100 && p2AttBar.rect.width < 200 && fighting && !p2Raging && p2Id != 7) {
				p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, 32f);
				p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, -50f);
				p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, -50f);
				p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, -50f);
				p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, 32f);
				p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, 32f);
			}
		
			if (p2AttBar.rect.width >= 200 && p2AttBar.rect.width < 300 && fighting && !p2Raging && p2Id != 7) {
				p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, 32f);
				p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, 32f);
				p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, -50f);
				p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, -50f);
				p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, -50f);
				p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, 32f);
			}
		
			if (p2AttBar.rect.width >= 300 && fighting && !p2Raging && p2Id != 7) {
				p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, 32f);
				p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, 32f);
				p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, 32f);
				p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, -50f);
				p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, -50f);
				p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, -50f);
			}

			if (p2AttBar2.rect.width < 100 && fighting && p2Raging && p2Id != 7) {
				p2Att3aActive.anchoredPosition = new Vector2 (p2Att3aActive.anchoredPosition.x, -50f);
				p2Att4Active.anchoredPosition = new Vector2 (p2Att4Active.anchoredPosition.x, -50f);
				p2Att3aInactive.anchoredPosition = new Vector2 (p2Att3aInactive.anchoredPosition.x, 32f);
				p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, 32f);
			}
		
			if (p2AttBar2.rect.width >= 100 && p2AttBar2.rect.width < 200 && fighting && p2Raging && p2Id != 7) {
				p2Att3aActive.anchoredPosition = new Vector2 (p2Att3aActive.anchoredPosition.x, 32f);
				p2Att4Active.anchoredPosition = new Vector2 (p2Att4Active.anchoredPosition.x, -50f);
				p2Att3aInactive.anchoredPosition = new Vector2 (p2Att3aInactive.anchoredPosition.x, -50f);
				p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, 32f);
			}
		
			if (p2AttBar2.rect.width >= 200 && fighting && p2Raging && p2Id != 7) {
				p2Att3aActive.anchoredPosition = new Vector2 (p2Att3aActive.anchoredPosition.x, 32f);
				p2Att4Active.anchoredPosition = new Vector2 (p2Att4Active.anchoredPosition.x, 32f);
				p2Att3aInactive.anchoredPosition = new Vector2 (p2Att3aInactive.anchoredPosition.x, -50f);
				p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, -50f);
			}

			if (p2AttBar2.rect.width < 200 && fighting && !p2Raging && p2Id == 7) {
				p2Att4Active.anchoredPosition = new Vector2 (p2Att4Active.anchoredPosition.x, -50f);
				p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, 32f);
			}

			if (p2AttBar2.rect.width >= 200 && fighting && !p2Raging && p2Id == 7) {
				p2Att4Active.anchoredPosition = new Vector2 (p2Att4Active.anchoredPosition.x, 32f);
				p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, -50f);
			}
		
			if (p2DefBar.rect.width < 100 && fighting) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, 50f);
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, 50f);
				p2Def1Inactive.anchoredPosition = new Vector2 (p2Def1Inactive.anchoredPosition.x, -72f);
				p2Def2Inactive.anchoredPosition = new Vector2 (p2Def2Inactive.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 100 && p2DefBar.rect.width < 200 && fighting) {
				if (!bambangScript.SAttack3 || !bambangRageScript.SAttack4) {
					p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				}
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, 50f);
				p2Def1Inactive.anchoredPosition = new Vector2 (p2Def1Inactive.anchoredPosition.x, 50f);
				p2Def2Inactive.anchoredPosition = new Vector2 (p2Def2Inactive.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 200 && fighting) {
				if (!bambangScript.SAttack3 || !bambangRageScript.SAttack4) {
					p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				}
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, -72f);
				p2Def1Inactive.anchoredPosition = new Vector2 (p2Def1Inactive.anchoredPosition.x, 50f);
				p2Def2Inactive.anchoredPosition = new Vector2 (p2Def2Inactive.anchoredPosition.x, 50f);
			}

			if (bambangScript.SAttack3 || bambangRageScript.SAttack3 || bambangRageScript.SAttack4 || bambangCosmoScript.SAttack3 || bambangCosmoScript.SAttack4) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, 50f);
			}

			if (p2Id != 6) {
				if (p2SAttack3 || p2SAttack4) {
					def1Button.anchoredPosition = new Vector2 (def1Button.anchoredPosition.x, 50f);
				}
			}

			// --- Entering strolling mode from fighting mode ---
			if (strollingStart) {
                strollingTimer -= Time.deltaTime * 50f;
            }
		
			if (strollingTimer <= 0) {
				strollingStart = false;

				if (p1HBar.GetComponent<RectTransform> ().rect.width <= 0 && rageMode && !p1Raging) {
					waahVoice.Play ();
					swipSound.Play ();
					hihiVoice.Play ();
					p1HBar.sizeDelta = new Vector2 (p1HBarTrnmtX, p1HBar.rect.height);
					p1AttBar2.sizeDelta = new Vector2 (0, p1AttBar2.rect.height);
					p1Raging = true;
					bambangRage.SetActive (true);
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (player1.transform.position.x, player1.transform.position.y - 1, player1.transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/EnergyBurst2"), new Vector3 (player1.transform.position.x, player1.transform.position.y - 1, player1.transform.position.z), Quaternion.identity);
					bambangRage.transform.position = new Vector3 (bambang.transform.position.x, bambang.transform.position.y, bambang.transform.position.z);
					bambang.SetActive (false);

				} else if (p2Id == 5 && p2HBar.GetComponent<RectTransform> ().rect.width <= 0 && !p2Raging) {
					waah2Voice.Play ();
					swipSound.Play ();
					p2HBar.sizeDelta = new Vector2 (p1HBarTrnmtX, p2HBar.rect.height);
					p2AttBar2.sizeDelta = new Vector2 (0, p2AttBar2.rect.height);
					p2Raging = true;
					ronRage.SetActive (true);
					Instantiate (Resources.Load ("Prefabs/EnergyBurst"), new Vector3 (player2.transform.position.x, player2.transform.position.y - 1, player2.transform.position.z), Quaternion.identity);
					ronRage.transform.position = new Vector3 (ron.transform.position.x, ron.transform.position.y, ron.transform.position.z);
					ron.SetActive (false);
				
				} else {
					screenShut = true;
					screenEnlarge = false;
					Initial ();
					fight = false;
				}
			
				strollingTimer = strollingTimerMax;
			}

		}
		
	}
	
	public void LoadResources (){
		
		bambang = GameObject.Find ("Bambang");
		bonang = GameObject.Find ("Bonang");
		nk = GameObject.Find ("NK");
		ron = GameObject.Find ("Ron");
		kbh = GameObject.Find ("KBH");
		sunWukong = GameObject.Find ("SunWukong");
		bambangRage = GameObject.Find ("BambangRage");
		ronRage = GameObject.Find ("RonRage");
		kbhRage = GameObject.Find ("KBHRage");
		bambangCosmo = GameObject.Find ("BambangCosmo");
		cosmo = GameObject.Find ("Cosmo");

		blackTop = GameObject.Find ("BlackTop");
		blackBottom = GameObject.Find ("BlackBottom");
		superScene = GameObject.Find ("SuperScene");


		p1HBarFrame = GameObject.Find("P1HBarFrame").GetComponent<RectTransform>();
		p2HBarFrame= GameObject.Find("P2HBarFrame").GetComponent<RectTransform>();
		p1HBar = GameObject.Find("P1HBar").GetComponent<RectTransform>();
		p2HBar = GameObject.Find("P2HBar").GetComponent<RectTransform>();
		p1AttBarFrame = GameObject.Find("P1AttBarFrame").GetComponent<RectTransform>();
		p1AttBarFrame2 = GameObject.Find("P1AttBarFrame2").GetComponent<RectTransform>();
		p2AttBarFrame = GameObject.Find("P2AttBarFrame").GetComponent<RectTransform>();
		p2AttBarFrame2 = GameObject.Find("P2AttBarFrame2").GetComponent<RectTransform>();
		p1AttBar = GameObject.Find("P1AttBar").GetComponent<RectTransform>();
		p1AttBar2 = GameObject.Find("P1AttBar2").GetComponent<RectTransform>();
		p2AttBar = GameObject.Find("P2AttBar").GetComponent<RectTransform>();
		p2AttBar2 = GameObject.Find("P2AttBar2").GetComponent<RectTransform>();
		p1DefBarFrame = GameObject.Find("P1DefBarFrame").GetComponent<RectTransform>();
		p2DefBarFrame = GameObject.Find("P2DefBarFrame").GetComponent<RectTransform>();
		p1DefBar = GameObject.Find("P1DefBar").GetComponent<RectTransform>();
		p2DefBar = GameObject.Find("P2DefBar").GetComponent<RectTransform>();
		p1Att1Inactive = GameObject.Find("P1Att1Inactive").GetComponent<RectTransform>();
		p1Att2Inactive = GameObject.Find("P1Att2Inactive").GetComponent<RectTransform>();
		p1Att3Inactive = GameObject.Find("P1Att3Inactive").GetComponent<RectTransform>();
		p1Att3aInactive = GameObject.Find("P1Att3aInactive").GetComponent<RectTransform>();
		p1Att4Inactive = GameObject.Find("P1Att4Inactive").GetComponent<RectTransform>();
		p1Def1Inactive = GameObject.Find("P1Def1Inactive").GetComponent<RectTransform>();
		p1Def2Inactive = GameObject.Find("P1Def2Inactive").GetComponent<RectTransform>();
		p2Att1Active = GameObject.Find("P2Att1Active").GetComponent<RectTransform>();
		p2Att2Active = GameObject.Find("P2Att2Active").GetComponent<RectTransform>();
		p2Att3Active = GameObject.Find("P2Att3Active").GetComponent<RectTransform>();
		p2Att3aActive = GameObject.Find("P2Att3aActive").GetComponent<RectTransform>();
		p2Att4Active = GameObject.Find("P2Att4Active").GetComponent<RectTransform>();
		p2Att1Inactive = GameObject.Find("P2Att1Inactive").GetComponent<RectTransform>();
		p2Att2Inactive = GameObject.Find("P2Att2Inactive").GetComponent<RectTransform>();
		p2Att3Inactive = GameObject.Find("P2Att3Inactive").GetComponent<RectTransform>();
		p2Att3aInactive = GameObject.Find("P2Att3aInactive").GetComponent<RectTransform>();
		p2Att4Inactive = GameObject.Find("P2Att4Inactive").GetComponent<RectTransform>();
		p2Def1Active = GameObject.Find("P2Def1Active").GetComponent<RectTransform>();
		p2Def2Active = GameObject.Find("P2Def2Active").GetComponent<RectTransform>();
		p2Def1Inactive = GameObject.Find("P2Def1Inactive").GetComponent<RectTransform>();
		p2Def2Inactive = GameObject.Find("P2Def2Inactive").GetComponent<RectTransform>();

		att1Button = GameObject.Find("ButtonAtt1").GetComponent<RectTransform>();
		att2Button = GameObject.Find("ButtonAtt2").GetComponent<RectTransform>();
		att3Button = GameObject.Find("ButtonAtt3").GetComponent<RectTransform>();
		att3aButton = GameObject.Find("ButtonAtt3a").GetComponent<RectTransform>();
		att4Button = GameObject.Find("ButtonAtt4").GetComponent<RectTransform>();
		def1Button = GameObject.Find("ButtonDef1").GetComponent<RectTransform>();
		def2Button = GameObject.Find("ButtonDef2").GetComponent<RectTransform>();
		cosmoButton = GameObject.Find("ButtonCosmo").GetComponent<RectTransform>();
		resumeButton = GameObject.Find("ButtonResume").GetComponent<RectTransform>();
		quitButton = GameObject.Find("ButtonQuit").GetComponent<RectTransform>();
		
	}

	public void LoadPlayers (){

		if (p1Id == 1){
			if (!p1Raging && !cosmo.activeSelf){
				player1 = bambang;
			}else if (p1Raging && !cosmo.activeSelf){
				player1 = bambangRage;
			}else if (!p1Raging && cosmo.activeSelf){
				player1 = bambangCosmo;
			}
		}

		if (p2Id == 3){
			player2 = bonang;

		}else if (p2Id == 4){
			player2 = nk;

		}else if (p2Id == 5){
			if (!p2Raging){
				player2 = ron;
			}else{
				player2 = ronRage;
			}

		}else if (p2Id == 6){
			player2 = kbh;

		}else if (p2Id == 7){
			player2 = sunWukong;

		}

		p1Anim = player1.GetComponent<Animator> ();
		p2Anim = player2.GetComponent<Animator> ();

	}

	public void FightersInactive () {

		bonang.SetActive (false);
		nk.SetActive (false);
		ron.SetActive (false);
		kbh.SetActive (false);
		sunWukong.SetActive (false);
		bambangRage.SetActive (false);
		ronRage.SetActive (false);
		kbhRage.SetActive (false);
		bambangCosmo.SetActive (false);

	}

	/*public void LoadActions (){
		
		if (p2Id == 3){
			p2SAttack1 = bonangScript.SAttack1;
			p2SAttack2 = bonangScript.SAttack2;
			p2SAttack3 = bonangScript.SAttack3;
		}else if (p2Id == 4){
			p2SAttack1 = nkScript.SAttack1;
			p2SAttack2 = nkScript.SAttack2;
			p2SAttack3 = nkScript.SAttack3;
		}

	}*/
	
	public void Initial (){
		
		p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, 40f);
		p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, 40f);
		p1AttBarFrame.anchoredPosition = new Vector2 (p1AttBarFrame.anchoredPosition.x, -10f);
		p1AttBarFrame2.anchoredPosition = new Vector2 (p1AttBarFrame2.anchoredPosition.x, -70f);
		p2AttBarFrame.anchoredPosition = new Vector2 (p2AttBarFrame.anchoredPosition.x, -10f);
		p2AttBarFrame2.anchoredPosition = new Vector2 (p2AttBarFrame2.anchoredPosition.x, -10f);
		p1DefBarFrame.anchoredPosition = new Vector2 (p1DefBarFrame.anchoredPosition.x, 50f);
		p2DefBarFrame.anchoredPosition = new Vector2 (p2DefBarFrame.anchoredPosition.x, 50f);
		
		p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, -50f);
		p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, -50f);
		p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, -50f);
		p1Att3aInactive.anchoredPosition = new Vector2 (p1Att3aInactive.anchoredPosition.x, -50f);
		p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, -50f);
		p1Def1Inactive.anchoredPosition = new Vector2 (p1Def1Inactive.anchoredPosition.x, 50f);
		p1Def2Inactive.anchoredPosition = new Vector2 (p1Def2Inactive.anchoredPosition.x, 50f);
		p2Att1Active.anchoredPosition = new Vector2 (p2Att1Active.anchoredPosition.x, -50f);
		p2Att2Active.anchoredPosition = new Vector2 (p2Att2Active.anchoredPosition.x, -50f);
		p2Att3Active.anchoredPosition = new Vector2 (p2Att3Active.anchoredPosition.x, -50f);
		p2Att3aActive.anchoredPosition = new Vector2 (p2Att3aActive.anchoredPosition.x, -50f);
		p2Att4Active.anchoredPosition = new Vector2 (p2Att4Active.anchoredPosition.x, -50f);
		p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, -50f);
		p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, -50f);
		p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, -50f);
		p2Att3aInactive.anchoredPosition = new Vector2 (p2Att3aInactive.anchoredPosition.x, -50f);
		p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, -50f);
		p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, 50f);
		p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, 50f);
		p2Def1Inactive.anchoredPosition = new Vector2 (p2Def1Inactive.anchoredPosition.x, 50f);
		p2Def2Inactive.anchoredPosition = new Vector2 (p2Def2Inactive.anchoredPosition.x, 50f);

		att1Button.anchoredPosition = new Vector2 (att1Button.anchoredPosition.x, -50f);
		att2Button.anchoredPosition = new Vector2 (att2Button.anchoredPosition.x, -50f);
		att3Button.anchoredPosition = new Vector2 (att3Button.anchoredPosition.x, -50f);
		att3aButton.anchoredPosition = new Vector2 (att3aButton.anchoredPosition.x, -50f);
		att4Button.anchoredPosition = new Vector2 (att4Button.anchoredPosition.x, -50f);
		def1Button.anchoredPosition = new Vector2 (def1Button.anchoredPosition.x, 50f);
		def2Button.anchoredPosition = new Vector2 (def2Button.anchoredPosition.x, 50f);
		cosmoButton.anchoredPosition = new Vector2 (cosmoButton.anchoredPosition.x, -100f);

		resumeButton.anchoredPosition = new Vector2 (0, -1000f);
		quitButton.anchoredPosition = new Vector2 (0, -1000f);

		pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -1000);
		pauseText.text = " ";
		
	}
	
	void FightScene (){
		
		p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
		p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, -20f);

		if (!p1Raging && !cosmo.activeSelf) {
			p1AttBarFrame.anchoredPosition = new Vector2 (p1AttBarFrame.anchoredPosition.x, 10f);

			p1Att1Inactive.anchoredPosition = new Vector2 (p1Att1Inactive.anchoredPosition.x, 32f);
			p1Att2Inactive.anchoredPosition = new Vector2 (p1Att2Inactive.anchoredPosition.x, 32f);
			p1Att3Inactive.anchoredPosition = new Vector2 (p1Att3Inactive.anchoredPosition.x, 32f);
		} else if (p1Raging && !cosmo.activeSelf) {
			p1AttBarFrame2.anchoredPosition = new Vector2 (p1AttBarFrame2.anchoredPosition.x, 10f);

			p1Att3aInactive.anchoredPosition = new Vector2 (p1Att3aInactive.anchoredPosition.x, 32f);
			p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, 32f);
		} else if (cosmo.activeSelf) {
			p1AttBarFrame2.anchoredPosition = new Vector2 (p1AttBarFrame2.anchoredPosition.x, 10f);
	
			p1Att4Inactive.anchoredPosition = new Vector2 (p1Att4Inactive.anchoredPosition.x, 32f);
		}

		if (!p2Raging && p2Id != 7) {
			p2AttBarFrame.anchoredPosition = new Vector2 (p2AttBarFrame.anchoredPosition.x, 10f);

			p2Att1Inactive.anchoredPosition = new Vector2 (p2Att1Inactive.anchoredPosition.x, 32f);
			p2Att2Inactive.anchoredPosition = new Vector2 (p2Att2Inactive.anchoredPosition.x, 32f);
			p2Att3Inactive.anchoredPosition = new Vector2 (p2Att3Inactive.anchoredPosition.x, 32f);
		} else if (p2Raging && p2Id != 7) {
			p2AttBarFrame2.anchoredPosition = new Vector2 (p2AttBarFrame2.anchoredPosition.x, 10f);
			
			p2Att3aInactive.anchoredPosition = new Vector2 (p2Att3aInactive.anchoredPosition.x, 32f);
			p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, 32f);
		} else if (p2Id == 7) {
			p2AttBarFrame2.anchoredPosition = new Vector2 (p2AttBarFrame2.anchoredPosition.x, 10f);

			p2Att4Inactive.anchoredPosition = new Vector2 (p2Att4Inactive.anchoredPosition.x, 32f);
		}

		p1DefBarFrame.anchoredPosition = new Vector2 (p1DefBarFrame.anchoredPosition.x, -50f);
		p2DefBarFrame.anchoredPosition = new Vector2 (p2DefBarFrame.anchoredPosition.x, -50f);
		
		p1Def1Inactive.anchoredPosition = new Vector2 (p1Def1Inactive.anchoredPosition.x, -72f);
		p1Def2Inactive.anchoredPosition = new Vector2 (p1Def2Inactive.anchoredPosition.x, -72f);
		
		p2Def1Inactive.anchoredPosition = new Vector2 (p2Def1Inactive.anchoredPosition.x, -72f);
		p2Def2Inactive.anchoredPosition = new Vector2 (p2Def2Inactive.anchoredPosition.x, -72f);

		if (PlayerPrefs.GetInt ("success") == 1 && !cosmo.activeSelf) {
			cosmoButton.anchoredPosition = new Vector2 (cosmoButton.anchoredPosition.x, 0);
		} else {
			cosmoButton.anchoredPosition = new Vector2 (cosmoButton.anchoredPosition.x, -100);
		}

		
	}
	
	void ScreenSrinking (){
		
		blackTop.transform.position = new Vector3 (blackTop.transform.position.x, blackTop.transform.position.y + ((9.45f - blackTop.transform.position.y) * 0.1f), 0);
		blackBottom.transform.position = new Vector3 (blackBottom.transform.position.x, blackBottom.transform.position.y + ((-9.45f - blackBottom.transform.position.y) * 0.1f), 0);
		if (blackTop.transform.position.y < 9.5f) {
			p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);

		}
		
	}
	
	void ScreenEnlarging (){
		
		blackTop.transform.position = new Vector3 (blackTop.transform.position.x, blackTop.transform.position.y + ((10.8f - blackTop.transform.position.y) * 0.1f), 0);
		blackBottom.transform.position = new Vector3 (blackBottom.transform.position.x, blackBottom.transform.position.y + ((-10.8f - blackBottom.transform.position.y) * 0.1f), 0);
		
	}
	
	void ScreenShutting (){
		
		blackTop.transform.position = new Vector3 (blackTop.transform.position.x, blackTop.transform.position.y + ((4f - blackTop.transform.position.y) * 0.1f), 0);
		blackBottom.transform.position = new Vector3 (blackBottom.transform.position.x, blackBottom.transform.position.y + ((-4f - blackBottom.transform.position.y) * 0.1f), 0);
		
	}
	
	IEnumerator SuperSceneFadeIn(){
		
		for (float i = 0f; i <= 1f; i+= 0.1f) {
			superScene.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds(0.05f);
		}
		
	}
	

	public void LoadLevel (){
		
		StartCoroutine (LevelCoroutine ());
		
	}

	public void LoadLevelNext (){
		
		StartCoroutine (LevelCoroutineNext ());
		
	}
	
	IEnumerator LevelCoroutine (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (2);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}

	IEnumerator LevelCoroutineNext (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (4);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}

	public void OnClickedExit (Button exitButton) {

		Application.LoadLevel(1);
		Time.timeScale = 1;
		
	}
	
	public void OnClickedResume (Button resumeButton) {
		
		buttonSound.Play ();
		Time.timeScale = 1;
		
		resumeButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -1000f);
		quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -1000f);
		pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -1000);
		pauseText.text = " ";
		
	}
	
	public void OnClickedAtt1 (Button att1Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1SAttack1 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar.sizeDelta = new Vector2 (p1AttBar.rect.width - 100f, p1AttBar.rect.height);
			Initial ();
		
			p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
			p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, -20f);
		
			if (p2DefBar.rect.width >= 100 && p2DefBar.rect.width < 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, -72f);
			}
		}
	}
	
	public void OnClickedAtt2 (Button att2Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1SAttack2 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar.sizeDelta = new Vector2 (p1AttBar.rect.width - 200f, p1AttBar.rect.height);
			Initial ();
		
			p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
			p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, -20f);
		
			if (p2DefBar.rect.width >= 100 && p2DefBar.rect.width < 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, -72f);
			}
		}
		
	}
	
	public void OnClickedAtt3 (Button att3Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1SAttack3 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar.sizeDelta = new Vector2 (p1AttBar.rect.width - 300f, p1AttBar.rect.height);
			Initial ();
		
			p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
			p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, -20f);
		
			if (p2DefBar.rect.width >= 100 && p2DefBar.rect.width < 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, -72f);
			}
		}
		
	}

	public void OnClickedAtt3a (Button att3aButton) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1SAttack3 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar2.sizeDelta = new Vector2 (p1AttBar2.rect.width - 100f, p1AttBar2.rect.height);
			Initial ();
		
			p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
			p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, -20f);
		
			if (p2DefBar.rect.width >= 100 && p2DefBar.rect.width < 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, -72f);
			}
		}
		
	}

	public void OnClickedAtt4 (Button att4Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1SAttack4 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar2.sizeDelta = new Vector2 (p1AttBar2.rect.width - 200f, p1AttBar2.rect.height);
			Initial ();
		
			p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
			p2HBarFrame.anchoredPosition = new Vector2 (p2HBarFrame.anchoredPosition.x, -20f);
		
			if (p2DefBar.rect.width >= 100 && p2DefBar.rect.width < 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.rect.width >= 200) {
				p2Def1Active.anchoredPosition = new Vector2 (p2Def1Active.anchoredPosition.x, -72f);
				p2Def2Active.anchoredPosition = new Vector2 (p2Def2Active.anchoredPosition.x, -72f);
			}
		}
		
	}
	
	public void OnClickedDef1 (Button def1Button) {

		if (Time.timeScale != 0) {
			if (p2SAttack1 || p2SAttack2 || p2SAttack3 || p2SAttack4) {
				fightSound.Play ();
				p1Block = true;
				p1Dodge = false;
				p1DefBar.sizeDelta = new Vector2 (p1DefBar.rect.width - 100f, p1DefBar.rect.height);
				Initial ();
				p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
				p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}
		
	}
	
	public void OnClickedDef2 (Button def2Button) {

		if (Time.timeScale != 0) {
			if (p2SAttack1 || p2SAttack2 || p2SAttack3 || p2SAttack4) {
				fightSound.Play ();
				p1Block = false;
				p1Dodge = true;
				p1DefBar.sizeDelta = new Vector2 (p1DefBar.rect.width - 200f, p1DefBar.rect.height);
				Initial ();
				p1HBarFrame.anchoredPosition = new Vector2 (p1HBarFrame.anchoredPosition.x, -20f);
				p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}
		
	}

	public void OnClickedCosmo (Button cosmoButton) {

		if (Time.timeScale != 0) {
			cosmo.SetActive (true);
			Instantiate (Resources.Load ("Prefabs/EnergyBurst2"), new Vector3 (player1.transform.position.x, player1.transform.position.y - 1, player1.transform.position.z), Quaternion.identity);
			swipSound.Play ();
			cosmoButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (cosmoButton.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -100);

			p1AttBarFrame2.anchoredPosition = new Vector2 (p1AttBarFrame2.anchoredPosition.x, 10f);
			p1AttBarFrame.anchoredPosition = new Vector2 (p1AttBarFrame.anchoredPosition.x, -10f);

			bambangCosmo.SetActive (true);
			bambangCosmo.transform.position = new Vector3 (bambang.transform.position.x, bambang.transform.position.y, bambang.transform.position.z);
			bambang.SetActive (false);
		}
	
	}
}
