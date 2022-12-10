using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingScript : MonoBehaviour {
	
	
	public GameObject congratText;

	
	public Button playButton;
	public Button exitButton;
	
	public AudioSource buttonSound;
	
	public GameObject loadingScene;
	public Image loadingBar;
	public Text loadingText;
	
	void Start () {
		
		loadingScene.SetActive (false);

		transform.position = new Vector3 (0, 0, -8);

		congratText.SetActive (false);

		playButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (28.9f, -50);
		exitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (281.5f, -50);

		PlayerPrefs.SetInt ("quickMode", 1);

	}
	
	void Update () {
		
		transform.position = new Vector3 (transform.position.x + ((-4f -transform.position.x) * 0.1f),
		                                  transform.position.y + ((0.8f -transform.position.y) * 0.1f),
		                                  transform.position.z + ((0 - transform.position.z) * 0.1f));

		if (transform.position.z > - 0.1f && transform.position.z < 0) {

			transform.position = new Vector3 (-4, 0.8f, 0);
			congratText.SetActive (true);
			playButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (28.9f, 6);
			exitButton.GetComponentInChildren<RectTransform>().anchoredPosition = new Vector2 (281.5f, 6);
		}
		
	}
	
	public void LoadLevelExit (){
		
		StartCoroutine (LevelCoroutineExit ());
		
	}
	
	public void LoadLevelPlay (){
		
		StartCoroutine (LevelCoroutinePlay ());
		
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
	
	public void OnClickedExit (Button exitButton) {
		
		//buttonSound.Play ();
		LoadLevelExit ();
	}
	
	public void OnClickedPlay (Button playButton) {
		
		buttonSound.Play ();
		
		PlayerPrefs.SetInt ("fromTour", 1);
		PlayerPrefs.SetInt ("prologue", 0);
		LoadLevelPlay ();
		
	}
}
