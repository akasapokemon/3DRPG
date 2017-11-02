using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAttack : MonoBehaviour {

	public GameObject root;
	private CapsuleCollider collider;
	public float damage = 1.0f;
	public bool isAttacked = false;

	// アニメーション中一回しかヒットさせないためのboolean
	private bool one_hit = false;


	void Start() {
		this.root = transform.root.gameObject;
		this.collider = GetComponent<CapsuleCollider> ();
	}

	void Update () {
		if (isAttacked) {
			this.collider.isTrigger = true;
		}

		if (this.root.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {
			one_hit = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		
		// プレイヤーにのみ当たった時(今後設置するオブジェクトのことを考慮して)
		if (other.gameObject.tag == "Player" && one_hit == false) {
			
			// キャラのヒットモーションを操作するためにコンポーネントを取得
			Animator chara = other.gameObject.GetComponent<Animator> ();

			// キャラのヒットモーションが再生されていない時にのみ、かつエネミー自身のアニメーションがAttackの時のみ
			if (chara.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false && 
				this.root.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == true) {

				// trueにしてアニメーション一回につき一回しかダメージを負わせないことにする
				one_hit = true;

				// トリガーで察知したオブジェクトを操作すると、コンソールに謎の文がでるのでエラー(?)をキャッチして返してあげる
				try {
					other.gameObject.GetComponent<CharaStatus> ().life -= damage;

					// キャラのヒットモーションを発動
					other.gameObject.GetComponent<CharaController>().isGetHit = true;

					this.collider.isTrigger = false;
					isAttacked = false;
				} catch {
					return;
				}
			}
		}
	}
}
