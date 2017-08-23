using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMDSourceManager : MonoBehaviour {

	public RuntimeAnimatorController JiLeJingTu;
	public RuntimeAnimatorController QianBenYing;
	public Animator PlayerAnimator;

	public AudioClip JiLeJingTuClip;
	public AudioClip QianBenYingClip;
	public AudioSource AudioPlayer;

	enum Dances { QianBenYing, JiLeJingTu };
	private Dances Waiting = Dances.QianBenYing;

	// Use this for initialization
	void Start () {
		Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void WatchQianbenyingAd() {
		Debug.Log ("Watch QianbenyingAd");
		Stop ();
		Waiting = Dances.QianBenYing;
		UnityAdsManager.Instance ().UnityAdsShow (Values.PlacementId);
	}

	public void WatchJilejingtuAd() {
		Debug.Log ("Watch QianbenyingAd");
		Stop ();
		Waiting = Dances.JiLeJingTu;
		UnityAdsManager.Instance ().UnityAdsShow (Values.PlacementId);
	}

	public void AdsCompletelyWatched() {
		switch (Waiting) {
		case Dances.JiLeJingTu:
			PlayJilejingtu ();
			break;
		case Dances.QianBenYing:
			PlayQianbenying ();
			break;
		}
	}

	private void PlayMMD() {
		PlayerAnimator.speed = 1f;
		AudioPlayer.Play ();
	}

	private void PlayJilejingtu() {
		SetJiLeJingTu ();
		PlayMMD ();
	}

	private void PlayQianbenying() {
		SetQianBenYing ();
		PlayMMD ();
	}

	private void SetJiLeJingTu() {
		PlayerAnimator.runtimeAnimatorController = JiLeJingTu;
		AudioPlayer.clip = JiLeJingTuClip;
	}

	private void SetQianBenYing() {
		PlayerAnimator.runtimeAnimatorController = QianBenYing;
		AudioPlayer.clip = QianBenYingClip;
	}

	private void Stop() {
		PlayerAnimator.speed = 0;
		AudioPlayer.Stop ();
	}

	public static MMDSourceManager Instance() {
		GameObject go = GameObject.FindGameObjectWithTag(Values.TagMMDSourceManager);
		MMDSourceManager msm = go.GetComponent<MMDSourceManager> ();
		return msm;
	}
}
