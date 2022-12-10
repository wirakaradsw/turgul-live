using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject turgulTitle0;
	public GameObject turgulTitle1;
	public GameObject turgulTitle2;

	public GameObject pukulanIcon;
	public GameObject blackLine;

	public GameObject bGBlue;
	public GameObject bGBlack;

	public GameObject loadingScene;
	public Image loadingBar;
	public Text loadingText;
	
	public Button startButton;
	public Button continueButton;
	public Button quickButton;
	public Button tutorialButton;
	public Button quitButton;

	public AudioSource buttonSound;
	public AudioSource gongSound;

	//public AudioSource pukulanVoice;
	
	void Awake (){
		
		/*if (Screen.currentResolution.width / Screen.currentResolution.height == 16/9) {
			Screen.SetResolution (1920, 1080, true);
		} else {
			//Screen.SetResolution (1024, 576, false);
			Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);
		}*/
		
	}
	
	// Use this for initialization
	void Start () {

		turgulTitle1.SetActive (false);
		loadingScene.SetActive (false);
		startButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -300);
		continueButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -300);
		quickButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -300);
		tutorialButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -300);
		quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -300);
		
	}
	
	// Update is called once per frame
	void Update () {

		pukulanIcon.transform.position = new Vector3(pukulanIcon.transform.position.x + ((12f - pukulanIcon.transform.position.x) * 0.03f) , pukulanIcon.transform.position.y, pukulanIcon.transform.position.z);

		if (pukulanIcon.transform.position.x > 9.3f && pukulanIcon.transform.position.x < 10f) {

			turgulTitle1.SetActive (true);
			turgulTitle0.SetActive (false);
			blackLine.SetActive (false);

		}

		if (pukulanIcon.transform.position.x > 11f) {

			/*if (gongSound.isPlaying ==false){
				gongSound.Play ();
			}*/

			StartCoroutine ("TurgulTitleFadeOut");
			//turgulTitle2.transform.position = new Vector3(turgulTitle2.transform.position.x, turgulTitle2.transform.position.y + ((1f - turgulTitle2.transform.position.y) * 0.04f), turgulTitle2.transform.position.z);

		}

		if (turgulTitle2.transform.position.y > 0.98f) {

			//gongSound.Stop ();

			turgulTitle2.transform.position = new Vector3 (0, 1, 0);

			startButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -20);
			if (PlayerPrefs.GetInt ("chapter") > 0){
				continueButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -60);
			}
			if (PlayerPrefs.GetInt ("quickMode") == 1){
				quickButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -100);
			}
			tutorialButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -140);
			quitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (0, -180);

		}
		
	}
	
	public void LoadLevel (){
		
		StartCoroutine (LevelCoroutine ());
		
	}

	public void LoadLevelTutorial (){
		
		StartCoroutine (LevelCoroutineTutorial ());
		
	}

	IEnumerator TurgulTitleFadeOut(){
		for (float i = 1f; i >= 0f; i-= 0.1f) {
			if (i < 0.1){
				i = 0;
				turgulTitle2.transform.position = new Vector3(turgulTitle2.transform.position.x, turgulTitle2.transform.position.y + ((1f - turgulTitle2.transform.position.y) * 0.04f), turgulTitle2.transform.position.z);
				turgulTitle1.SetActive (false);
				bGBlack.SetActive (false);
			}
			turgulTitle1.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, i);
			bGBlack.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, i);
			yield return new WaitForSeconds(0.1f);
		}
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

	IEnumerator LevelCoroutineTutorial (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (5);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}
	
	public void OnClickedStart (Button startButton) {

		buttonSound.Play ();
		//Application.LoadLevel (1);
//		PlayerPrefs.SetInt ("quickMode", 0);
		PlayerPrefs.SetInt ("chapter", 1);
		PlayerPrefs.SetInt ("moneyPoint", 0);
		PlayerPrefs.SetInt ("moneyTournament", 0);
		PlayerPrefs.SetFloat ("p1HBarX", 300);
		PlayerPrefs.SetInt ("registered", 0);
		PlayerPrefs.SetInt ("patrickAppear", 0);
		PlayerPrefs.SetInt ("tournamentNumb", 0);
		PlayerPrefs.SetInt ("matchNumb", 0);
		PlayerPrefs.SetInt ("fromTour", 0);
		PlayerPrefs.SetInt ("p1Lost", 0);
		PlayerPrefs.SetInt ("prologue", 0);
		PlayerPrefs.SetInt ("rageMode", 0);
		PlayerPrefs.SetInt ("bajayOn", 0);
		PlayerPrefs.SetInt ("notFirstTime", 0);
		PlayerPrefs.SetInt ("success", 0);
		LoadLevel ();
	}

	public void OnClickedCont (Button continueButton) {
		
		buttonSound.Play ();

		LoadLevel ();
	}

	public void OnClickedQuick (Button quickButton) {
		
		buttonSound.Play ();
		//Application.LoadLevel (1);
		PlayerPrefs.SetInt ("chapter", 5);
		PlayerPrefs.SetInt ("moneyPoint", 0);
		PlayerPrefs.SetInt ("moneyTournament", 0);
		PlayerPrefs.SetFloat ("p1HBarX", 300);
		PlayerPrefs.SetInt ("registered", 0);
		PlayerPrefs.SetInt ("patrickAppear", 1);
		PlayerPrefs.SetInt ("tournamentNumb", 4);
		PlayerPrefs.SetInt ("matchNumb", 0);
		PlayerPrefs.SetInt ("fromTour", 0);
		PlayerPrefs.SetInt ("p1Lost", 0);
		PlayerPrefs.SetInt ("prologue", 0);
		PlayerPrefs.SetInt ("rageMode", 0);
		PlayerPrefs.SetInt ("bajayOn", 1);
		PlayerPrefs.SetInt ("notFirstTime", 1);
		PlayerPrefs.SetInt ("success", 1);
		LoadLevel ();
	}

	public void OnClickedTutorial (Button tutorialButton) {

		//buttonSound.Play ();
		LoadLevelTutorial ();

	}
	
	public void OnClickedQuit (Button quitButton) {

		buttonSound.Play ();
		Application.Quit ();
	}
}
