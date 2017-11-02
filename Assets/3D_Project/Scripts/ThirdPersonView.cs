using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour {
	
	public GameObject Player;
	public int height = 6;
	public int deep = 5;

	void Start () {
		this.Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + height, Player.transform.position.z - deep);
		transform.rotation =  Quaternion.Euler(40,0,0);
	}
}
