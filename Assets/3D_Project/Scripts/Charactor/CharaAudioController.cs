using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAudioController : MonoBehaviour {

	Animator animator;
	AudioSource[] AudioSources;
	AudioSource runAudio;
	CharaStatus status;
	int audioIdx = 0;
	bool attackAudioOnce = false;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		status = GetComponent<CharaStatus> ();
		AudioSources = GetComponents<AudioSource> ();
		runAudio = AudioSources [3];
	}
	
	// Update is called once per frame
	void Update () {

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {
			attackAudioOnce = false;

		}

		AudioController ();
		
	}

	void AudioController () {

		// 攻撃音声を一回一回変える
		if (audioIdx > 2) {
			audioIdx = 0;
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Idle")) {

			runAudio.Stop ();
		}

		// 攻撃モーション中
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack")) {

			// 一回流したら次のソースへ
			if (attackAudioOnce == false) {
				AudioSources [audioIdx].Play ();
				audioIdx++;
				attackAudioOnce = true;
			}
		}

		// 移動モーション中
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.run")) {

			if (status.dead) {
				runAudio.Stop ();
			}

			if (runAudio.isPlaying == false) {
				runAudio.Play ();
			}
		}
	}
}
