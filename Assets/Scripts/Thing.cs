using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour {

	int hp;

	Vector3 pos;

	TextMesh text;

	void Start(){
		pos = transform.position;
		text = GetComponent<TextMesh> ();

		hp = Random.Range (2,5);

		UpdateText ();
	}

	void Update(){
		if (GameManager.instance.isPlaying == false) {
			return;
		}
		pos.y -=Time.deltaTime*ThingSpawner.instance.speed;
		transform.position = pos;

		if (pos.y <= -3.5f) {
			GameManager.instance.Gameover ();
		}
	}

	public void Hurt(){
		hp--;
		if (hp <= 0) {
			Die ();
		}
		UpdateText ();
	}

	void UpdateText(){
		text.text = hp.ToString ();
	}

	void Die(){
		ThingSpawner.instance.speed += 0.2f;
		SoundPlayer.instance.PlayByName ("Explosion");
		ThingSpawner.instance.RemoveFromList (this);
		Destroy (gameObject);
	}
}
