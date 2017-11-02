using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour {

	public int DeadEnemies = 0;
	bool BossEvent = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// 規定数討伐したらボスイベントをtrueに
		if (DeadEnemies == 50) {
			BossEvent = true;
		}
	}

	void Events	() {

		// 実装次第、記述するつもり
		if (BossEvent) {
			
		}
	}
}
