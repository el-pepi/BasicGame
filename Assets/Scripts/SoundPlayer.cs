using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	AudioSource source;

	public AudioClip[] clips;

	Dictionary<string,AudioClip> sounds;

	public static SoundPlayer instance;
	// Use this for initialization
	void Start () {
		instance = this;

		source = GetComponent<AudioSource> ();
		sounds = new Dictionary<string, AudioClip> ();
		foreach (AudioClip c in clips) {
			sounds.Add (c.name,c);
		}
	}

	public void PlayByName(string name){
		source.PlayOneShot (sounds[name]);
	}
}
