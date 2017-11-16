using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAttack : MonoBehaviour {

	Animator animator;
	private MeshCollider collider;
	public bool attack = false;
	public float damage = 50.0f;

	void Start(){
		collider = GetComponent<MeshCollider> ();
	}

	void Update() {
		
		if (attack) {
			collider.isTrigger = true;
		}
	}
			


	void OnTriggerEnter(Collider other) {
		if (attack) {
			if (this.gameObject.tag == "AttackPart" ) {
				try {
					
					// 衝突した部分が本体でなければ
					if(other.gameObject.GetComponent<EnemyController>() == null) {

						// ルートにアタッチされているコントローラーにアクセスする
						other.gameObject.transform.root.gameObject.GetComponent<EnemyController>().getHit = true;
						other.gameObject.transform.root.gameObject.GetComponent<EnemyStatus> ().hp -= damage;
					} else {
						other.gameObject.GetComponent<EnemyController>().getHit = true;
						other.gameObject.GetComponent<EnemyStatus> ().hp -= damage;
					}
					collider.isTrigger = false;
					attack = false;

				} catch {
					return;
				}
			}
		}
	}
}
