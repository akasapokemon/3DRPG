using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour {


	Animator animator;
	public CharaAttack child;
	public float speed = 3.0f;
	public bool isGetHit = false;
	bool isPressedUpKey = false;
	bool isPressedDownKey = false;
	bool isPressedRightKey = false;
	bool isPressedLeftKey = false;
	bool isPressedSpaceKey = false;
	Vector3 prevPosition;
	// Use this for initialization
	void Start () {
		this.animator = GetComponent<Animator> ();
		this.child.GetComponent<CharaAttack> ();
	}

	// Update is called once per frame
	void Update () {
		
		Move ();
		ProcessKeys ();

		}

	void Move() {
		
		if (this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false &&
		   this.animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.getHit") == false) {

			// 移動
			if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
				animator.SetBool ("isRun", true);
				transform.Translate (Vector3.forward * Time.deltaTime * speed * 1);
			} else {
				animator.SetBool ("isRun", false);
			}

			// 方向転換
			if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
				transform.rotation = Quaternion.LookRotation(transform.position + 
					(Vector3.right * Input.GetAxisRaw("Horizontal")) + 
					(Vector3.forward * Input.GetAxisRaw("Vertical")) 
					- transform.position);
			}

		}
			
		//ヒットエフェクト
		if (isGetHit) {
			this.animator.SetTrigger ("getHitTrigger");
			isGetHit = false;
		}
	}

	void ProcessKeys () {
		if (Input.GetKeyDown ("space")) {
			isPressedSpaceKey = true;
			child.isAttacked = true;
		}

		if (isPressedSpaceKey) {
			this.animator.SetTrigger ("attackTrigger");
			isPressedSpaceKey = false;
		}
	}
}
