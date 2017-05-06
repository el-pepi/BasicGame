using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    /*
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
    */
    public void OnClick()
    {
        if (GameManager.instance.isPlaying)
        {
            ThingSpawner.instance.OnFire();
        }
        else {
            if (GameManager.instance.dead == false)
            {
                GameManager.instance.StartGame();
            }
        }
    }
}
