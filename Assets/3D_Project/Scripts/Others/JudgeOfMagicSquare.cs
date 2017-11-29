using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeOfMagicSquare : MonoBehaviour {

	public bool intoMagicSquare = false;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			intoMagicSquare = true;
		}
	}
}
