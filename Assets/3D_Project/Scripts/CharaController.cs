using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour {


	Animator animator;
	public CharaAttack child;
	public Rigidbody rigid;
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
		animator = GetComponent<Animator> ();
		child.GetComponent<CharaAttack> ();
		rigid = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

		Move ();
		ProcessKeys ();

	}

	void Move() {

		
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {

			// 移動
			if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {


				// 移動と方向転換
				if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {
					animator.SetBool ("run", true);
					transform.Translate (Vector3.forward * Time.deltaTime * speed * 1);
					transform.rotation = Quaternion.LookRotation (transform.position +
						(Vector3.right * Input.GetAxisRaw ("Horizontal")) +
						(Vector3.forward * Input.GetAxisRaw ("Vertical"))
						- transform.position);
				}
			} else {
				animator.SetBool ("run", false);
			}
		}

//		if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1.0f) {
//			child.attack = false;
//		}
	}

	void ProcessKeys () {
		if (Input.GetKeyDown ("space")) {
			isPressedSpaceKey = true;
			child.attack = true;
		}

		if (isPressedSpaceKey) {
			animator.SetTrigger("attackTrigger");
			isPressedSpaceKey = false;
		}
	}
}
