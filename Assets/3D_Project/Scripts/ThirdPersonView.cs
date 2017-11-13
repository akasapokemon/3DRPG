using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour {
	
	public GameObject Player;
	public int height = 6;
	public int deep = 5;
	bool isPressedZkey = false;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		transform.rotation = Quaternion.Euler(Player.transform.rotation.x,0,Player.transform.rotation.z);

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + height, Player.transform.position.z - deep);
	}
}
