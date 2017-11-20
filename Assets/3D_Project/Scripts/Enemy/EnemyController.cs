﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	

	Animator animator;
	AudioSource[] AudioSources;
	AudioSource attackAudio;
	GameObject target;
	public EnemyAttack child;
	EnemyStatus status;
	GameObject EventsController;
	public float speed = 5.0f;
	public float attackDistance = 1.0f;
	public float noticeDistance = 10.0f;
	public bool  getHit = false;
	bool dead = false;
	bool playAttackAudio = false;

	void Start () {
		
		animator = GetComponent<Animator> ();
		AudioSources = GetComponents<AudioSource> ();
		attackAudio = AudioSources [0];
		target = GameObject.FindGameObjectWithTag ("Player");
		child.GetComponent<CapsuleCollider> ().isTrigger = false;
		status = GetComponent<EnemyStatus> ();
		EventsController = GameObject.FindGameObjectWithTag ("EventsController");
	}

	void Update () {
		

		Action ();
		AudioController ();

	}

	void Action () {
		
		Vector3 enemyPos = transform.position;
		Vector3 charaPos = target.transform.position;
		float distance = Vector3.Distance (enemyPos, charaPos);


		// -----距離に応じた処理-----------

	//攻撃範囲に入ったら攻撃モーションに遷移させて、攻撃判定をEnemyAttack側で操作できるようにする
		if (dead == false) {
			if (distance < attackDistance) {
				AttackMotion ();
				child.attack = true;
				playAttackAudio = true;

				// 攻撃モーション以外はキャラに向かって移動して来る
			} else if (distance < noticeDistance) {
				if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false &&
				    animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.getHit") == false) {

					// 移動アニメーションに遷移させる
					RunMotion ();
					// キャラに向かって移動
					transform.localRotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
					transform.position += transform.forward * speed * Time.deltaTime; // Time.deltaTime = 環境に依存せず、フレーム間で決まった距離移動させることができる
				}
			} else {
				StopMotion ();
			}
		}

		// Enemyのデス判定
		if (this.status.hp < 1) {
			dead = true;
			StopMotion ();
			animator.SetBool ("dead", true);
			StartCoroutine (DestroyEnemy (5.0f));
		}

		// ヒットエフェクト
		if (getHit) {
			animator.SetTrigger ("getHitTrigger");
			getHit = false;
		}
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
		

	void RunMotion () {
		animator.SetBool ("attack", false);
		animator.SetBool ("run", true);
	}

	void AttackMotion () {
		animator.SetBool ("run", false);
		animator.SetBool ("attack", true);
	}

	void StopMotion() {
		playAttackAudio = true;
		animator.SetBool ("run", false);
		animator.SetBool ("attack", false);
	}

	// コルーチン用の関数
	private IEnumerator DestroyEnemy(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy (gameObject);
		EventsController.GetComponent<EventsController>().DeadEnemies++;
	}
}
