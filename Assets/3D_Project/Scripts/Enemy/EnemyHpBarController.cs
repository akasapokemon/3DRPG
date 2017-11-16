using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarController : MonoBehaviour {

	Slider slider;
	public GameObject parent;

	// Use this for initialization
	void Start () {

		// スライダーの取得
		slider = transform.Find("Slider").gameObject.GetComponent<Slider>();
		slider.value = 100;
	}

	// Update is called once per frame
	void Update () {

		slider.value = parent.GetComponent<EnemyStatus>().hp;
	}
}
