using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public bool isPlaying = false;

	public GameObject gameoverScr;
	public GameObject gameplayScr;
	public GameObject startScr;

	public GameObject gameStuff;

	public bool dead=false;

	int score;
	public Text scoreText;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		instance = this;

        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success)=> { Debug.Log( "aututu: " +  success); });
	}

	public void StartGame(){
		if (AdsManager.instance.IsAdShowing ()) {
			return;
		}
		isPlaying = true;
		gameplayScr.SetActive (true);
		startScr.SetActive (false);

		gameStuff.SetActive (true);
	}

	public void Gameover(){
		isPlaying = false;
		dead = true;
		gameoverScr.SetActive (true);
		SoundPlayer.instance.PlayByName ("Gameover");

		Dictionary<string,object> data = new Dictionary<string, object> ();
		data.Add ("score" , score);
		Analytics.CustomEvent ("gameover",data);

        if (score >= 100)
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportProgress("CgkIrKmkyIceEAIQAg", 100, null);
            }
        }

        if (Social.localUser.authenticated)
        {
            Social.ReportScore(score, "CgkIrKmkyIceEAIQAQ", null);
        }
    }
    

	public void Reset(){
		AdsManager.instance.ShowPlacement ();
		ThingSpawner.instance.OnReset ();
		gameoverScr.SetActive (false);
		gameplayScr.SetActive (false);
		startScr.SetActive (true);
		dead = false;
		gameStuff.SetActive (false);
		score = 0;
		UpdateScoreText ();
	}

	public void AddScore(){
		score++;
		UpdateScoreText ();
	}

	void UpdateScoreText(){
		scoreText.text = score.ToString ();
	}

    public void ShowBoard()
    {
        //PlayGamesPlatform.Instance.ShowLeaderboardUI();
        Social.ShowLeaderboardUI();
    }
    public void ShowAchievements()
    {
        //PlayGamesPlatform.Instance.ShowAchievementsUI();
        Social.ShowAchievementsUI();
    }
}
