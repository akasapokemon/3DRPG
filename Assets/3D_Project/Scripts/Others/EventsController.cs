using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour {

	GameObject Player;
	public int DeadEnemies = 0;
	public bool BossEvent = false;
	bool GameOver = false;
	public bool isZoom = true;
	GameObject textController;
	public GameObject MagicSquare;
	bool appearMagicSquare = false;
	public LoadingScene loadingScene;
	AudioSource warpAudio;
	bool oneTime;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		textController = GameObject.FindGameObjectWithTag ("TextController");
		warpAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		// 規定数討伐したらボスイベントをtrueに
		if (DeadEnemies == 50) {
			BossEvent = true;
		}

		if (Player.GetComponent<CharaStatus> ().dead) {
			GameOver = true;
		}

		Events ();
	}

	void Events	() {

		// ボス発生イベント
		if (BossEvent) {

			// 魔法陣を出現させる
			if (appearMagicSquare == false) {
				MagicSquare.SetActive (true);
				appearMagicSquare = true;

			// 魔法陣に入っていたらボスシーンに遷移
			} else if (MagicSquare.GetComponent<JudgeOfMagicSquare>().intoMagicSquare) {
				if (oneTime == false) {
					warpAudio.Play ();
					StartCoroutine (DerayGoToBoss (1.0f));
					oneTime = true;
				}
			}
				
		}

		// ゲームオーバーイベント
		if (GameOver) {
			StartCoroutine (ZoomPlayer (3.0f));
		}
	}

	private IEnumerator ZoomPlayer(float waitTime) {
		yield return new WaitForSeconds(waitTime);

		if (Camera.main.fieldOfView < 34.5f) {

			textController.GetComponent<TextController> ().finishedZoom = true;
			isZoom = false;

		} else if (isZoom){

			// カメラのズームをデクリメントし続ける
			Camera.main.fieldOfView = Camera.main.fieldOfView - 1.0f;
		}
	}

	IEnumerator DerayGoToBoss (float waitTime) {
		yield return new WaitForSeconds (waitTime);
		loadingScene.goToBoss = true;

	}
}
