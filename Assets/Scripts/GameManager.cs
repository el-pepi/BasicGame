using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		instance = this;
	}

	public void StartGame(){
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
	}

	public void Reset(){
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
}
