using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

	public static AdsManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void ShowPlacement(){
		if (Advertisement.isInitialized && Advertisement.IsReady()) {
			Advertisement.Show ();
		}
	}

	public bool IsAdShowing(){
		return Advertisement.isShowing;
	}
}
