using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour {
	
	GameObject Player;
	Vector3 PlayerPos;
	public int height = 6;
	public int deep = 5;
	bool isPressedZkey = false;
	Vector3 currentRotation;
	Vector3 updateRotation;
	bool front = false;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerPos = Player.transform.position;
		transform.rotation = Quaternion.Euler(Player.transform.rotation.x,0,Player.transform.rotation.z);
		transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + height, Player.transform.position.z - deep);

	}
	
	// Update is called once per frame
	void Update () {

		ChangeOfView ();

		if (Input.GetKeyDown ("c")) {
			front = true;
		}
	}

	void ChangeOfView () {
		// targetの移動量分、自分（カメラ）も移動する
		transform.position += Player.transform.position - PlayerPos;
		PlayerPos = Player.transform.position;

		// マウスの右クリックを押している間
		if (Input.GetMouseButton(1)) {
			// マウスの移動量
			float mouseInputX = Input.GetAxis("Mouse X");
			float mouseInputY = Input.GetAxis("Mouse Y");
			// targetの位置のY軸を中心に、回転する
			transform.RotateAround(PlayerPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
		}  

		if (front) {
			transform.rotation = Quaternion.Euler(Player.transform.rotation.x,0,Player.transform.rotation.z);
		}
			
	}
}
