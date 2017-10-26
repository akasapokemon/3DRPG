using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	

	Animator animator;
	GameObject target;
	public EnemyAttack child;
	public float speed = 0.1f;
	public float attackDistance = 1.0f;
	public bool isGetHit = false;

	void Start () {
		this.animator = GetComponent<Animator> ();
		this.target = GameObject.FindGameObjectWithTag ("Player");
		this.child.GetComponent<CapsuleCollider> ().isTrigger = false;
	}

	void Update () {


		Move ();

	}

	void Move() {
		Vector3 enemyPos = transform.position;
		Vector3 charaPos = target.transform.position;
		float distance = Vector3.Distance (enemyPos, charaPos);

		// -----距離に応じた処理-----------

		// 攻撃範囲に入ったら攻撃モーションに遷移させて、攻撃判定をEnemyAttack側で操作できるようにする
		if (distance < attackDistance) {
			this.animator.SetBool ("isWalk",false);
			this.animator.SetBool ("isAttack",true);
			child.isAttacked = true;

		// 攻撃モーション以外はキャラに向かって移動して来る
		} else if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false && 
			this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.getHit") == false) {
			
			// 移動アニメーションに遷移させる
			this.animator.SetBool ("isAttack",false);
			this.animator.SetBool ("isWalk",true);
			
			// キャラに向かって移動
			transform.localRotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
			transform.position += transform.forward * speed * Time.deltaTime; // Time.deltaTime = 環境に依存せず、フレーム間で決まった距離移動させることができる
		}

		// ヒットエフェクト
		if (isGetHit) {
			this.animator.SetTrigger ("getHitTrigger");
			isGetHit = false;
		}
	}
}
