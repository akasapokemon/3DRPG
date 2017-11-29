using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour {


	Animator animator;
	public CharaAttack child;
	CharaStatus status;
	GameObject eventsCtr;
	Rigidbody rb;
	bool isPressedUpKey = false;
	bool isPressedDownKey = false;
	bool isPressedRightKey = false;
	bool isPressedLeftKey = false;
	bool isPressedSpaceKey = false;
	float inputHorizontal;
	float inputVertical;

	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator> ();
		child.GetComponent<CharaAttack> ();
		status = GetComponent<CharaStatus> ();
		eventsCtr = GameObject.FindGameObjectWithTag ("EventsController");
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		// 攻撃モーション中では無い場合
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {
			Action ();

		} else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f){
			child.attack = false;
		}
	}
		

	void Action () {

		if (status.hp < 1) {
			status.dead = true;
			animator.SetBool ("dead", true);
		}
			

		if (status.dead == false) {
			
			// キャラの攻撃
			if (Input.GetKeyDown ("space")) {
				child.attack = true;
				animator.SetTrigger ("attackTrigger");
			}


			if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {


				// キー入力を値として取得
				inputHorizontal = Input.GetAxisRaw ("Horizontal");
				inputVertical = Input.GetAxisRaw ("Vertical");

				// Cameraの正面方向をy軸を考慮せず取得
				Vector3 cameraForward = Vector3.Scale (Camera.main.transform.forward, new Vector3 (1, 0, 1));

				// カメラベクトルに入力値を乗算してから正規化
				Vector3 moveForward = ((cameraForward * inputVertical) + (Camera.main.transform.right * inputHorizontal)).normalized;

				if (moveForward != Vector3.zero) {
					animator.SetBool ("run", true);

					// 移動
					rb.velocity = moveForward * status.speed;

					// 方向転換
					transform.rotation = Quaternion.LookRotation (moveForward);
				}
			} else {
				animator.SetBool ("run", false);
				rb.velocity = Vector3.zero;
			}
		}
	}
}
