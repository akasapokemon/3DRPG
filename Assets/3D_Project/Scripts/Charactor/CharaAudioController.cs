using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAudioController : MonoBehaviour {

	Animator animator;
	AudioSource[] AudioSources;
	AudioSource runAudio;
	AudioSource deadAudio;
	CharaStatus status;
	GameObject BGM;
	GameObject GameOverBGM;
	GameObject EventsCtr;
	bool gameOverAudioOnce = false;
	int attackAudioIdx = 0;
	int getHitAudioIdx = 4;
	bool attackAudioOnce = false;
	bool deadAudioOnce = false;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		status = GetComponent<CharaStatus> ();
		AudioSources = GetComponents<AudioSource> ();
		BGM = GameObject.FindGameObjectWithTag ("BGM");
		GameOverBGM = GameObject.FindGameObjectWithTag ("GameOverBGM");
		EventsCtr = GameObject.FindGameObjectWithTag ("EventsController");
		runAudio = AudioSources [3];
		deadAudio = AudioSources [6];
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
		if (attackAudioIdx > 2) {
			attackAudioIdx = 0;
		}

		// キャラが死んだらBGMを止める
		if (status.dead && gameOverAudioOnce == false) {
			BGM.GetComponent<AudioSource> ().Stop ();

			if (deadAudioOnce == false) {
				deadAudio.Play ();
				deadAudioOnce = true;
			}

			if (EventsCtr.GetComponent<EventsController> ().isZoom == false) {
				GameOverBGM.GetComponent<AudioSource> ().Play ();
				gameOverAudioOnce = true;
			}
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Idle")) {

			runAudio.Stop ();
		}

		// 攻撃モーション中
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack")) {

			// 一回流したら次のソースへ
			if (attackAudioOnce == false) {
				AudioSources [attackAudioIdx].Play ();
				attackAudioIdx++;
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

		// キャラが攻撃をくらったら
		if (status.getHit) {
			AudioSources [getHitAudioIdx].Play();
			getHitAudioIdx++;
			status.getHit = false;

			if (getHitAudioIdx > 5) {
				getHitAudioIdx = 4;
			}
		}
	}
}
