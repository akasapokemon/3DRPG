using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	

	Animator animator;
	GameObject target;
	public EnemyAttack child;
	EnemyStatus status;
	ParticleSystem particle;
	public float speed = 0.1f;
	public float attackDistance = 1.0f;
	public float noticeDistance = 5.0f;
	public bool isGetHit = false;

	void Start () {
		this.animator = GetComponent<Animator> ();
		this.target = GameObject.FindGameObjectWithTag ("Player");
		this.child.GetComponent<CapsuleCollider> ().isTrigger = false;
		this.status = GetComponent<EnemyStatus> ();
		this.particle = GetComponent<ParticleSystem> ();
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
			this.animator.SetBool ("run",false);
			this.animator.SetBool ("attack",true);
			child.isAttacked = true;

		// 攻撃モーション以外はキャラに向かって移動して来る
		} else if (distance < noticeDistance) {
			if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false &&
			   this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.getHit") == false) {

				// 移動アニメーションに遷移させる
				this.animator.SetBool ("attack",false);
				this.animator.SetBool ("run",true);

				// キャラに向かって移動
				transform.localRotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
				transform.position += transform.forward * speed * Time.deltaTime; // Time.deltaTime = 環境に依存せず、フレーム間で決まった距離移動させることができる
			}
		}

		if (this.status.life < 0) {
			this.animator.SetBool ("dead", true);
			StartCoroutine (DestroyEnemy (3.0f));
		}

		// ヒットエフェクト
		if (isGetHit) {
			this.animator.SetTrigger ("getHitTrigger");
			isGetHit = false;
		}
	}

	private IEnumerator DestroyEnemy(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy (gameObject);
	}
}
