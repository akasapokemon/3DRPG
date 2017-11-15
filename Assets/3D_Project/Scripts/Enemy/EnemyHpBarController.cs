using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarController : MonoBehaviour {

	Slider slider;
	EnemyStatus root;

	// Use this for initialization
	void Start () {

		// スライダーの取得
		slider = GetComponent<Slider>();
		slider.value = 100;
		root = transform.root.gameObject.GetComponent<EnemyStatus> ();

	}

	// Update is called once per frame
	void Update () {
		if (root.hp > 1) {
			root.hp = 0;
		}

		slider.value = root.hp;
	}
}
