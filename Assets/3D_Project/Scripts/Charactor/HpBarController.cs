using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour {

	Slider slider;
	CharaStatus root;

	// Use this for initialization
	void Start () {

		// スライダーの取得
		slider = GetComponent<Slider>();
		root = transform.root.gameObject.GetComponent<CharaStatus> ();

	}
	
	// Update is called once per frame
	void Update () {
		root.hp += 0.01f;
		if (root.hp > 1) {
			root.hp = 0;
		}

		slider.value = root.hp;
	}
}
