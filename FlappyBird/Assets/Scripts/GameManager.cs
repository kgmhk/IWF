using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour {

	public float waitingTime = 1.5f;
	public static GameManager manager;
	public bool ready = true;
	public bool end = false;
    public bool continueGame = false;

	public GameObject cactus;
	public GameObject readyImage01;
	public GameObject readyImage02;
	public GameObject gameOverImage;
	public GameObject finalWindow;
	public GameObject imageNew;
    public GameObject unityAds;

	public AudioClip deathSound;
	public AudioClip goalSound;
	
	public int score;
	public TextMesh scoreText;
	public TextMesh finalScoreText;
	public TextMesh bestScoreText;

	void Start () {
		score = 0;
		manager = this;
	}

	void Update(){
        
       
        if (Input.GetMouseButtonDown (0) && ready == true) {
            print("branch test");
			ready = false;
            InvokeRepeating ("MakeCactus", 1f, waitingTime);
			Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;
			iTween.FadeTo(readyImage01, iTween.Hash("alpha", 0,"time", 1.50f));
			iTween.FadeTo(readyImage02, iTween.Hash("alpha", 0, "time", 1.0f));

            //iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 255, "delay", 1, "time", 0.5f));
            iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 0, "delay", 0, "time", 0.5f));
            iTween.MoveTo(finalWindow, iTween.Hash("y", -5, "delay", 0, "time", 0.5f));
        }

        if (Input.GetMouseButtonDown(0) && continueGame == true)
        {
            continueGame = false;
            InvokeRepeating("MakeCactus", 1f, waitingTime);
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //iTween.FadeTo(readyImage01, iTween.Hash("alpha", 0, "time", 1.50f));
            //iTween.FadeTo(readyImage02, iTween.Hash("alpha", 0, "time", 1.0f));

            //iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 255, "delay", 1, "time", 0.5f));
            iTween.FadeTo(gameOverImage, iTween.Hash("alpha", 0, "delay", 0, "time", 0.5f));
            iTween.MoveTo(finalWindow, iTween.Hash("y", -5, "delay", 0, "time", 0.5f));
        }
    }	

	void MakeCactus(){
		Instantiate (cactus);
	}

	public void GameOver(){
		end = true;
		CancelInvoke ("MakeCactus");
        iTween.ShakePosition (Camera.main.gameObject, iTween.Hash("x", 0.2,"y",0.2,"time",0.5f));
		iTween.FadeTo(gameOverImage, iTween.Hash("alpha",255,"delay",1,"time",0.5f));
		iTween.MoveTo (finalWindow, iTween.Hash ("y", 1, "delay", 1.3f, "time", 0.5f));

		if(score > PlayerPrefs.GetInt ("BestScore")){
			PlayerPrefs.SetInt("BestScore",score);
			imageNew.SetActive(true);
		}else if (score <= PlayerPrefs.GetInt("BestScore")){
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
