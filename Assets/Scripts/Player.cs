﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (GameManager.instance.isPlaying) {
					ThingSpawner.instance.OnFire ();
			} else {
				if (GameManager.instance.dead == false) {
					GameManager.instance.StartGame ();
				}
			}
		}
	}
}
