using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		Advertisement.Initialize (Values.GameId);
	}

	public bool UnityAdsIsDefaultPlacementReady() {
//		Debug.Log ("Ad ready");
		if (Advertisement.isInitialized && Advertisement.IsReady ()) {
			return true;
		} else {
			Debug.Log (Advertisement.GetPlacementState());
			return false;
		}
	}

	public bool UnityAdsIsReady(string placement) {
		if (Advertisement.isInitialized && Advertisement.IsReady (placement)) {
			return true;
		} else {
			Debug.Log (Advertisement.GetPlacementState());
			return false;
		}
	}

	public void UnityAdsShowDefaultPlacement() {
		if (UnityAdsIsDefaultPlacementReady ()) {
			Debug.Log ("Ad start");
			UIManager.Instance ().OnAdsShown ();
			ShowOptions options = new ShowOptions();
			options.resultCallback = UnityAdsResultCallback;
			Advertisement.Show (options);
		}
	}

	public void UnityAdsShow(string placement) {
		if (UnityAdsIsReady (placement)) {
			Debug.Log ("Ad start, " + placement);
			UIManager.Instance ().OnAdsShown ();
			ShowOptions options = new ShowOptions();
			options.resultCallback = UnityAdsResultCallback;
			Advertisement.Show (placement, options);
		}
	}

	private void UnityAdsResultCallback(ShowResult result) {
		switch (result) {
		case ShowResult.Finished:
			MMDSourceManager.Instance ().AdsCompletelyWatched ();
			break;
		}
	}

	public static UnityAdsManager Instance() {
		GameObject go = GameObject.FindGameObjectWithTag(Values.TagUnityAdsManager);
		UnityAdsManager uam = go.GetComponent<UnityAdsManager> ();
		return uam;
	}
}
