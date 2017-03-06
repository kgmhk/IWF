using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;
using GooglePlayGames.BasicApi;
using GooglePlayGames;

public class GameManager : MonoBehaviour {

	public float waitingTime = 1.5f;
	public static GameManager manager;
	public bool ready = false;
    public bool start = false;
	public bool end = false;
    public bool bonusGame = false;
    public bool continueGame = false;

	public GameObject cactus;
    public GameObject missile;
	public GameObject readyImage01;
	public GameObject readyImage02;
	public GameObject gameOverImage;
	public GameObject finalWindow;
	public GameObject imageNew;
    public GameObject unityAds;
    public GameObject continueBtn;
    public GameObject playBtn;
    public GameObject leaderboardBtn;
    public GameObject titleText;

	public AudioClip deathSound;
	public AudioClip goalSound;
	
	public int score;
	public TextMesh scoreText;
	public TextMesh finalScoreText;
    public TextMesh bestScoreText;

    void Start () {
		score = 0;
		manager = this;
        bonusGame = false;
        playBtn.SetActive(true);
        titleText.SetActive(true);
        
        PlayGamesPlatform.Activate();

        if (Social.localUser.authenticated)
            Invoke("ShowLeaderBoardBtn", 0.5f);
    }

    void ShowLeaderBoardBtn()
    {
        leaderboardBtn.SetActive(true);
    }

	void Update(){
        if (!Social.localUser.authenticated)
            Social.localUser.Authenticate(LoginCallBackGPGS);

        if (ready == true) {
            print("desktop branch test");
            playBtn.SetActive(false);
            titleText.SetActive(false);
            leaderboardBtn.SetActive(false);
            start = true;
			ready = false;
            InvokeRepeating ("MakeCactus", 1f, waitingTime);
            InvokeRepeating("MakeMissiles", 1f, waitingTime);
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Bird.bird.gameObject.GetComponent<Rigidbody>().AddForce(0, 5f, 0, ForceMode.VelocityChange);
            iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 0, "delay", 0, "time", 0.5f));
            iTween.MoveTo(finalWindow, iTween.Hash("y", -5, "delay", 0, "time", 0.5f));
        }

        if (continueGame == true)
        {
            start = true;
            bonusGame = true;
            continueGame = false;
            InvokeRepeating("MakeCactus", 1f, waitingTime);
            InvokeRepeating("MakeMissiles", 1f, waitingTime);
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Bird.bird.gameObject.GetComponent<Rigidbody>().AddForce(0, 5f, 0, ForceMode.VelocityChange);
            iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 0, "delay", 0, "time", 0.5f));
            iTween.MoveTo(finalWindow, iTween.Hash("y", -5, "delay", 0, "time", 0.5f));

            continueBtn.SetActive(false);
        }
    }

    public void LoginCallBackGPGS(bool result)
    {
        if(result && !start)
        {
            leaderboardBtn.SetActive(true);
        }
    }

    void MakeCactus(){
		Instantiate (cactus);
	}

    void MakeMissiles()
    {
        Instantiate (missile);
    }

	public void GameOver(){

        // unity Ads check
        if (Advertisement.IsReady("rewardedVideo") && !bonusGame)
        {
            continueBtn.SetActive(true);
        }
        start = false;
        end = true;
		CancelInvoke ("MakeCactus");
        CancelInvoke("MakeMissiles");
        iTween.ShakePosition (Camera.main.gameObject, iTween.Hash("x", 0.2,"y",0.2,"time",0.5f));
		iTween.FadeTo(gameOverImage, iTween.Hash("alpha",255,"delay",1,"time",0.5f));
		iTween.MoveTo (finalWindow, iTween.Hash ("y", 1, "delay", 1.3f, "time", 0.5f));

		if(score > PlayerPrefs.GetInt ("BestScore")){
			PlayerPrefs.SetInt("BestScore",score);
			imageNew.SetActive(true);

            // 리더보드 갱신
            Social.ReportScore(score, GPGSIds.leaderboard_iwf, (bool success) => {
                // handle success or failure
            });
        }
        else if (score <= PlayerPrefs.GetInt("BestScore")){
			imageNew.SetActive(false);
		}

		finalScoreText.text = score.ToString ();
		bestScoreText.text = PlayerPrefs.GetInt ("BestScore").ToString ();

		GetComponent<AudioSource>().clip = deathSound;
		GetComponent<AudioSource>().Play ();
	}
	public void GetScore() {
		score += 1;
		scoreText.text = score.ToString ();
		GetComponent<AudioSource>().clip = goalSound;
		GetComponent<AudioSource>().Play ();
	}
}
