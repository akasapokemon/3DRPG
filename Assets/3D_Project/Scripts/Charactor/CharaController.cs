using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour {


	Animator animator;
	public CharaAttack child;
	public Rigidbody rb;
	AudioSource[] AudioSources;
	AudioSource runAudio;
	float speed = 15.0f;
	float timer = 0.5f;
	int audioIdx = 0;
	public bool dead = false;
	public bool start = false;
	bool isPressedUpKey = false;
	bool isPressedDownKey = false;
	bool isPressedRightKey = false;
	bool isPressedLeftKey = false;
	bool isPressedSpaceKey = false;
	bool attackAudioOnce = false;
	bool playRunAudio= false;
	float inputHorizontal;
	float inputVertical;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		child.GetComponent<CharaAttack> ();
		rb = GetComponent<Rigidbody> ();
		AudioSources = GetComponents<AudioSource> ();
		runAudio = AudioSources [3];

	}

	// Update is called once per frame
	void Update () {

		// 攻撃モーション中では無い場合
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") == false) {
			Action ();
			attackAudioOnce = false;
		} else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f){
			child.attack = false;
		}
		AudioController ();
	}
		

	void AudioController () {

		// 攻撃音声を一回一回変える
		if (audioIdx > 2) {
			audioIdx = 0;
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack") ||
		   animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Idle")) {

			runAudio.Stop ();
		}

		// 攻撃モーション中
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attack")) {

			// 一回流したら次のソースへ
			if (attackAudioOnce == false) {
				AudioSources [audioIdx].Play ();
				audioIdx++;
				attackAudioOnce = true;
			}
		}

		// 移動モーション中
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.run")) {

			if (dead) {
				runAudio.Stop ();
			}

			if (runAudio.isPlaying == false) {
				runAudio.Play ();
			}
		}
	}

	void Action () {
		
		if (Input.GetKeyDown ("space")) {
			child.attack = true;
			animator.SetTrigger ("attackTrigger");
		}


		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {

			playRunAudio = true;

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
				rb.velocity = moveForward * speed;

				// 方向転換
				transform.rotation = Quaternion.LookRotation (moveForward);
			}
		} else {
			animator.SetBool ("run", false);
			rb.velocity = Vector3.zero;
		}

	}
}
