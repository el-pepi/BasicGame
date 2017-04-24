using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingSpawner : MonoBehaviour {

	float spawnTimer = 0;

	public GameObject thingPref;
	public ParticleSystem shotParticle;
	public ParticleSystem badParticle;

	List<Thing> things;

	public static ThingSpawner instance;

	public float speed = 3;

	public LineRenderer line;
	float lineTime;

	// Use this for initialization
	void Start () {
		instance = this;
		things = new List<Thing> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.isPlaying == false) {
			return;
		}
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0) {
			spawnTimer = Random.Range (0.5f,2f);
			Spawn ();
		}
		if (lineTime > 0) {
			lineTime -= Time.deltaTime;
			if (lineTime <= 0) {
				line.enabled = false;
			}
		}
	}

	void Spawn(){
		things.Add(Instantiate (thingPref).GetComponent<Thing>());
	}

	public void OnFire(){
		line.enabled = true;
		lineTime = 0.05f;
		if (things.Count == 0) {
			GameManager.instance.Gameover ();
			line.SetPosition (1, Vector3.up*4f);
			badParticle.Play ();
			return;
		}
		line.SetPosition (1, things [0].transform.position);
		shotParticle.transform.position = things [0].transform.position;
		shotParticle.Emit (5);
		things [0].Hurt ();
		GameManager.instance.AddScore ();
		SoundPlayer.instance.PlayByName ("Fire");

	}

	public void RemoveFromList(Thing t){
		things.Remove (t);
	}

	public void OnReset(){
		foreach (Thing t in things) {
			Destroy (t.gameObject);
		}

		things.Clear ();

		speed = 3;
		lineTime = 0;
		line.enabled = false;
		spawnTimer = 0;
	}
}
