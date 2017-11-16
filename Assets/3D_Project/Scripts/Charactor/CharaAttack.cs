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
//		Debug.Log ("1");
		if (attack) {
//			Debug.Log ("2");
			if (this.gameObject.tag == "AttackPart" ) {
				try {
//					Debug.Log ("3");
//					Debug.Log (this.gameObject.name);
//					Debug.Log (other.gameObject.name);
					// 衝突した部分が本体でなければ
					if(other.gameObject.GetComponent<EnemyController>() == null) {

						// ルートにアタッチされているコントローラーにアクセスする
						other.gameObject.transform.root.gameObject.GetComponent<EnemyController>().getHit = true;
						other.gameObject.transform.root.gameObject.GetComponent<EnemyStatus> ().hp -= damage;
//						Debug.Log ("4");
					} else {
						other.gameObject.GetComponent<EnemyController>().getHit = true;
						other.gameObject.GetComponent<EnemyStatus> ().hp -= damage;
//						Debug.Log ("5");
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
