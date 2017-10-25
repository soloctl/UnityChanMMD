using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour {

	void Start () {
		Advertisement.Initialize (Values.GameId);
	}

	public void UnityAdsShow(string placement) {
		if (Advertisement.IsReady (placement)) {
			UIManager.Instance ().AdsStarted ();
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
		case ShowResult.Skipped:
			// MMDSourceManager.Instance ().AdsCompletelyWatched ();
			break;
		}
	}

	public static UnityAdsManager Instance() {
		GameObject go = GameObject.FindGameObjectWithTag(Values.TagUADManager);
		UnityAdsManager uam = go.GetComponent<UnityAdsManager> ();
		return uam;
	}
}
