using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour {

	Slider slider;
	public GameObject Player;

	// Use this for initialization
	void Start () {

		// スライダーの取得
		slider = GetComponent<Slider>();
		Player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		slider.value = Player.GetComponent<CharaStatus>().hp;
	}
}
