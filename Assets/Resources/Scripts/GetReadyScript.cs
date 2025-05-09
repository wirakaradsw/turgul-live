using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetReadyScript : MonoBehaviour
{
    public GameObject[] p2;
    public GameObject[] p2BoxV;
    public GameObject[] p2BoxX;
    public GameObject[] p2X;

    public Text chapText;

    public AudioSource bGMusic;

    private int matchNumb = 0;
    private int chapter = 0;

    private bool isLoading = false;
    public GameObject loadingScene;
    public Image loadingBar;
    public Text loadingText;

    void Start()
    {
        matchNumb = PlayerPrefs.GetInt("matchNumb");
        chapter = PlayerPrefs.GetInt("chapter");

        // --- Initial Reset
        loadingScene.SetActive(false);

        for (int i = 0; i < p2.Length; i++) {
            p2[i].SetActive(false);
        }

        for (int i = 0; i < p2BoxV.Length; i++) {
            p2BoxV[i].SetActive(false);
        }

        for (int i = 0; i < p2BoxX.Length; i++)
        {
            p2BoxX[i].SetActive(true);
        }

        for (int i = 0; i < p2X.Length; i++)
        {
            p2X[i].SetActive(false);
        }

        if (chapter == 1) {
            chapText.text = "Chapter 1:\n" +
                        "Rookie Tournament\nLet's have a Turgul!";

        } else if (chapter == 2) {
            chapText.text = "Chapter 2:\n" +
                            "Amateur Tournament\nThe devil within";
            p2BoxX[0].SetActive(false);

        } else if (chapter == 3) {
            chapText.text = "Chapter 3:\n" +
                            "Pro Tournament\nSuper Heroes";
            p2BoxX[0].SetActive(false);
            p2BoxX[1].SetActive(false);

        } else if (chapter == 4) {
            chapText.text = "Last Chapter:\n" +
                            "Grand Tournament\nThe power within";
            p2BoxX[0].SetActive(false);
            p2BoxX[1].SetActive(false);
            p2BoxX[2].SetActive(false);

        } else {
            chapText.text = "\nGrand Tournament\n";
            p2BoxX[0].SetActive(false);
            p2BoxX[1].SetActive(false);
            p2BoxX[2].SetActive(false);
        }

        if (matchNumb == 1) {
            p2[0].SetActive(true);
            p2BoxV[0].SetActive(true);

        } else if (matchNumb == 2) {
            p2[1].SetActive(true);
            p2BoxV[1].SetActive(true);
            p2X[0].SetActive(true);

        } else if (matchNumb == 3) {
            p2[2].SetActive(true);
            p2BoxV[2].SetActive(true);
            p2X[0].SetActive(true);
            p2X[1].SetActive(true);

        } else if (matchNumb == 4) {
            p2[3].SetActive(true);
            p2BoxV[3].SetActive(true);
            p2X[0].SetActive(true);
            p2X[1].SetActive(true);
            p2X[2].SetActive(true);

        } else if (matchNumb == 5) {
            p2[4].SetActive(true);
            p2BoxV[4].SetActive(true);
            p2X[0].SetActive(true);
            p2X[1].SetActive(true);
            p2X[2].SetActive(true);
            p2X[3].SetActive(true);

        }
    }

    void Update()
    {
        if (!bGMusic.isPlaying && !isLoading) {
            isLoading = true;
            LoadLevel();
        }
    }

    private void LoadLevel()
    {

        StartCoroutine(LevelCoroutine());

    }

    private IEnumerator LevelCoroutine()
    {
        loadingScene.SetActive(true);
        AsyncOperation async = Application.LoadLevelAsync(3);

        while (!async.isDone)
        {
            float loadProgress = async.progress * 100;
            loadingBar.fillAmount = async.progress / 0.9f;
            loadingText.text = "Loading...\n" + loadProgress.ToString("n0") + "%";
            yield return null;
        }
    }
}
