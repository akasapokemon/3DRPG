using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour {

	GameObject Player;
	public int DeadEnemies = 0;
	bool BossEvent = false;
	bool GameOver = false;
	GameObject textController;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		textController = GameObject.FindGameObjectWithTag ("TextController");
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
			
		}

//		// ゲームオーバーイベント
//		if (GameOver) {
//
//			if (Camera.main.fieldOfView < 34.5f) {
//
//				textController.GetComponent<TextController> ().finishedZoom = true;
//			}
//
//			Camera.main.fieldOfView - 0.1f;
//		}
	}
}
