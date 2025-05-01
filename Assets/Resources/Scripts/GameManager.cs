using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	Player1Script p1Script;
	PatrickScript patrickScript;

    public Camera mainCam;
    public GameObject MoveLeftButton;
    public GameObject blocker;
    public GameObject hitFxPool;
    public GameObject[] hitFx;
    public GameObject[] cloudButton;

	public GameObject player1;
	public GameObject patrick;
	GameObject dakochan;
	GameObject ron;
	GameObject kitaro;
	GameObject sunWukong;
	GameObject nk;
	GameObject siModo;
	GameObject cakKumis;
	GameObject counterLady;
	GameObject bouncer;
	GameObject bajay;
	GameObject kintoun;
	GameObject wukongShadow;
	GameObject bonangIcon;
	GameObject nkIcon;
	GameObject ronIcon;
	GameObject kbhIcon;
	GameObject sunWukongIcon;
	GameObject camera1;
	GameObject blackTop;
	GameObject blackBottom;
	GameObject darkScene;
	public GameObject superScene;
	
	public Image p1HBarFrame;
	public Image p2HBarFrame;
	public Image p1HBar;
	public Image p2HBar;
	public Image p1AttBarFrame;
	public Image p2AttBarFrame;
	public Image p1AttBar;
	public Image p2AttBar;
	public Image p1DefBarFrame;
	public Image p2DefBarFrame;
	public Image p1DefBar;
	public Image p2DefBar;
	public Image p1Att1Inactive;
	public Image p1Att2Inactive;
	public Image p1Att3Inactive;
	public Image p1Def1Inactive;
	public Image p1Def2Inactive;
	public Image p2Att1Active;
	public Image p2Att2Active;
	public Image p2Att3Active;
	public Image p2Att1Inactive;
	public Image p2Att2Inactive;
	public Image p2Att3Inactive;
	public Image p2Def1Active;
	public Image p2Def2Active;
	public Image p2Def1Inactive;
	public Image p2Def2Inactive;
	public Image moneyIcon;

	public Image panel;
	public Image pausePanel;

	public Text hitText;
	public Text moneyText;
	public Text moneyDynamicText;
	public Text healthText;
	public Text panelText;
	public Text p1NameText;
	public Text p2NameText;
	public Text pauseText;
	public Text chapText;

	public Button fightButton;
	public Button satayButton;
	public Button registerButton;
	public Button enterButton;
	public Button exitButton;
	public Button leaveButton;
	public Button nextButton;
	public Button trainingButton;
	public Button att1Button;
	public Button att2Button;
	public Button att3Button;
	public Button def1Button;
	public Button def2Button;
	public Button resumeButton;
	public Button quitButton;

	public AudioSource bGMusic;
	public AudioSource bGMusic2;
	public AudioSource bajaySound;
	public AudioSource attack1Voice;
	public AudioSource attack2Voice;
	public AudioSource pukulanVoice;
	public AudioSource awurawuranVoice;
	public AudioSource sapuJagatVoice;
	public AudioSource punchSound;
	public AudioSource blockSound;
	public AudioSource jumpSound;
	public AudioSource hitSound;
	public AudioSource manyHitSound;
	public AudioSource swipSound;
	public AudioSource criticalSound;
	public AudioSource buttonSound;
	public AudioSource gongSound;
	public AudioSource gotSomethingSound;
	public AudioSource chachingSound;
	public AudioSource fightSound;
	public AudioSource swooshSound;
	public AudioSource hihiSound;
	public AudioSource welehVoice;
	public AudioSource mantraVoice;
	public AudioSource tendanganMautVoice;
	public AudioSource xplosionSound;
	public AudioSource hawaVoice;
	public AudioSource oioiVoice;


	float readyToFightTimer = 80;
	float readyToFightTimerMax = 80;
	float fightStartTimer = 40;
    float fightStartTimerMax = 40;
    float p2ActionTimer = 40;
    float p2ActionTimerInit = 40;
    float addDefBarTimer = 100;
    float addDefBarTimerInit = 100;
    float chap2ProlEndTimer = 80;
    float chap2ProlEndTimerMax = 80;
    int p1RanAttack = 0;
    int p2RanAttack = 0;

    float strollingTimer = 200;
    float strollingTimerMax = 200;

	int attackVoice1 = 0;
	int attackVoice2 = 0;

	int chatInfo = 0;
    float henshinTimer = 100;
    float henshinTimerMax = 100;
    float chapTextTime = 200;
    float chapTextTimeMax = 200;
    float chap4AttackTimer = 200;
    float chap4AttackTimerMax = 200;

	public int chapter;
	public int moneyPoint;
	public int moneyTournament;
	public int moneyDynamicPoint = 0;

	public float p1HBarX;

	float defPoint = 20f;
	float attPoint = 8f;
	float sAtt1Damage = 40f;
	float sAtt2Damage = 80f;
	float sAtt3Damage = 120f;
	float alphaVal = 0f;

	public bool patrickAppear = false;
	public bool chat = false;
	public bool moneyChecked = false;
	public bool moneyAppearPlus = false;
	public bool moneyAppearMin = false;
	bool healthAppear = false;
	public bool registered;
	public bool fight = false;
	public bool screenSrink = false;
	public bool screenEnlarge = false;
	public bool screenShut = false;
	bool bow = false;
	public bool fightStart = false;
	public bool fighting = false;
	bool p1MoveFwd = false;
	bool p2Movefwd = false;
	bool chap2ProlClose = false;
	bool justPossessed = false;
	bool dynamicCam = false;
	bool postModo = false;
	bool healthRestored = false;
	bool wukongJump = false;
	bool chap4Fighting = false;
	bool chap4P1Attack = false;
	bool chap4P2Attack = false;
	public bool chatKumis = false;

	public bool strollingStart = false;
	public bool p1Lost = false;
	public bool fromTour = false;
	public bool prologue = false;
	public bool bajayOn = false;
	public bool bajayStop = false;

	[HideInInspector] public bool actionChapter2 = false;

    private Vector3 targetAction2 = Vector3.zero;


    Vector3 savePositionP1;
	Vector3 savePositionP2;

	RaycastHit hit;
	
	public Animator anim;
	public Animator patrickAnim;
	public Animator dakochanAnim;
	public Animator ronAnim;
	public Animator kitaroAnim;
	public Animator sunWukongAnim;
	public Animator nkAnim;

	public GameObject loadingScene;
	public Image loadingBar;
	public Text loadingText;
	
	void Awake (){

		//Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);
		/*if (Screen.currentResolution.width / Screen.currentResolution.height == 16/9) {
			Screen.SetResolution (1920, 1080, true);
		} else {
			Screen.SetResolution (1024, 576, false);
		}*/

	}

	void Start () {

		chapter = PlayerPrefs.GetInt ("chapter");
		moneyPoint = PlayerPrefs.GetInt ("moneyPoint");
		moneyTournament = PlayerPrefs.GetInt ("moneyTournament");
		p1HBarX = PlayerPrefs.GetFloat ("p1HBarX");
		registered = PlayerPrefs.GetInt("registered") > 0;
		p1Lost = PlayerPrefs.GetInt ("p1Lost") > 0;
		patrickAppear = PlayerPrefs.GetInt ("patrickAppear") > 0;
		fromTour = PlayerPrefs.GetInt ("fromTour") > 0;
		prologue = PlayerPrefs.GetInt ("prologue") > 0;
		bajayOn = PlayerPrefs.GetInt ("bajayOn") > 0;

		// --- TODO: testing
//		chapter = 4;
//		prologue = true;
//		bajayOn = false;
//		PlayerPrefs.SetInt ("tournamentNumb", chapter);
//		PlayerPrefs.SetInt ("rageMode", 0);
//		PlayerPrefs.SetInt ("success", 0);
//		PlayerPrefs.SetInt ("notFirstTime", 0);
		// ---

		//p1HBarX = 300;

//		moneyPoint += moneyTournament;

		bGMusic.Play ();

		loadingScene.SetActive (false);

		//Screen.fullScreen = true;

		//Screen.SetResolution (1920, 1080, true);

		p1Script = GameObject.Find ("Bambang").GetComponent<Player1Script> ();
		patrickScript = GameObject.Find ("Patrick").GetComponent<PatrickScript> ();

		LoadResources ();
		Initial ();

		bonangIcon.SetActive (false);
		nkIcon.SetActive (false);

		hitText.text = " ";
		moneyDynamicText.text = " ";
		healthText.text = " ";
		panelText.text = " ";
		chapText.text = " ";

		superScene.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
		//Screen.orientation = ScreenOrientation.LandscapeLeft;

		anim.SetBool ("Walk", false);

		blackTop.transform.position = new Vector3 (camera1.transform.position.x, 10.8f, 0);
		blackBottom.transform.position = new Vector3 (camera1.transform.position.x, -10.8f, 0);
		darkScene.SetActive (false);

		p1HBar.rectTransform.sizeDelta = new Vector2 (p1HBarX, p1HBar.GetComponent<RectTransform> ().rect.height);
		p2HBar.rectTransform.sizeDelta = new Vector2 (300, p2HBar.GetComponent<RectTransform> ().rect.height);
		p1AttBar.rectTransform.sizeDelta = new Vector2 (0, p1AttBar.GetComponent<RectTransform> ().rect.height);
		p2AttBar.rectTransform.sizeDelta = new Vector2 (0, p2AttBar.GetComponent<RectTransform> ().rect.height);
		p1DefBar.rectTransform.sizeDelta = new Vector2 (0, p1DefBar.GetComponent<RectTransform> ().rect.height);
		p2DefBar.rectTransform.sizeDelta = new Vector2 (0, p2DefBar.GetComponent<RectTransform> ().rect.height);

		charsNotAppear ();
		kintoun.SetActive (false);

		if (prologue)
		{
            //if (chapter == 2)
            //    MoveLeftButton.SetActive(true);
        }	

		targetAction2 = new Vector3(-2.1f, 0.0f, 0.0f);
    }
	
	void Update () {

		//print ("Chapter " + PlayerPrefs.GetInt ("chapter"));
        //print("Chapter Time: " + chapTextTime);
		//print (PlayerPrefs.GetInt ("tournamentNumb"));
		//print ("Chap" + chap2ProlClose + " " + chap2ProlEndTimer);
		//print ("Stroll" + strollingStart + " " + strollingTimer);

		PlayerPrefs.SetInt ("chapter", chapter);
		PlayerPrefs.SetInt ("moneyPoint", moneyPoint);
		PlayerPrefs.SetInt ("moneyTournament", moneyTournament);
		PlayerPrefs.SetFloat ("p1HBarX", p1HBar.GetComponent<RectTransform> ().rect.width);
		PlayerPrefs.SetInt ("registered", registered ? 1 : 0);
		PlayerPrefs.SetInt ("p1Lost", p1Lost ? 1 : 0);
		PlayerPrefs.SetInt ("patrickAppear", patrickAppear ? 1 : 0);
		PlayerPrefs.SetInt ("fromTour", fromTour ? 1 : 0);
		PlayerPrefs.SetInt ("prologue", prologue ? 1 : 0);
		PlayerPrefs.SetInt ("bajayOn", bajayOn ? 1 : 0);

		//PlayerPrefs.SetFloat ("p1HBarX", p1HBarX);

		//p1HBar.rectTransform.sizeDelta = new Vector2 (p1HBarX, p1HBar.GetComponent<RectTransform> ().rect.height);

		if (Input.GetKeyDown(KeyCode.Escape)){
//			Application.Quit();
			Time.timeScale = 0;

			resumeButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, 0);
			quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -50f);
			pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			pauseText.text = "PAUSE";

		}

		// --- CHEAT CODES ---
		if (Input.GetKeyDown(KeyCode.F1))
		{
			PlayerPrefs.SetInt("matchNumb", 2);
		}

		if (Input.GetKeyDown (KeyCode.F2) && Input.GetKeyDown (KeyCode.F4)) {
			if (!gotSomethingSound.isPlaying){
				gotSomethingSound.Play ();
			}
			moneyPoint = moneyPoint + 100;
		}

		if (Input.GetKeyDown (KeyCode.Alpha6) && Input.GetKeyDown (KeyCode.Alpha8)) {
			if (!oioiVoice.isPlaying){
				oioiVoice.Play ();
			}
			PlayerPrefs.SetInt ("quickMode", 1);
		}
		
//		if (Input.GetKeyDown (KeyCode.F3)) {
//			PlayerPrefs.SetInt ("matchNumb", 3);
//		}
		// -------------------

		if (PlayerPrefs.GetInt ("success") == 1) {
			PlayerPrefs.SetInt ("rageMode", 0);
        }

        if (actionChapter2)
		{
            player1.transform.position = Vector3.MoveTowards(player1.transform.position, targetAction2, 5.0f * Time.deltaTime);
			anim.SetBool("Walk", true);
        }			

        if (Time.timeScale != 0) {

			if (chapter == 1) {
                chapTextTime -= Time.deltaTime * 100f;
				if (chapTextTime > 0 && player1.transform.position.x < 17f){
					chapText.text = "Chapter 1:\n" +
						"Rookie Tournament\n~ Let's have a Turgul!";
				}else {
					chapTextTime = 0;
					chapText.text = " ";
				}
			}
			if (chapter == 2) {
				if (prologue) {
					chapTextTime -= Time.deltaTime * 100f;
					if (chapTextTime > 0){
                        chapText.text = "Chapter 2:\n" +
							"Amateur Tournament\n~ The devil within ~";
					}else {
						chapTextTime = 0;
						chapText.text = " ";
					}
					bGMusic.Stop ();
					if (!bGMusic2.isPlaying) {
						bGMusic2.Play ();
					}
					darkScene.SetActive (true);
					patrickAppear = false;
					cakKumis.SetActive (false);
					counterLady.SetActive (false);
					bouncer.SetActive (false);
					bajay.SetActive (false);
				} else {
//				darkScene.SetActive (false);
					patrickAppear = true;
					ron.transform.position = new Vector3 (-24, 0, 2);
//				cakKumis.SetActive (true);
					counterLady.SetActive (true);
					bouncer.SetActive (true);
					bajay.SetActive (true);
                    //p1Script.joystick.SetActive(false);
                }

				if (player1.transform.position.x < -2f && player1.transform.position.x > -4f && prologue) {
                    if (!hihiSound.isPlaying) {
						hihiSound.Play ();
					}
					actionChapter2 = false;
					chat = true;
                    //MoveLeftButton.SetActive(false);
                    p1Script.joystick.SetActive(false);
                    p1Script.OnMoveLeft(false);
                    player1.transform.localScale = new Vector3 (-1, 1, 1);
					anim.SetBool ("Walk", true);
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-4f - player1.transform.position.x) * 0.1f), player1.transform.position.y, player1.transform.position.z + ((0 - player1.transform.position.z) * 0.1f));
					dakochan.transform.position = new Vector3 (4, 0, 0);
					camera1.transform.position = new Vector3 (camera1.transform.position.x + ((0 - camera1.transform.position.x) * 0.4f), camera1.transform.position.y, camera1.transform.position.z);
				}
				if (player1.transform.position.x < -3.9f && prologue) {
					player1.transform.position = new Vector3 (-4f, player1.transform.position.y, 0);
					camera1.transform.position = new Vector3 (0, camera1.transform.position.y, camera1.transform.position.z);
					anim.SetBool ("Walk", false);
				}
				if (player1.transform.position.x == -4f && prologue && dakochan.activeSelf) {
					screenSrink = true;
					screenEnlarge = false;
					screenShut = false;
					p1HBarFrame.enabled = false;
					p1HBar.enabled = false;
					p1NameText.enabled = false;
					moneyIcon.enabled = false;
					moneyText.enabled = false;
					player1.transform.localScale = new Vector3 (1, 1, 1);
					anim.SetInteger ("FightMove", 2);
					alphaVal += 0.005f;
					dakochan.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, alphaVal);
				}
				if (dakochan.GetComponent<SpriteRenderer> ().color.a > 0.95f && dakochan.activeSelf) {
					dakochanAnim.SetInteger ("FightMove", 18);
					dakochan.transform.position = new Vector3 (dakochan.transform.position.x + ((-4f - dakochan.transform.position.x) * 0.4f), dakochan.transform.position.y, dakochan.transform.position.z);
					Instantiate (Resources.Load ("Prefabs/DakochanShadowL"), new Vector3 (dakochan.transform.position.x, dakochan.transform.position.y, dakochan.transform.position.z), Quaternion.identity);
					if (!swooshSound.isPlaying) {
						swooshSound.Play ();
					}
				}
				if (dakochan.transform.position.x < -2f && dakochan.activeSelf) {
					anim.SetInteger ("FightMove", 13);
					dakochan.SetActive (false);
					chap2ProlClose = true;
					if (!punchSound.isPlaying) {
						punchSound.Play ();
					}
					Instantiate (Resources.Load ("Prefabs/PunchClash3"), new Vector3 (player1.transform.position.x, player1.transform.position.y - 1, player1.transform.position.z), Quaternion.identity);
//				Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (player1.transform.position.x, player1.transform.position.y - 1, player1.transform.position.z), Quaternion.identity);
				}
				if (chap2ProlClose) {
					chap2ProlEndTimer -= Time.deltaTime * 100f;
				}
				if (chap2ProlEndTimer <= 0) {
					chap2ProlClose = false;
					strollingStart = true;
					screenSrink = false;
					chap2ProlEndTimer = chap2ProlEndTimerMax;
					anim.SetInteger ("FightMove", 14);
					p1HBar.rectTransform.sizeDelta = new Vector2 (0, p1HBar.GetComponent<RectTransform> ().rect.height);
					savePositionP1 = new Vector3 (-18, 0, 2);
					justPossessed = true;
					PlayerPrefs.SetInt ("rageMode", 1);
				}
			}

			if (chapter == 3) {
				if (prologue) {
					chapTextTime -= Time.deltaTime * 100f;
                    if (chapTextTime > 0){
                        chapText.text = "Chapter 3:\n" +
							"Pro Tournament\n~ Super Heroes ~";
					}else {
						chapTextTime = 0;
						chapText.text = " ";
					}
					bGMusic.Stop ();
					if (!bGMusic2.isPlaying) {
						bGMusic2.Play ();
					}
					nk.transform.position = new Vector3 (-7f, 0, 0);
					if (chatInfo == 0) {
						siModo.transform.position = new Vector3 (-16f, 1.3f, 0);
					}
					patrickAppear = false;
					cakKumis.SetActive (false);
					counterLady.SetActive (false);
					bouncer.SetActive (false);
					bajay.SetActive (false);
				} else {
					patrickAppear = true;
					kitaroAnim.SetInteger ("FightMove", 0);
					kitaro.transform.position = new Vector3 (-24, 0, 2);
					kitaro.transform.localScale = new Vector3 (1, 1, 1);
					counterLady.SetActive (true);
					bouncer.SetActive (true);
					bajay.SetActive (true);
				}
			
				if (player1.transform.position.x < -2f && player1.transform.position.x > -4f && prologue && !dynamicCam) {

					chat = true;
                    //MoveLeftButton.SetActive(false);
                    p1Script.joystick.SetActive(false);
                    p1Script.OnMoveLeft(false);
                    player1.transform.localScale = new Vector3 (-1, 1, 1);
					anim.SetBool ("Walk", true);
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-4f - player1.transform.position.x) * 0.1f), player1.transform.position.y, player1.transform.position.z + ((0 - player1.transform.position.z) * 0.1f));
					camera1.transform.position = new Vector3 (camera1.transform.position.x + ((-12f - camera1.transform.position.x) * 0.4f), camera1.transform.position.y, camera1.transform.position.z);
				}
				if (player1.transform.position.x < -3.9f && prologue && !dynamicCam) {
					player1.transform.position = new Vector3 (-4f, player1.transform.position.y, 0);
					camera1.transform.position = new Vector3 (-12f, camera1.transform.position.y, camera1.transform.position.z);
					anim.SetBool ("Walk", false);
					if (!welehVoice.isPlaying) {
						welehVoice.Play ();
					}
				}
				if (player1.transform.position.x == -4f && prologue && !dynamicCam) {
					screenSrink = true;
					screenEnlarge = false;
					screenShut = false;
					p1HBarFrame.enabled = false;
					p1HBar.enabled = false;
					p1NameText.enabled = false;
					moneyIcon.enabled = false;
					moneyText.enabled = false;
					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
					panelText.text = "NIGHT KNIGHT:\n\n" +
						"This MONSTER was causing a massive traffic jam on the street.\nI tried to take care of this HUGE COW LIZZARD...\n" +
						"but it is too savage and too strong...\nI'm too exhausted now...\nI can't handle it anymore...";
					dynamicCam = true;
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
				}
				if (chatInfo == 1 && dynamicCam) {
				
					nkAnim.SetInteger ("Move", 1);
					kitaro.transform.position = new Vector3 (1f, 0, 0);
					panelText.text = "???:\n\n" +
						"Hold on there NIGHT KNIGHT!\nI'm going to assist you!";
					camera1.transform.position = new Vector3 (camera1.transform.position.x + ((0 - camera1.transform.position.x) * 0.4f), camera1.transform.position.y, camera1.transform.position.z);

				}
				if (chatInfo == 2 && dynamicCam) {
					henshinTimer -= Time.deltaTime * 100f;
				}
				if (henshinTimer < 15f && henshinTimer > 14f) {
					swipSound.Play ();
					Instantiate (Resources.Load ("Prefabs/EnergyBurst2"), new Vector3 (kitaro.transform.position.x, kitaro.transform.position.y - 1, kitaro.transform.position.z), Quaternion.identity);
				}
				if (henshinTimer <= 0) {
                    henshinTimer = 0;
                    panelText.text = "KBH:\n\n" +
						"I am KNIGHT BLACK HERO!!!";
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
				}
				if (chatInfo == 3 && dynamicCam) {
					Initial ();
					kitaroAnim.SetInteger ("FightMove", 18);
					kitaro.transform.position = new Vector3 (kitaro.transform.position.x + ((-14f - kitaro.transform.position.x) * 0.05f), 0, 0);
					camera1.transform.position = new Vector3 (camera1.transform.position.x + ((-12f - camera1.transform.position.x) * 0.4f), camera1.transform.position.y, camera1.transform.position.z);
				
				}
				if (kitaro.transform.position.x < 0f && kitaro.transform.position.x > -1f) {
					if (!tendanganMautVoice.isPlaying) {
						tendanganMautVoice.Play ();
					}
				}
				if (kitaro.transform.position.x < -13.5f && kitaro.transform.position.x > -13.6f) {
					if (!xplosionSound.isPlaying) {
						xplosionSound.Play ();
					}
					Instantiate (Resources.Load ("Prefabs/Explosion1"), new Vector3 (siModo.transform.position.x, siModo.transform.position.y, siModo.transform.position.z), Quaternion.identity);
					postModo = true;
					strollingStart = true;
					screenSrink = false;
					savePositionP1 = new Vector3 (-18, 0, 2);
				}
			}

			if (chapter == 4) {
				if (prologue) {
					chapTextTime -= Time.deltaTime * 100f;
                    if (chapTextTime > 0){
                        chapText.text = "Last Chapter:\n" +
							"Grand Tournament\n~ The power within ~";
					}else {
						chapTextTime = 0;
						chapText.text = " ";
					}
					bGMusic.Stop ();
					if (!bGMusic2.isPlaying) {
						bGMusic2.Play ();
					}
					patrickAppear = false;
					wukongShadow.SetActive (false);
					counterLady.SetActive (false);
					bouncer.SetActive (false);
					bajay.SetActive (false);
				} else {
					wukongShadow.SetActive (false);
					patrickAppear = true;
					kitaroAnim.SetInteger ("FightMove", 0);
					counterLady.SetActive (true);
					bouncer.SetActive (true);
					bajay.SetActive (true);
                    if (!fight)
                        cloudButton[6].SetActive(true);
                    else
                        cloudButton[6].SetActive(false);
                }
			
				if (player1.transform.position.x < -2f && player1.transform.position.x > -4f && prologue && p1HBar.GetComponent<RectTransform> ().rect.width == 300) {
				
					chat = true;
                    //MoveLeftButton.SetActive(false);
                    p1Script.joystick.SetActive(false);
                    p1Script.OnMoveLeft(false);
                    player1.transform.localScale = new Vector3 (-1, 1, 1);
					anim.SetBool ("Walk", true);
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-4f - player1.transform.position.x) * 0.1f), player1.transform.position.y, player1.transform.position.z + ((0 - player1.transform.position.z) * 0.1f));
					camera1.transform.position = new Vector3 (camera1.transform.position.x + ((0f - camera1.transform.position.x) * 0.4f), camera1.transform.position.y, camera1.transform.position.z);
					healthRestored = true;
					kintoun.SetActive (true);
					if (!swipSound.isPlaying) {
						swipSound.Play ();
					}
				}
				if (player1.transform.position.x < -3.9f && prologue && healthRestored) {
					player1.transform.position = new Vector3 (-4f, player1.transform.position.y, 0);
					camera1.transform.position = new Vector3 (0f, camera1.transform.position.y, camera1.transform.position.z);
					anim.SetBool ("Walk", false);
					healthRestored = false;
				}
				if (kintoun.transform.position.x > 10f && kintoun.transform.position.x < 11f) {
					sunWukong.transform.position = new Vector3 (12, 2, 0);
					player1.transform.localScale = new Vector3 (1, 1, 1);
					sunWukongAnim.SetInteger ("FightMove", 17);
					wukongJump = true;
				}
				if (kintoun.transform.position.x > 11f) {
					sunWukong.transform.position = new Vector3 (sunWukong.transform.position.x + ((4f - sunWukong.transform.position.x) * 0.1f),
				                                           sunWukong.transform.position.y + ((0 - sunWukong.transform.position.y) * 0.1f),
				                                           sunWukong.transform.position.z);
				}
				if (kintoun.transform.position.x > 25f) {
					kintoun.SetActive (false);
				}
				if (sunWukong.transform.position.x < 4.1f && prologue && wukongJump) {
					sunWukong.transform.position = new Vector3 (4, 0, 0);
					sunWukongAnim.SetInteger ("FightMove", 1);
				}
				if (sunWukong.transform.position.x == 4f && prologue && wukongJump) {
					screenSrink = true;
					screenEnlarge = false;
					screenShut = false;
					p1HBarFrame.enabled = false;
					p1HBar.enabled = false;
					p1NameText.enabled = false;
					moneyIcon.enabled = false;
					moneyText.enabled = false;
					wukongJump = false;

					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
					panelText.text = "SUN WUKONG:\n\n" +
						"Yos!\nI'm the KING of TURGUL TOURNAMENT... SUN WUKONG!";
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
				}
				if (chatInfo == 1) {
					panelText.text = "SUN WUKONG:\n\n" +
						"I need to test you first, whether you are worthy or not \nto enter the next tournament... Which is the GRAND TOURNAMENT!";
				}
				if (chatInfo == 2) {
					panelText.text = "SUN WUKONG:\n\n" +
						"Let us throw each of our SUPER ATTACK... Yours against mine.\nSo I could see what you are capable of." +
						"\nYou go first!";
				}
				if (chap4Fighting) {
					chap4AttackTimer -= Time.deltaTime * 100f;
                }
				if (chap4AttackTimer < 100f && chap4AttackTimer > 99f && chap4P1Attack) {
					anim.SetInteger ("FightMove", 12);
					sapuJagatVoice.Play ();
				}
				if (chap4AttackTimer <= 65f && chap4AttackTimer > 64f && chap4P1Attack) {
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (player1.transform.position.x + 3f, -0.2f, player1.transform.position.z), Quaternion.identity);
					swipSound.Play ();
				}
				if (chap4AttackTimer <= 50f && chap4AttackTimer >49f && chap4P1Attack) {
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (sunWukong.transform.position.x, -0.2f, sunWukong.transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (sunWukong.transform.position.x, sunWukong.transform.position.y, sunWukong.transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (sunWukong.transform.position.x, sunWukong.transform.position.y, sunWukong.transform.position.z), Quaternion.identity);
					sunWukongAnim.SetInteger ("FightMove", 13);
					hitSound.Play ();
					criticalSound.Play ();
					p2HBar.rectTransform.sizeDelta = new Vector2 (270, p2HBar.GetComponent<RectTransform> ().rect.height);
					cakKumis.transform.localScale = new Vector3 (1, 1, 1);
				}
				if (chap4AttackTimer <= 0 && chap4P1Attack) {
					anim.SetInteger ("FightMove", 2);
					sunWukongAnim.SetInteger ("FightMove", 2);
					chap4P1Attack = false;
					chap4P2Attack = true;
					chap4AttackTimer = chap4AttackTimerMax;
				}
				if (chap4AttackTimer <= 100f && chap4AttackTimer > 99f && chap4P2Attack) {
					sunWukongAnim.SetInteger ("FightMove", 12);
					hawaVoice.Play ();
				}
				if (chap4AttackTimer <= 65f && chap4AttackTimer > 64f && chap4P2Attack) {
					Instantiate (Resources.Load ("Prefabs/ElectroBall2"), new Vector3 (sunWukong.transform.position.x - 3f, -0.2f, sunWukong.transform.position.z), Quaternion.identity);
					swipSound.Play ();
				}
				if (chap4AttackTimer <= 50f && chap4AttackTimer > 49f && chap4P2Attack) {
					Instantiate (Resources.Load ("Prefabs/SuperBlow"), new Vector3 (player1.transform.position.x, 0.2f, player1.transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit2"), new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
					anim.SetInteger ("FightMove", 13);
					hitSound.Play ();
					criticalSound.Play ();
					p1HBar.rectTransform.sizeDelta = new Vector2 (0, p2HBar.GetComponent<RectTransform> ().rect.height);
					cakKumis.transform.localScale = new Vector3 (-1, 1, 1);
				}
				if (chap4AttackTimer <= 0 && chap4P2Attack) {
					anim.SetInteger ("FightMove", 14);
					sunWukongAnim.SetInteger ("FightMove", 1);
					chap4P1Attack = false;
					chap4P2Attack = false;
					chap4AttackTimer = chap4AttackTimerMax;
					chap4Fighting = false;

					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
					panelText.text = "SUN WUKONG:\n\n" +
						"Here, eat this MAGIC BEAN to restore your health!";
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
				}
				if (chatInfo == 4) {
					panelText.text = "SUN WUKONG:\n\n" +
						"Train your self to become stronger,\nthen face me again later in the FINAL MATCH \nat the GRAND TOURNAMENT.";
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);
				}
			}
			if (chapter == 5) {
				wukongShadow.SetActive (false);
				sunWukong.transform.position = new Vector3 (-24, 0, 2);
				sunWukong.transform.localScale = new Vector3 (1, 1, 1);
			}

			if (PlayerPrefs.GetInt ("matchNumb") == 0) {
				IconInit ();
			}
			if (PlayerPrefs.GetInt ("matchNumb") == 1) {
				IconInit ();
				bonangIcon.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("matchNumb") == 2) {
				IconInit ();
				nkIcon.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("matchNumb") == 3) {
				IconInit ();
				ronIcon.SetActive (true);
				ron.transform.position = new Vector3 (-24, 0, -10);
			}
			if (PlayerPrefs.GetInt ("matchNumb") == 4) {
				IconInit ();
				kbhIcon.SetActive (true);
				kitaro.transform.position = new Vector3 (-24, 0, -10);
			}
			if (PlayerPrefs.GetInt ("matchNumb") == 5) {
				IconInit ();
				sunWukongIcon.SetActive (true);
				sunWukong.transform.position = new Vector3 (-24, 0, -10);
			}

			if (!patrickAppear) {
				patrick.transform.position = new Vector3 (-15, 0, -10);
			}

			if (patrickAppear && !fight) {
				patrick.transform.position = new Vector3 (-15, 0, 2);
			}

			if (fromTour) {
				if (moneyTournament > 0) {
					gotSomethingSound.Play ();
					moneyPoint += moneyTournament;
					moneyDynamicPoint = moneyTournament;
					moneyAppearPlus = true;

					ChatOn();
					panelText.text = "You received $" + moneyTournament + " from the last match.";
					leaveButton.GetComponentInChildren<Text> ().text = "OK";
				}
				player1.transform.position = new Vector3 (20, 0, -1);
				player1.transform.localScale = new Vector3 (-1, 1, 1);
				camera1.transform.position = new Vector3 (player1.transform.position.x, camera1.transform.position.y, camera1.transform.position.z);
				fromTour = false;
			}

			moneyText.text = "$" + moneyPoint.ToString ();

			if (moneyAppearPlus) {
				moneyDynamicText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (player1.transform.position.x, 80);
				moneyDynamicText.text = "+$" + moneyDynamicPoint.ToString ();
				moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -6);
				moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, -21);
				StartCoroutine ("MoneyTextFadeOut");
			}

			if (moneyAppearMin) {
				moneyDynamicText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (player1.transform.position.x, 80);
				moneyDynamicText.text = "-$" + moneyDynamicPoint.ToString ();
				moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -6);
				moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, -21);
				StartCoroutine ("MoneyTextFadeOut");
			}

			if (healthAppear) {
				healthText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (player1.transform.position.x, 102);
				healthText.text = "+HP Full";
				p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -6);
				moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, -21);
				StartCoroutine ("HealthTextFadeOut");
			}

			if (blackTop.transform.position.y < 4.3f) {

				screenShut = false;
				screenEnlarge = true;
				if (fight) {
					gongSound.Play ();
					blackTop.transform.position = new Vector3 (camera1.transform.position.x, 10.8f, 0);
					anim.SetBool ("Walk", false);

					if (player1.transform.position.x > patrick.transform.position.x) {
						player1.transform.localScale = new Vector3 (1, 1, 1);
					} else {
						patrick.transform.localScale = new Vector3 (-1, 1, 1);
					}

					player1.transform.position = new Vector3 (-4, 0, 0);
					patrick.transform.position = new Vector3 (4, 0, 0);
					camera1.transform.position = new Vector3 (0, camera1.transform.position.y, camera1.transform.position.z);

					cakKumis.transform.position = new Vector3 (6.5f, 0, 1);
					cakKumis.transform.localScale = new Vector3 (-1, 1, 1);

					anim.SetInteger ("FightMove", 1);
					patrickAnim.SetInteger ("PatrickFightMove", 1);
					bow = true;
				} else {
					player1.transform.position = savePositionP1;
					patrick.transform.position = savePositionP2;

					ChatOn();

					if (justPossessed) {
						darkScene.SetActive (false);
						bGMusic2.Stop ();
						if (!bGMusic.isPlaying) {
							bGMusic.Play ();
						}

						p1HBarFrame.enabled = true;
						p1HBar.enabled = true;
						p1NameText.enabled = true;
						moneyIcon.enabled = true;
						moneyText.enabled = true;

						panelText.text = "PATRICK:\n\n" +
							"Wow Bro!\nYou were acting weard just now.\nWhat's wrong?";
					
						leaveButton.GetComponentInChildren<Text> ().text = "Nothing...";
						justPossessed = false;
					} else if (postModo) {
						bGMusic2.Stop ();
						if (!bGMusic.isPlaying) {
							bGMusic.Play ();
						}
						p1HBarFrame.enabled = true;
						p1HBar.enabled = true;
						p1NameText.enabled = true;
						moneyIcon.enabled = true;
						moneyText.enabled = true;

						player1.transform.localScale = new Vector3 (1, 1, 1);
						nk.transform.position = new Vector3 (5, 0, -10);
						siModo.transform.position = new Vector3 (-4, 1.3f, -10);
//					kitaro.transform.position = new Vector3 (-24, 0, 2);
//					kitaro.transform.localScale = new Vector3(1, 1, 1);
						dynamicCam = false;

						panelText.text = "PATRICK:\n\n" +
							"OK I admit it... I am the NIGHT KNIGHT...\nBut please keep it as a secret.\nDon't tell to anyone OK!";
					
						leaveButton.GetComponentInChildren<Text> ().text = "OK";
						postModo = false;
					} else if (chatKumis) {
						bGMusic2.Stop ();
						if (!bGMusic.isPlaying) {
							bGMusic.Play ();
						}
						p1HBarFrame.enabled = true;
						p1HBar.enabled = true;
						p1NameText.enabled = true;
						moneyIcon.enabled = true;
						moneyText.enabled = true;
						p2NameText.enabled = true;
						bajayOn = true;

						sunWukong.transform.position = new Vector3 (-24, 0, -10);
						cakKumis.transform.localScale = new Vector3 (-1, 1, 1);
						panelText.text = "CHAK KUMIS:\n" +
							"You-are you OK? Saw-I saw you with that MONKEY GUY." +
							"\nWas-he was so strong, taiya. Have-I have a friend that might able to train you to become stronger." +
							"\nName-his name is GLETSER, taiya. Is-he is the guy who sells DOONG-DOONG ICE CREAM." +
							"\nThat-ride that BAJAY TUK-TUK to go to his place." +
							"\nOn-It only cost you $10, taiya.";
					
						leaveButton.GetComponentInChildren<Text> ().text = "Thank You";
					} else {
						anim.SetInteger ("FightMove", 0);
						patrickAnim.SetInteger ("PatrickFightMove", 0);


						panelText.text = "PATRICK:\n\n" +
							"Thanks for the sparring match Bro!\nHere, $" + moneyDynamicPoint + " for you.\nGo buy SATAY to restore your health!";

						leaveButton.GetComponentInChildren<Text> ().text = "Thank You";

						moneyAppearPlus = true;

						gotSomethingSound.Play ();

						cakKumis.transform.position = new Vector3 (2.8f, 0, 2);
						cakKumis.transform.localScale = new Vector3 (1, 1, 1);
					}

					if (player1.transform.position.x > patrick.transform.position.x) {
						player1.transform.localScale = new Vector3 (-1, 1, 1);
					} else {
						patrick.transform.localScale = new Vector3 (-1, 1, 1);
					}
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
			if (bow) {
				readyToFightTimer -= Time.deltaTime * 100f;

				//p1HBar.rectTransform.sizeDelta = new Vector2 (300, p1HBar.GetComponent<RectTransform> ().rect.height);
				p2HBar.rectTransform.sizeDelta = new Vector2 (300, p2HBar.GetComponent<RectTransform> ().rect.height);
				p1AttBar.rectTransform.sizeDelta = new Vector2 (0, p1AttBar.GetComponent<RectTransform> ().rect.height);
				p2AttBar.rectTransform.sizeDelta = new Vector2 (0, p2AttBar.GetComponent<RectTransform> ().rect.height);
				p1DefBar.rectTransform.sizeDelta = new Vector2 (0, p1DefBar.GetComponent<RectTransform> ().rect.height);
				p2DefBar.rectTransform.sizeDelta = new Vector2 (0, p2DefBar.GetComponent<RectTransform> ().rect.height);
			}

			if (readyToFightTimer <= 0) {
				bow = false;
				readyToFightTimer = readyToFightTimerMax;
				anim.SetInteger ("FightMove", 2);
				patrickAnim.SetInteger ("PatrickFightMove", 2);
				fightStart = true;
                hitFxPool.SetActive(true);
			}

			if (fightStart) {
				fightStartTimer -= Time.deltaTime * 100f;

				FightScene ();
			}

			if (fightStartTimer <= 0) {
				fightStart = false;
				fightStartTimer = fightStartTimerMax;
				p1MoveFwd = true;
			}

			if (p1MoveFwd) {
				player1.transform.position = new Vector3 (player1.transform.position.x + ((-1f - player1.transform.position.x) * 0.4f), player1.transform.position.y, player1.transform.position.z);
				patrick.transform.position = new Vector3 (patrick.transform.position.x + ((1f - patrick.transform.position.x) * 0.4f), patrick.transform.position.y, patrick.transform.position.z);
				anim.SetInteger ("FightMove", 3);
				patrickAnim.SetInteger ("PatrickFightMove", 3);
			}

			if (player1.transform.position.x > -1.1f && p1MoveFwd) {
				Instantiate (Resources.Load ("Prefabs/PunchClash1"), new Vector3 (0, -1, 0), Quaternion.identity);
				punchSound.Play ();
				p1AttBar.rectTransform.sizeDelta = new Vector2 (p1AttBar.GetComponent<RectTransform> ().rect.width + attPoint, p1AttBar.GetComponent<RectTransform> ().rect.height);
				p2AttBar.rectTransform.sizeDelta = new Vector2 (p2AttBar.GetComponent<RectTransform> ().rect.width + attPoint, p2AttBar.GetComponent<RectTransform> ().rect.height);
				p1DefBar.rectTransform.sizeDelta = new Vector2 (p1DefBar.GetComponent<RectTransform> ().rect.width + defPoint, p1DefBar.GetComponent<RectTransform> ().rect.height);
				p2DefBar.rectTransform.sizeDelta = new Vector2 (p2DefBar.GetComponent<RectTransform> ().rect.width + defPoint, p2DefBar.GetComponent<RectTransform> ().rect.height);

				player1.transform.position = new Vector3 (-1.95f, player1.transform.position.y, player1.transform.position.z);
				patrick.transform.position = new Vector3 (1.95f, patrick.transform.position.y, patrick.transform.position.z);

				anim.SetInteger ("FightMove", 2);
				patrickAnim.SetInteger ("PatrickFightMove", 2);
				p1MoveFwd = false;
				fighting = true;
			}

			if (p2ActionTimer <= (p2ActionTimerInit - 10f) && p2ActionTimer > (p2ActionTimerInit - 11f) && fighting) {
				anim.SetInteger ("FightMove", 2);
				patrickAnim.SetInteger ("PatrickFightMove", 2);
				player1.transform.position = new Vector3 (player1.transform.position.x + ((-2f - player1.transform.position.x) * 0.5f), player1.transform.position.y, player1.transform.position.z);
				patrick.transform.position = new Vector3 (patrick.transform.position.x + ((2f - patrick.transform.position.x) * 0.5f), patrick.transform.position.y, patrick.transform.position.z);
			}

			if (fighting) {

				p2ActionTimer -= Time.deltaTime * 100f;
				addDefBarTimer -= Time.deltaTime * 100f;

				if (addDefBarTimer <= 0) {
					p1DefBar.rectTransform.sizeDelta = new Vector2 (p1DefBar.GetComponent<RectTransform> ().rect.width + defPoint, p1DefBar.GetComponent<RectTransform> ().rect.height);
					p2DefBar.rectTransform.sizeDelta = new Vector2 (p2DefBar.GetComponent<RectTransform> ().rect.width + defPoint, p2DefBar.GetComponent<RectTransform> ().rect.height);
					addDefBarTimer = addDefBarTimerInit;
				}

				if (p2ActionTimer <= 0) {
					anim.SetInteger ("FightMove", 5);
					patrickAnim.SetInteger ("PatrickFightMove", Random.Range (6, 10));
					attackVoice1 = Random.Range (1, 3);
					if (attackVoice1 == 1 && attack1Voice.isPlaying == false) {
						attack1Voice.Play ();
					}
					if (attackVoice1 == 2 && attack2Voice.isPlaying == false) {
						attack2Voice.Play ();
					}

					blockSound.Play ();

					p1DefBar.rectTransform.sizeDelta = new Vector2 (p1DefBar.GetComponent<RectTransform> ().rect.width - (defPoint / 2), p1DefBar.GetComponent<RectTransform> ().rect.height);
					p2AttBar.rectTransform.sizeDelta = new Vector2 (p2AttBar.GetComponent<RectTransform> ().rect.width + attPoint, p2AttBar.GetComponent<RectTransform> ().rect.height);
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-1f - player1.transform.position.x) * 0.5f), player1.transform.position.y, Random.Range (-0.01f, 0.02f));
					patrick.transform.position = new Vector3 (patrick.transform.position.x + ((1f - patrick.transform.position.x) * 0.5f), patrick.transform.position.y, Random.Range (-0.01f, 0.02f));
					Instantiate (Resources.Load ("Prefabs/PunchClash2"), new Vector3 (0, -1, 0), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (-1, -1, 0), Quaternion.identity);
					p2ActionTimer = p2ActionTimerInit;
				}

				if (Input.GetMouseButtonDown (0)) {

					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                    for (int i =0; i< hitFx.Length; i++)
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
							p1RanAttack = Random.Range (6, 10);
							p2RanAttack = Random.Range (5, 10);

							if (p2RanAttack == 5) {
								p2RanAttack = Random.Range (1, 3);
								if (p2RanAttack == 1) {
									p2RanAttack = 5;
								} else {
									p2RanAttack = Random.Range (5, 10);
								}
							}

							anim.SetInteger ("FightMove", p1RanAttack);
							patrickAnim.SetInteger ("PatrickFightMove", p2RanAttack);

							if (attack1Voice.isPlaying == false) {
								attack1Voice.Play ();
							}
							if (attack2Voice.isPlaying == false) {
								attack2Voice.Play ();
							}

							/*attackVoice1 = Random.Range (1, 3);
						attackVoice2 = Random.Range (1, 3);
						if (attackVoice1 == 1){
							attack1Voice.Play ();
						}
						if (attackVoice1 == 2){
							attack2Voice.Play ();
						}
						if (attackVoice2 == 1){
							attack1Voice.Play ();
						}
						if (attackVoice2 == 2){
							attack2Voice.Play ();
						}*/

							player1.transform.position = new Vector3 (player1.transform.position.x + ((-1f - player1.transform.position.x) * 0.5f), player1.transform.position.y, Random.Range (-0.01f, 0.02f));
							patrick.transform.position = new Vector3 (patrick.transform.position.x + ((1f - patrick.transform.position.x) * 0.5f), patrick.transform.position.y, Random.Range (-0.01f, 0.02f));

							p1AttBar.rectTransform.sizeDelta = new Vector2 (p1AttBar.GetComponent<RectTransform> ().rect.width + attPoint, p1AttBar.GetComponent<RectTransform> ().rect.height);
						
							if (p2RanAttack > 5 && p2RanAttack < 10) {
								p2AttBar.rectTransform.sizeDelta = new Vector2 (p2AttBar.GetComponent<RectTransform> ().rect.width + attPoint, p2AttBar.GetComponent<RectTransform> ().rect.height);
								punchSound.Play ();
							}
						
							if (p2RanAttack == 5) {
								p2DefBar.rectTransform.sizeDelta = new Vector2 (p2DefBar.GetComponent<RectTransform> ().rect.width - (defPoint / 2), p2DefBar.GetComponent<RectTransform> ().rect.height);
								Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (1, -1, 0), Quaternion.identity);
								blockSound.Play ();
							}

						}
					}

				}

				if (Input.GetMouseButtonUp (0)) {
					Instantiate (Resources.Load ("Prefabs/PunchClash2"), new Vector3 (0, -1, 0), Quaternion.identity);
					anim.SetInteger ("FightMove", 2);
					patrickAnim.SetInteger ("PatrickFightMove", 2);
				
					player1.transform.position = new Vector3 (player1.transform.position.x + ((-2f - player1.transform.position.x) * 0.5f), player1.transform.position.y, player1.transform.position.z);
					patrick.transform.position = new Vector3 (patrick.transform.position.x + ((2f - patrick.transform.position.x) * 0.5f), patrick.transform.position.y, patrick.transform.position.z);
				}

			}

			// --- Entering strolling mode from fighting mode ---
			if (strollingStart) {
				strollingTimer -= Time.deltaTime * 100f;
			}

			if (strollingTimer <= 0) {
				strollingStart = false;
				screenShut = true;
				screenEnlarge = false;
				Initial ();
				fight = false;
                hitFxPool.SetActive(false);
                //p1Script.joystick.SetActive (true);

				prologue = false;

				henshinTimer = henshinTimerMax;

				strollingTimer = strollingTimerMax;
			}

		}

	}

	void LoadResources (){

		player1 = GameObject.Find ("Bambang");
		patrick = GameObject.Find ("Patrick");
		dakochan = GameObject.Find ("Dakochan");
		ron = GameObject.Find ("Ron");
		kitaro = GameObject.Find ("Kitaro");
		sunWukong = GameObject.Find ("SunWukong");
		nk = GameObject.Find ("NK");
		siModo = GameObject.Find ("SiModo");
		cakKumis = GameObject.Find ("CakKumis");
		counterLady = GameObject.Find ("CounterLady");
		bouncer = GameObject.Find ("Bouncer");
		bajay = GameObject.Find ("Bajay");
		kintoun = GameObject.Find ("Kintoun");
		wukongShadow = GameObject.Find ("wukong_shadow");
		bonangIcon = GameObject.Find ("Bonang_Icon");
		nkIcon = GameObject.Find ("NK_Icon");
		ronIcon = GameObject.Find ("Ron_Icon");
		kbhIcon = GameObject.Find ("KBH_Icon");
		sunWukongIcon = GameObject.Find ("SunWukong_Icon");
		camera1 = GameObject.Find ("MainCamera");
		blackTop = GameObject.Find ("BlackTop");
		blackBottom = GameObject.Find ("BlackBottom");
		darkScene = GameObject.Find ("DarkScene");
		superScene = GameObject.Find ("SuperScene");

		anim = player1.GetComponent<Animator> ();
		patrickAnim = patrick.GetComponent<Animator> ();
		dakochanAnim = dakochan.GetComponent<Animator> ();
		ronAnim = ron.GetComponent<Animator> ();
		kitaroAnim = kitaro.GetComponent<Animator> ();
		sunWukongAnim = sunWukong.GetComponent<Animator> ();
		nkAnim = nk.GetComponent<Animator> ();

	}

	public void Initial (){

		p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 40f);
		p2HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 40f);
		p1AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, -10f);
		p2AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, -10f);
		p1DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		p2DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);

		p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);

		fightButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		satayButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		registerButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		enterButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		exitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, -800);
		nextButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, -800);
		trainingButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		att1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		att2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		att3Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (att3Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		def1Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def1Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);
		def2Button.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (def2Button.GetComponentInChildren<RectTransform>().anchoredPosition.x, 50f);

		resumeButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -1000f);
		quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -1000f);

		moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 50);
		moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, 21);
		panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -140);
		pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -1000);

		panelText.text = " ";
		pauseText.text = " ";

        BoxColliderOn();

    }

	void charsNotAppear () {

		dakochan.transform.position = new Vector3 (4, 0, -10);
		ron.transform.position = new Vector3 (-24, 0, -10);
		kitaro.transform.position = new Vector3 (-24, 0, -10);
		sunWukong.transform.position = new Vector3 (-24, 0, -10);
		nk.transform.position = new Vector3 (5, 0, -10);
		siModo.transform.position = new Vector3 (-4, 1.3f, -10);

//		dakochan.SetActive (false);
//		ron.SetActive (false);
//		kitaro.SetActive (false);
//		sunWukong.SetActive (false);
//		siModo.SetActive (false);

	}

	void IconInit () {

		bonangIcon.SetActive (false);
		nkIcon.SetActive (false);
		ronIcon.SetActive (false);
		kbhIcon.SetActive (false);
		sunWukongIcon.SetActive (false);

	}

	void FightScene (){

		p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, -20f);
		p2HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, -20f);
		p1AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 10f);
		p2AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2AttBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 10f);
		p1DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);
		p2DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2DefBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, -50f);

		p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);

		p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
		p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);

		p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);
		p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Att3Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, 32f);

		p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def1Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);
		p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p2Def2Inactive.GetComponentInChildren<RectTransform>().anchoredPosition.x, -72f);

	}

	void ScreenSrinking (){

		blackTop.transform.position = new Vector3 (camera1.transform.position.x, blackTop.transform.position.y + ((9.45f - blackTop.transform.position.y) * 0.1f), 0);
		blackBottom.transform.position = new Vector3 (camera1.transform.position.x, blackBottom.transform.position.y + ((-9.45f - blackBottom.transform.position.y) * 0.1f), 0);
		if (blackTop.transform.position.y < 9.5f) {
			p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
			moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -6);
			moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, -21);
		}

	}

	void ScreenEnlarging (){
		
		blackTop.transform.position = new Vector3 (camera1.transform.position.x, blackTop.transform.position.y + ((10.8f - blackTop.transform.position.y) * 0.1f), 0);
		blackBottom.transform.position = new Vector3 (camera1.transform.position.x, blackBottom.transform.position.y + ((-10.8f - blackBottom.transform.position.y) * 0.1f), 0);
		
	}

	void ScreenShutting (){
		
		blackTop.transform.position = new Vector3 (camera1.transform.position.x, blackTop.transform.position.y + ((4f - blackTop.transform.position.y) * 0.1f), 0);
		blackBottom.transform.position = new Vector3 (camera1.transform.position.x, blackBottom.transform.position.y + ((-4f - blackBottom.transform.position.y) * 0.1f), 0);
		
	}

	IEnumerator SuperSceneFadeIn(){

		for (float i = 0f; i <= 1f; i+= 0.1f) {
			superScene.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds(0.05f);
			//yield return null;
		}

	}

	IEnumerator MoneyTextFadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
				moneyAppearPlus = false;
				moneyAppearMin = false;
				moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 50);
				moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, 21);
			}
			moneyDynamicText.color = new Color (1f, 1f, 0, i);
			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator HealthTextFadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
				p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 40f);
				moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 50);
				moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, 21);
				healthAppear = false;
			}
			healthText.color = new Color (0.5f, 0, 0, i);
			yield return new WaitForSeconds(0.1f);
		}
	}

	void BoxColliderOn()
	{
        patrick.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ron.GetComponent<BoxCollider2D>().enabled = true;
		kitaro.GetComponent<BoxCollider2D>().enabled = true;
		sunWukong.GetComponent<BoxCollider2D>().enabled = true;
		cakKumis.GetComponent<BoxCollider2D>().enabled = true;
		counterLady.GetComponent<BoxCollider2D>().enabled = true;
		bouncer.GetComponent<BoxCollider2D>().enabled = true;
	}

    void BoxColliderOff()
    {
        patrick.gameObject.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        ron.GetComponent<BoxCollider2D>().enabled = false;
        kitaro.GetComponent<BoxCollider2D>().enabled = false;
        sunWukong.GetComponent<BoxCollider2D>().enabled = false;
        cakKumis.GetComponent<BoxCollider2D>().enabled = false;
        counterLady.GetComponent<BoxCollider2D>().enabled = false;
        bouncer.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ChatOn()
	{
        chat = true;
		BoxColliderOff();
        blocker.SetActive(true);
        panel.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(0, 0);
        leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(140, 6);
    }

	public void OnClickedLeave (Button leaveButton) {

		if (Time.timeScale != 0) {
			buttonSound.Play ();
			screenSrink = false;
			screenEnlarge = true;
			Initial ();
			if (player1.transform.position.x == patrick.transform.position.x + 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x + 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			if (player1.transform.position.x == patrick.transform.position.x - 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			cakKumis.transform.localScale = new Vector3 (1, 1, 1);
			chat = false;
			moneyChecked = false;
			//p1Script.joystick.SetActive (true);
			anim.SetInteger ("FightMove", 0);
			cakKumis.SetActive (true);
			chatKumis = false;

            blocker.SetActive(false);

            if (prologue)
			{
                if (chapter == 2)
					MoveLeftButton.SetActive(true);
            }


            if (bajayOn && bajayStop) {

				player1.transform.position = new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z + 1f);
				bajayStop = false;
			}
		}

	}

	public void OnClickedNext (Button nextButton) {

		if (Time.timeScale != 0) {
			buttonSound.Play ();

			if (chapter == 3) {
				if (chatInfo == 2) {

					chatInfo = 3;

				} else if (chatInfo == 1) {

					if (!mantraVoice.isPlaying) {
						mantraVoice.Play ();
					}
					kitaroAnim.SetInteger ("FightMove", 1);
					panelText.text = " ";
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, -800);
					chatInfo = 2;

				} else if (chatInfo == 0) {

					chatInfo = 1;
				}
			} else if (chapter == 4) {
				if (chatInfo == 4) {
				
					panelText.text = " ";
					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -140);
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, -800);

					chatKumis = true;
					strollingStart = true;
					screenSrink = false;
					savePositionP1 = new Vector3 (-0.2f, 0, 2);

					chatInfo = 5;
				
				} else if (chatInfo == 3) {

					gotSomethingSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Twinkle2"), new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
					p1HBar.rectTransform.sizeDelta = new Vector2 (300, p2HBar.GetComponent<RectTransform> ().rect.height);
					anim.SetInteger ("FightMove", 0);
					chatInfo = 4;
				
				} else if (chatInfo == 2) {

					panelText.text = " ";
					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -140);
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, -800);

					anim.SetInteger ("FightMove", 2);
					sunWukongAnim.SetInteger ("FightMove", 2);

					p1HBarFrame.enabled = true;
					p1HBar.enabled = true;
					p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
					p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
					p2NameText.enabled = false;

					chap4Fighting = true;
					chap4P1Attack = true;

					cakKumis.transform.localScale = new Vector3 (-1, 1, 1);

					chatInfo = 3;
				
				} else if (chatInfo == 1) {

					chatInfo = 2;
				
				} else if (chatInfo == 0) {
				
					chatInfo = 1;
				}
			}
		}

	}

	public void OnClickedExit (Button exitButton) {

		//buttonSound.Play ();
		//PlayerPrefs.SetInt ("moneyPoint", moneyPoint);
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

	public void OnClickedFight (Button FightButton) {

		if (Time.timeScale != 0) {
			buttonSound.Play ();
			fight = true;
			screenShut = true;
			screenSrink = false;
			Initial ();
			/*if (player1.transform.position.x == patrick.transform.position.x + 3f){
				player1.transform.position = new Vector3 (player1.transform.position.x + 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			if (player1.transform.position.x == patrick.transform.position.x - 3f){
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}*/
			savePositionP1 = new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z);
			savePositionP2 = new Vector3 (patrick.transform.position.x, patrick.transform.position.y, patrick.transform.position.z);

			chat = false;
            blocker.SetActive(false);
        }
				
	}

	public void OnClickedSatay (Button satayButton) {

		if (Time.timeScale != 0) {
			chachingSound.Play ();
			gotSomethingSound.Play ();
			moneyDynamicPoint = 15;
			moneyPoint -= moneyDynamicPoint;
			p1HBar.rectTransform.sizeDelta = new Vector2 (300, p1HBar.GetComponent<RectTransform> ().rect.height);
			moneyAppearMin = true;

			screenSrink = false;
			screenEnlarge = true;
			Initial ();

			healthAppear = true;

			if (player1.transform.position.x == cakKumis.transform.position.x + 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x + 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			if (player1.transform.position.x == cakKumis.transform.position.x - 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			cakKumis.transform.localScale = new Vector3 (1, 1, 1);
			chat = false;
			moneyChecked = false;
			//p1Script.joystick.SetActive (true);
            blocker.SetActive(false);
            /*if (prologue)
                p1Script.joystick.SetActive(true);*/

        }

	}

	public void OnClickedRegister (Button registerButton) {

		if (Time.timeScale != 0) {
			chachingSound.Play ();
			moneyDynamicPoint = 100;
			moneyPoint -= moneyDynamicPoint;
			moneyAppearMin = true;

			registered = true;

			if (!p1Lost && PlayerPrefs.GetInt ("tournamentNumb") != 4) {
				PlayerPrefs.SetInt ("tournamentNumb", PlayerPrefs.GetInt ("tournamentNumb") + 1);
			} else if (p1Lost || PlayerPrefs.GetInt ("tournamentNumb") == 4) {
				p1Lost = false;
				PlayerPrefs.SetInt ("tournamentNumb", PlayerPrefs.GetInt ("tournamentNumb"));
			}
		
			screenSrink = false;
			screenEnlarge = true;
			Initial ();

			if (player1.transform.position.x == counterLady.transform.position.x - 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}

			if (PlayerPrefs.GetInt ("matchNumb") == 0 || PlayerPrefs.GetInt ("matchNumb") == 1) {
				PlayerPrefs.SetInt ("matchNumb", 1);
			} else if (PlayerPrefs.GetInt ("matchNumb") == 2) {
				PlayerPrefs.SetInt ("matchNumb", 2);
			} else if (PlayerPrefs.GetInt ("matchNumb") == 3) {
				PlayerPrefs.SetInt ("matchNumb", 3);
			} else if (PlayerPrefs.GetInt ("matchNumb") == 4) {
				PlayerPrefs.SetInt ("matchNumb", 4);
			} else if (PlayerPrefs.GetInt ("matchNumb") == 5) {
				PlayerPrefs.SetInt ("matchNumb", 5);
			}

			chat = false;
			moneyChecked = false;
			//p1Script.joystick.SetActive (true);
            blocker.SetActive(false);
        }
		
	}

	public void OnClickedEnter (Button enterButton) {

		if (Time.timeScale != 0) {
			buttonSound.Play ();
			/*screenSrink = false;
			screenEnlarge = true;
			Initial ();
			
			if (player1.transform.position.x == counterLady.transform.position.x - 3f){
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			
			chat = false;
			moneyChecked = false;
			p1Script.joystick.SetActive (true);*/

			LoadLevel ();
		}
		
	}

	public void LoadLevel (){
		
		StartCoroutine (LevelCoroutine ());
		
	}

	IEnumerator LevelCoroutine (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (3);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}

	public void OnClickedTraining (Button trainingButton) {

		if (Time.timeScale != 0) {
			chachingSound.Play ();
			moneyDynamicPoint = 10;
			moneyPoint -= moneyDynamicPoint;
			moneyAppearMin = true;
		
			LoadLevel2 ();
		}
		
	}

	public void LoadLevel2 (){
		
		StartCoroutine (LevelCoroutine2 ());
		
	}

	IEnumerator LevelCoroutine2 (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (6);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}

	public void OnClickedAtt1 (Button att1Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1Script.SAttack1 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar.rectTransform.sizeDelta = new Vector2 (p1AttBar.GetComponent<RectTransform> ().rect.width - 100f, p1AttBar.GetComponent<RectTransform> ().rect.height);
			Initial ();

			p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
			p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);

			if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 100 && p2DefBar.GetComponent<RectTransform> ().rect.width < 200) {
				p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
				p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}
	}

	public void OnClickedAtt2 (Button att2Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1Script.SAttack2 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar.rectTransform.sizeDelta = new Vector2 (p1AttBar.GetComponent<RectTransform> ().rect.width - 200f, p1AttBar.GetComponent<RectTransform> ().rect.height);
			Initial ();
		
			p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
			p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
		
			if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 100 && p2DefBar.GetComponent<RectTransform> ().rect.width < 200) {
				p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
				p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}
		
	}

	public void OnClickedAtt3 (Button att3Button) {

		if (Time.timeScale != 0) {
			fightSound.Play ();
			fighting = false;
			p1Script.SAttack3 = true;
			StartCoroutine ("SuperSceneFadeIn");
			p1AttBar.rectTransform.sizeDelta = new Vector2 (p1AttBar.GetComponent<RectTransform> ().rect.width - 300f, p1AttBar.GetComponent<RectTransform> ().rect.height);
			Initial ();
		
			p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
			p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
		
			if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 100 && p2DefBar.GetComponent<RectTransform> ().rect.width < 200) {
				p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		
			if (p2DefBar.GetComponent<RectTransform> ().rect.width >= 200) {
				p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def1Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
				p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2Def2Active.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}
		
	}

	public void OnClickedDef1 (Button def1Button) {

		if (Time.timeScale != 0) {
			if (patrickScript.P2SAttack1 || patrickScript.P2SAttack2 || patrickScript.P2SAttack3) {
				fightSound.Play ();
				p1Script.Block = true;
				p1Script.Dodge = false;
				p1DefBar.rectTransform.sizeDelta = new Vector2 (p1DefBar.GetComponent<RectTransform> ().rect.width - 100f, p1DefBar.GetComponent<RectTransform> ().rect.height);
				Initial ();
				p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1Def1Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}

	}

	public void OnClickedDef2 (Button def2Button) {
		if (Time.timeScale != 0) {
			if (patrickScript.P2SAttack1 || patrickScript.P2SAttack2 || patrickScript.P2SAttack3) {
				fightSound.Play ();
				p1Script.Block = false;
				p1Script.Dodge = true;
				print ("DODGE");
				p1DefBar.rectTransform.sizeDelta = new Vector2 (p1DefBar.GetComponent<RectTransform> ().rect.width - 200f, p1DefBar.GetComponent<RectTransform> ().rect.height);
				Initial ();
				p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p2HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1Def2Inactive.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -72f);
			}
		}

	}

    public bool TargetVisible(Camera c, GameObject go)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = go.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
                return false;
        }
        return true;
    }

}
