using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrainingScript : MonoBehaviour {

	P1TrainingScript p1Script;

	public GameObject player1;
    public GameObject cloudButton;
	GameObject gletser;
	GameObject bajay;
	GameObject camera1;
	GameObject blackTop;
	GameObject blackBottom;

    public GameObject hitFxPool;
    public GameObject[] hitFx;

    public GameObject spark;
	public GameObject dust;
	public GameObject cosmo;
	
	public Image p1HBarFrame;
	public Image p1HBar;
	public Image moneyIcon;

	public Image panel;
	public Image pausePanel;

	public Text moneyText;
	public Text moneyDynamicText;
	public Text healthText;
	public Text panelText;
	public Text p1NameText;
	public Text pauseText;
	
	public Button satayButton;
	public Button leaveButton;
	public Button nextButton;
	public Button backButton;
	public Button resumeButton;
	public Button quitButton;

	public AudioSource bGMusic;
	public AudioSource bajaySound;	
	public AudioSource pukulanVoice;
	public AudioSource punchSound;
	public AudioSource blockSound;
	public AudioSource jumpSound;
	public AudioSource hitSound;
	public AudioSource swipSound;
	public AudioSource buttonSound;
	public AudioSource gongSound;
	public AudioSource gotSomethingSound;
	public AudioSource chachingSound;
	public AudioSource fightSound;
	public AudioSource swooshSound;
	public AudioSource debu2Intan;
	public AudioSource waahVoice;

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
	int henshinTimer = 100;
	int henshinTimerMax = 100;
	int chap4AttackTimer = 200;
	int chap4AttackTimerMax = 200;

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
	public bool training = false;
	public bool screenSrink = false;
	public bool screenEnlarge = false;
	public bool screenShut = false;
	bool bow = false;
	public bool fightStart = false;
	public bool fighting = false;
	bool p1MoveFwd = false;
	bool p2Movefwd = false;

	public bool strollingStart = false;
	public bool p1Lost = false;
	public bool fromTour = false;
	public bool prologue = false;
	public bool bajayStop = false;
	public bool notFirstTime = false;
	public bool success = false;

	bool dustStart = false;
	float dustStartTimer = 80;
	float dustStartTimerMax = 80;

	Vector3 savePositionP1;
	Vector3 savePositionP2;

	RaycastHit hit;
	
	public Animator anim;
	public Animator gletserAnim;

	public GameObject loadingScene;
	public Image loadingBar;
	public Text loadingText;

	public float strengthValue = 27f;

	void Start () {

		moneyPoint = PlayerPrefs.GetInt ("moneyPoint");
		p1HBarX = PlayerPrefs.GetFloat ("p1HBarX");
		notFirstTime = PlayerPrefs.GetInt ("notFirstTime") > 0;
		success = PlayerPrefs.GetInt ("success") > 0;
        //success = false;    //Activate it to reset training

		p1Script = GameObject.Find ("Bambang").GetComponent<P1TrainingScript> ();

		LoadResources ();
		Initial ();

		loadingScene.SetActive (false);

		moneyDynamicText.text = " ";
		healthText.text = " ";

		p1HBar.rectTransform.sizeDelta = new Vector2 (p1HBarX, p1HBar.GetComponent<RectTransform> ().rect.height);

		spark.SetActive (false);
		dust.SetActive (false);
		cosmo.SetActive (false);

	}

	void Update () {

		PlayerPrefs.SetInt ("moneyPoint", moneyPoint);
		PlayerPrefs.SetFloat ("p1HBarX", p1HBar.GetComponent<RectTransform> ().rect.width);
		PlayerPrefs.SetInt ("notFirstTime", notFirstTime ? 1 : 0);
		PlayerPrefs.SetInt ("success", success ? 1 : 0);

		if (Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale = 0;
			resumeButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, 0);
			quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -50f);
			pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			pauseText.text = "PAUSE";
			
		}

		if (Time.timeScale != 0) {

			if (p1HBar.GetComponent<RectTransform> ().rect.width <= 0) {

				p1HBar.rectTransform.sizeDelta = new Vector2 (0, p1HBar.GetComponent<RectTransform> ().rect.height);
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

			if (screenSrink) {
				ScreenSrinking ();
			}
		
			if (screenEnlarge) {
				ScreenEnlarging ();
			}
		
			if (screenShut) {
				ScreenShutting ();
			}

			if (player1.transform.position.x < gletser.transform.position.x + 3f && player1.transform.position.x > gletser.transform.position.x - 3f &&
				player1.transform.position.z == gletser.transform.position.z && !chat) {

                ChatOn();
			}

			if (blackTop.transform.position.y < 4.3f) {
			
				screenShut = false;
				screenEnlarge = true;

				blackTop.transform.position = new Vector3 (camera1.transform.position.x, 10.8f, 0);
				anim.SetBool ("Walk", false);

				if (fight) {

					notFirstTime = true;

                    cloudButton.SetActive(false);
				
					if (player1.transform.position.x > gletser.transform.position.x) {
						player1.transform.localScale = new Vector3 (1, 1, 1);
					} else {
						gletser.transform.localScale = new Vector3 (-1, 1, 1);
					}
				
					player1.transform.position = new Vector3 (-7, 0, 0);
					gletser.transform.position = new Vector3 (7.7f, 0, 0);
					camera1.transform.position = new Vector3 (0, camera1.transform.position.y, camera1.transform.position.z);

					bajay.transform.position = new Vector3 (-90f, bajay.transform.position.y, bajay.transform.position.z);
					bajay.SetActive (false);
				
					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
					panelText.text = "GLETSER:\n\n" +
						"You need to move toward to me by TAPPING THE SCREEN RAPIDLY while I attack you with my SPECIAL TECHNIC." +
						"\nYour aim is to reach to this white line in front of me." +
						"\nYou will then attack me with one punch." +
						"\nARE YOU READY?!!";
				
					nextButton.GetComponentInChildren<Text> ().text = "I'm Ready!";
					nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (-140, 6);


				} else {

					player1.transform.position = savePositionP1;
					gletser.transform.position = savePositionP2;

					anim.SetInteger ("FightMove", 0);
					gletserAnim.SetInteger ("Move", 0);

					if (player1.transform.position.x > gletser.transform.position.x) {
						player1.transform.localScale = new Vector3 (-1, 1, 1);
					} else {
						gletser.transform.localScale = new Vector3 (-1, 1, 1);
					}

					panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 0);

					if (success) {
						panelText.text = "GLETSER:\n" +
							"Congratulations! You have mastered the COSMO POWER." +
							"\nNow you have become stronger than before." +
							"\nThe training has also cleansed your soul from the devil.\n\n" +
							"\nClick this icon during your fight in the tournament" +
							"\nto activate your COSMO POWER.";
				
						leaveButton.GetComponentInChildren<Text> ().text = "Thank You";
						cosmo.SetActive (true);
						gotSomethingSound.Play ();
					} else {

						panelText.text = "GLETSER:\n\n" +
							"Let's have a break for now." +
							"\nJust talk to me again later if you wanna have another training session.";

						leaveButton.GetComponentInChildren<Text> ().text = "OK";

					}

					leaveButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, 6);



				}
			}

			if (dustStart) {
				dustStartTimer -= Time.deltaTime * 50f;
			}
			if (dustStartTimer <= 0) {
				dustStart = false;
				dust.SetActive (true);
				swipSound.Play ();
				anim.SetInteger ("FightMove", 18);
				training = true;
				p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform> ().anchoredPosition.x, -20f);
				dustStartTimer = dustStartTimerMax;
                hitFxPool.SetActive(true);
            }

			if (training) {

				p1HBar.rectTransform.sizeDelta = new Vector2 (p1HBar.GetComponent<RectTransform> ().rect.width - 8f * Time.deltaTime, p1HBar.GetComponent<RectTransform> ().rect.height);

				player1.transform.position = new Vector3 (player1.transform.position.x - 1f * Time.deltaTime, player1.transform.position.y, player1.transform.position.z);
				Instantiate (Resources.Load ("Prefabs/BambangShadow"), new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);

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
						
							player1.transform.position = new Vector3 (player1.transform.position.x + strengthValue * Time.deltaTime, player1.transform.position.y, player1.transform.position.z);
						
						}
					}
				
				}

				if (player1.transform.position.x >= 4) {
					training = false;
					pukulanVoice.Play ();
					player1.transform.position = new Vector3 (4f, player1.transform.position.y, player1.transform.position.z);
					anim.SetInteger ("FightMove", 10);
					gletserAnim.SetInteger ("Move", 2);
					dust.SetActive (false);
					spark.SetActive (true);
					Instantiate (Resources.Load ("Prefabs/Hit"), new Vector3 (player1.transform.position.x + 2, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
					Instantiate (Resources.Load ("Prefabs/BlockClash"), new Vector3 (player1.transform.position.x + 2, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
					hitSound.Play ();
					blockSound.Play ();
					Instantiate (Resources.Load ("Prefabs/Dakochan"), new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
					waahVoice.Play ();

					success = true;
					strollingStart = true;
					screenSrink = false;
				}

				if (p1HBar.GetComponent<RectTransform> ().rect.width <= 0 && player1.transform.position.x < 4) {
					training = false;
					anim.SetInteger ("FightMove", 14);
					gletserAnim.SetInteger ("Move", 2);
					dust.SetActive (false);
					strollingStart = true;
					screenSrink = false;
				}

			}

			if (strollingStart) {
				strollingTimer -= Time.deltaTime *100f;
			}
		
			if (strollingTimer <= 0) {
				strollingStart = false;
				screenShut = true;
				screenEnlarge = false;
				Initial ();
				fight = false;
				p1Script.joystick.SetActive (true);
                hitFxPool.SetActive(false);
                strollingTimer = strollingTimerMax;
			}

		}

	}

	void LoadResources (){
		
		player1 = GameObject.Find ("Bambang");
		gletser = GameObject.Find ("Gletser");
		bajay = GameObject.Find ("Bajay");

		camera1 = GameObject.Find ("MainCamera");
		blackTop = GameObject.Find ("BlackTop");
		blackBottom = GameObject.Find ("BlackBottom");
		
		anim = player1.GetComponent<Animator> ();
		gletserAnim = gletser.GetComponent<Animator> ();
		
	}

	public void Initial (){
		
		p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (p1HBarFrame.GetComponentInChildren<RectTransform>().anchoredPosition.x, 40f);

		satayButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		backButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (-140, -800);
		leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, -800);
		nextButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (140, -800);

		resumeButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -1000f);
		quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -1000f);

		moneyIcon.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, 50);
		moneyText.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (80, 21);
		panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -140);
		pausePanel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -1000);
		
		panelText.text = " ";
		pauseText.text = " ";
		
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

	public void OnClickedLeave (Button leaveButton) {

		if (Time.timeScale != 0) {
			buttonSound.Play ();
			screenSrink = false;
			screenEnlarge = true;
			Initial ();
			if (player1.transform.position.x == gletser.transform.position.x + 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x + 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			if (player1.transform.position.x == gletser.transform.position.x - 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			gletser.transform.localScale = new Vector3 (1, 1, 1);
			chat = false;
			moneyChecked = false;
			p1Script.joystick.SetActive (true);
			anim.SetInteger ("FightMove", 0);

			bajay.SetActive (true);
			cosmo.SetActive (false);
			spark.SetActive (false);
		
			if (bajayStop) {

				player1.transform.position = new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z + 1f);
				bajayStop = false;
			}

            cloudButton.SetActive(true);
		}
		
	}
	
	public void OnClickedNext (Button nextButton) {

		if (Time.timeScale != 0) {
			buttonSound.Play ();

			if (fight) {

				anim.SetInteger ("FightMove", 2);
				gletserAnim.SetInteger ("Move", 1);
				debu2Intan.Play ();
				dustStart = true;
			}
			panelText.text = " ";
			nextButton.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (140, -800);
			panel.GetComponentInChildren<RectTransform> ().anchoredPosition = new Vector2 (0, -140);
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
	
	public void OnClickedSatay (Button satayButton) {

		if (Time.timeScale != 0) {
			chachingSound.Play ();
			gotSomethingSound.Play ();
			p1HBar.rectTransform.sizeDelta = new Vector2 (300, p1HBar.GetComponent<RectTransform> ().rect.height);

			if (!success) {
				moneyDynamicPoint = 20;
		
				fight = true;
				screenShut = true;
				screenSrink = false;


			} else {

				moneyDynamicPoint = 10;
				chat = false;
				screenSrink = false;
				screenEnlarge = true;

			}

			Initial ();
		
		
			if (player1.transform.position.x == gletser.transform.position.x + 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x + 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			if (player1.transform.position.x == gletser.transform.position.x - 3f) {
				player1.transform.position = new Vector3 (player1.transform.position.x - 0.01f, player1.transform.position.y, player1.transform.position.z);
			}
			gletser.transform.localScale = new Vector3 (1, 1, 1);

			p1Script.joystick.SetActive (true);

			savePositionP1 = new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z);
			savePositionP2 = new Vector3 (gletser.transform.position.x, gletser.transform.position.y, gletser.transform.position.z);

			moneyChecked = false;
			moneyPoint -= moneyDynamicPoint;
			moneyAppearMin = true;
			healthAppear = true;
		}

	}

    void ChatOn ()
    {
        p1Script.joystick.SetActive(false);
        chat = true;
        screenSrink = true;
        screenEnlarge = false;
        screenShut = false;

        panel.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(0, 0);
        if (!notFirstTime && !success)
        {
            panelText.text = "GLETSER:\n\n" +
                "So you want to become stronger ey?\nI can train you to master the COSMO POWER. " +
                "Don't worry, my training is free." +
                "\nYou just need to buy one cup of my ICE CREAM for $20 before we start the training." +
                "\nWhat say you?";
        }
        else if (notFirstTime && !success)
        {
            panelText.text = "GLETSER:\n\n" +
                "So you wanna have another training session ey?" +
                "\nNo problem. Just buy one cup of my ICE CREAM for $20 first before we start the training.";
        }
        else if (notFirstTime && success)
        {
            panelText.text = "GLETSER:\n\n" +
                "Because you have now mastered the COSMO POWER, I give you DISCOUNT 50% off from the price for a cup of ICE CREAM." +
                "\nSo,do you wanna buy ICE CREAM?";
        }

        if (player1.transform.position.x > gletser.transform.position.x)
        {
            player1.transform.position = new Vector3(gletser.transform.position.x + 3f, player1.transform.position.y, gletser.transform.position.z);
            if (player1.transform.localScale.x == 1)
            {
                player1.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (player1.transform.position.x < gletser.transform.position.x)
        {
            player1.transform.position = new Vector3(gletser.transform.position.x - 3f, player1.transform.position.y, gletser.transform.position.z);
            gletser.transform.localScale = new Vector3(-1, 1, 1);
            if (player1.transform.localScale.x == -1)
            {
                player1.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        satayButton.GetComponentInChildren<Text>().text = "OK";
        leaveButton.GetComponentInChildren<Text>().text = "No Thanks";
        leaveButton.GetComponentInChildren<Text>().fontSize = 14;
        if ((!success && moneyPoint >= 30) || (success && moneyPoint >= 20))
        {
            satayButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(-140, 6);
        }
        else if ((!success && moneyPoint < 30) || (success && moneyPoint < 20))
        {
            leaveButton.GetComponentInChildren<Text>().text = "I don't have enough money";
            leaveButton.GetComponentInChildren<Text>().fontSize = 10;
        }
        leaveButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2(140, 6);
    }

    public void OnChatWithGletser()
    {
        if (!fight)
        {
            ChatOn();

        }
    }

    public void OnClickedBack (Button backButton) {

		if (Time.timeScale != 0) {
			chachingSound.Play ();
			moneyDynamicPoint = 10;
			moneyPoint -= moneyDynamicPoint;
			moneyAppearMin = true;
			PlayerPrefs.SetInt ("fromTraining", 1);
			PlayerPrefs.SetInt ("registered", 0);
			PlayerPrefs.SetInt ("matchNumb", 0);

			LoadLevel ();
		}
		
	}
	
	public void LoadLevel (){
		
		StartCoroutine (LevelCoroutine ());
		
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

}
