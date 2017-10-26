using UnityEngine;
using System.Collections;

public class CameraController_1 : MonoBehaviour {

	public GameObject player = null;
	public Vector3 offset = Vector3.zero;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {
		Vector3 newPosition = transform.position;
		newPosition.x = player.transform.position.x + offset.x;
		newPosition.y = player.transform.position.y + offset.y;
		newPosition.z = player.transform.position.z + offset.z;
		transform.position = newPosition;
	}
}