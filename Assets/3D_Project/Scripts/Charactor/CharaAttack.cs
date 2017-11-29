using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAttack : MonoBehaviour {

	Animator animator;
	AudioSource slashAudio;
	private MeshCollider collider;
	GameObject rootStatus;
	public bool attack = false;

	void Start(){
		collider = GetComponent<MeshCollider> ();
		slashAudio = GetComponent<AudioSource> ();
		rootStatus = transform.root.gameObject;
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
						other.gameObject.transform.root.gameObject.GetComponent<EnemyStatus>().getHit = true;
						slashAudio.Play();
						other.gameObject.transform.root.gameObject.GetComponent<EnemyStatus> ().hp -= rootStatus.GetComponent<CharaStatus>().damage;
					} else {
						other.gameObject.GetComponent<EnemyStatus>().getHit = true;
						slashAudio.Play();
						other.gameObject.GetComponent<EnemyStatus> ().hp -= rootStatus.GetComponent<CharaStatus>().damage;
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
