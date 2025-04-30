using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BambangEnding : MonoBehaviour {

	float timerR = 0;
	float timerL = 0;
	public float timerMax;

	public GameObject bonang;
	public GameObject nk;
	public GameObject nk2;
	public GameObject ron;
	public GameObject ron2;
	public GameObject kbh;
	public GameObject kbh2;
	public GameObject wukong;

	public Button playButton;
	public Button exitButton;

	public AudioSource buttonSound;

	public GameObject loadingScene;
	public Image loadingBar;
	public Text loadingText;

	public bool quickMode = false;

	bool bowR = true;

	public Animator anim;

	void Start () {
	
		quickMode = PlayerPrefs.GetInt ("quickMode") > 0;

		timerR = timerMax;
		timerL = timerMax;

		loadingScene.SetActive (false);

		if (PlayerPrefs.GetInt ("tournamentNumb") == 1) {
			Init ();
			bonang.SetActive (true);
			nk.SetActive (true);
		} else if (PlayerPrefs.GetInt ("tournamentNumb") == 2) {
			Init ();
			ron.SetActive (true);
			nk2.SetActive (true);
		} else if (PlayerPrefs.GetInt ("tournamentNumb") == 3) {
			Init ();
			ron2.SetActive (true);
			kbh.SetActive (true);
		} else if (PlayerPrefs.GetInt ("tournamentNumb") == 4) {
			Init ();
			wukong.SetActive (true);
			kbh2.SetActive (true);
		}

	}

	void Update () {

		PlayerPrefs.SetInt ("quickMode", quickMode ? 1 : 0);

		if (timerR <= 0 && bowR) {
			bowR = false;
			timerR = timerMax;
		}

		if (timerL <= 0 && !bowR) {
			bowR = true;
			timerL = timerMax;
		}

		if (timerR == timerMax || timerL == timerMax) {
			anim.SetInteger ("FightMove", 1);
		}

		if (timerR <= 10 || timerL <= 10) {
			anim.SetInteger ("FightMove", 0);
		}
	
		if (bowR) {
			transform.localScale = new Vector3 (1, 1, 1);
            timerR -= Time.deltaTime * 50f;
		} else {
			transform.localScale = new Vector3 (-1, 1, 1);
			timerL -= Time.deltaTime * 50f;
        }

	}

	void Init () {

		bonang.SetActive (false);
		nk.SetActive (false);
		nk2.SetActive (false);
		ron.SetActive (false);
		ron2.SetActive (false);
		kbh.SetActive (false);
		kbh2.SetActive (false);
		wukong.SetActive (false);

	}

	public void LoadLevelExit (){
		
		StartCoroutine (LevelCoroutineExit ());
		
	}
	
	public void LoadLevelPlay (){
		
		StartCoroutine (LevelCoroutinePlay ());
		
	}

	public void LoadLevelEnd (){
		
		StartCoroutine (LevelCoroutineEnd ());
		
	}
	
	IEnumerator LevelCoroutineExit (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (0);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}
	
	IEnumerator LevelCoroutinePlay (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (2);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}

	IEnumerator LevelCoroutineEnd (){
		
		loadingScene.SetActive (true);
		AsyncOperation async = Application.LoadLevelAsync (7);
		
		while (!async.isDone) {
			float loadProgress = async.progress * 100;
			loadingBar.fillAmount = async.progress / 0.9f;
			loadingText.text = "Loading...\n" + loadProgress.ToString ("n0") + "%";
			yield return null;
		}
		
	}
	
	public void OnClickedExit (Button exitButton) {

		//buttonSound.Play ();
		LoadLevelExit ();
	}
	
	public void OnClickedPlay (Button playButton) {

		buttonSound.Play ();

		if (PlayerPrefs.GetInt ("chapter") == 4) {
//			PlayerPrefs.SetInt ("quickMode", 1);
			LoadLevelEnd ();
		} else {
			LoadLevelPlay ();
		}

		if (PlayerPrefs.GetInt ("chapter") == 5) {
			PlayerPrefs.SetInt ("chapter", 5);
		}else if (PlayerPrefs.GetInt ("chapter") == 4) {
			PlayerPrefs.SetInt ("chapter", 5);
		}else if (PlayerPrefs.GetInt ("chapter") == 3) {
			PlayerPrefs.SetInt ("chapter", 4);
		}else if (PlayerPrefs.GetInt ("chapter") == 2) {
			PlayerPrefs.SetInt ("chapter", 3);
		}else if (PlayerPrefs.GetInt ("chapter") == 1) {
			PlayerPrefs.SetInt ("chapter", 2);
		}

		PlayerPrefs.SetInt ("fromTour", 1);
		PlayerPrefs.SetInt ("prologue", 1);
//		LoadLevelPlay ();
		
	}
}
