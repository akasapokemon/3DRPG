using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAttack : MonoBehaviour {

	Animator animator;
	private MeshCollider collider;
	public bool isAttacked = false;
	public int damage = 1;

	void Start(){
		this.animator = GetComponent<Animator> ();
		this.collider = GetComponent<MeshCollider> ();
	}

	void Update() {
		if (isAttacked) {
			this.collider.isTrigger = true;
		}
	}
			


	void OnTriggerEnter(Collider other) {
		if (isAttacked) {
			Animator enemy = other.gameObject.GetComponent<Animator> ();

			// ヒットモーションが再生されていない時に攻撃判定
			if (enemy.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.getHit") == false) {
				if (this.gameObject.tag == "AttackPart" ) {
					try {
						other.gameObject.GetComponent<EnemyStatus> ().life -= damage;
						other.gameObject.GetComponent<EnemyController>().isGetHit = true;
						this.collider.isTrigger = false;
						isAttacked = false;
					} catch {
						return;
					}
				}
			}
		}
	}
}
