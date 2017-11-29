using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour {

	Animator animator;
	AudioSource[] AudioSources;
	AudioSource attackAudio;
	GameObject Player;
	public bool playAttackAudio = false;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		AudioSources = GetComponents<AudioSource> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
		attackAudio = AudioSources [0];
	}
	
	// Update is called once per frame
	void Update () {

		AudioController ();
		
	}

	void AudioController () {
		
		// キャラが死んでたらオーディオを止める
		if (Player.GetComponent<CharaStatus> ().dead) {
			attackAudio.Stop ();
		}


		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.run") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.getHit")) {

			playAttackAudio = false;
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") && playAttackAudio) {
			if (attackAudio.isPlaying == false) {
				attackAudio.Play ();
			}
		} else if (playAttackAudio == false || animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1.0f) {
			attackAudio.Stop ();
		}
	}
}
