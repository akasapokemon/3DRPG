using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour {

	Animator animator;
	AudioSource[] AudioSources;
	AudioSource attackAudio;
	public bool playAttackAudio = false;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		AudioSources = GetComponents<AudioSource> ();
		attackAudio = AudioSources [0];
	}
	
	// Update is called once per frame
	void Update () {

		AudioController ();
		
	}

	void AudioController () {

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
