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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayMMD() {
		PlayerAnimator.speed = 1f;
		AudioPlayer.Play ();
	}

	public void PlayJilejingtu() {
		SetJiLeJingTu ();
		PlayMMD ();
	}

	public void PlayQianbenying() {
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

	public void Stop() {
		PlayerAnimator.speed = 0;
		AudioPlayer.Stop ();
	}
}
