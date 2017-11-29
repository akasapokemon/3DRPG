using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAttack : MonoBehaviour {

	public GameObject root;
	private CapsuleCollider collider;
	public bool attack = false;

	// アニメーション中一回しかヒットさせないためのbool
	private bool one_hit = false;


	void Start() {
		collider = GetComponent<CapsuleCollider> ();
	}

	void Update () {
		if (attack) {
			collider.isTrigger = true;
		}

		if (root.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {
			one_hit = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (attack) {
			// プレイヤーにのみ当たった時(今後設置するオブジェクトのことを考慮して)
			if (other.gameObject.tag == "Player" && one_hit == false) {

				// エネミー自身のアニメーションがAttackの時のみ
				if (root.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == true) {

					// trueにしてアニメーション一回につき一回しかダメージを負わせないことにする
					one_hit = true;

					// トリガーで察知したオブジェクトを操作すると、コンソールに謎の文がでるのでエラー(?)をキャッチして返してあげる
					try {
						other.gameObject.GetComponent<CharaStatus> ().hp -= root.GetComponent<EnemyStatus>().damage;
						other.gameObject.GetComponent<CharaStatus> ().getHit = true;
						collider.isTrigger = false;
						attack = false;

					} catch {
						return;
					}
				}
			}
		}
	}
}
