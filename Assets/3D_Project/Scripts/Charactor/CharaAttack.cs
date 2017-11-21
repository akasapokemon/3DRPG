using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAttack : MonoBehaviour {

	Animator animator;
	AudioSource slashAudio;
	private MeshCollider collider;
	public bool attack = false;
	public float damage = 50.0f;

	void Start(){
		collider = GetComponent<MeshCollider> ();
		slashAudio = GetComponent<AudioSource> ();
	}

	void Update() {
		
		if (attack) {
			collider.isTrigger = true;
		} else {
			collider.isTrigger = false;
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
						slashAudio.Play();
						other.gameObject.transform.root.gameObject.GetComponent<EnemyStatus> ().hp -= damage;
					} else {
						other.gameObject.GetComponent<EnemyController>().getHit = true;
						slashAudio.Play();
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
