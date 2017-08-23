using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Button QianBenYingButton;
	public Button JiLeJingTuButton;

	bool buttonEnabled = false;

	const float interval = 0.5f;
	float counting = 0f;

	void Start() {
		DisableButtons ();
	}

	void Update() {
		if (!buttonEnabled) {
			counting += Time.deltaTime;
			if (counting >= interval) {
				counting = counting - interval;
				if (UnityAdsManager.Instance ().UnityAdsIsReady (Values.PlacementId)) {
					OnAdsReady ();
					counting = 0f;
				}
			}
		}
	}

	public void OnAdsReady() {
		Debug.Log ("OnAdsReady");
		QianBenYingButton.gameObject.SetActive (true);
		JiLeJingTuButton.gameObject.SetActive (true);
		buttonEnabled = true;
	}

	public void OnAdsShown() {
		Debug.Log ("OnAdsShown");
		DisableButtons ();
	}

	private void DisableButtons() {
		QianBenYingButton.gameObject.SetActive (false);
		JiLeJingTuButton.gameObject.SetActive (false);
		buttonEnabled = false;
	}

	public static UIManager Instance() {
		GameObject go = GameObject.FindGameObjectWithTag(Values.TagUIManager);
		UIManager um = go.GetComponent<UIManager> ();
		return um;
	}
}
