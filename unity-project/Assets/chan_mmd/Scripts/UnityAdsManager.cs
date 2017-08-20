using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool UnityAdsIsDefaultPlacementReady() {
		return Advertisement.isInitialized && Advertisement.IsReady ();
	}

	public bool UnityAdsIsReady(string placement) {
		return Advertisement.isInitialized && Advertisement.IsReady (placement);
	}

	public void UnityAdsShowDefaultPlacement() {
		if (UnityAdsIsDefaultPlacementReady ()) {
			Advertisement.Show ();
		}
	}

	public void UnityAdsShow(string placement) {
		if (UnityAdsIsReady (placement)) {
			Advertisement.Show (placement);
		}
	}

}
