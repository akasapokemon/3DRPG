using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour {
	
	public GameObject Player;
//	private Vector3 offset;
	public int height = 6;
	public int deep = 5;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
//		offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

//		transform.position = Player.transform.position + offset;

		transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + height, Player.transform.position.z - deep);
//		transform.rotation = Quaternion.Euler (20, 0, 0);
		transform.rotation =  Quaternion.Euler(40,0,0);
	}
}
