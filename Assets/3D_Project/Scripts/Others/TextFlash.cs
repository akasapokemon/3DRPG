using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour {

	int counter = 0;
	float textColor = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FlashText ();
		
	}

	void FlashText () {
		counter++;
		GetComponent<Text> ().color = new Color (249, 255, 0, textColor);
		textColor = 1.0f * Mathf.Sin( counter * 0.1f) / 1.5f;
	}
}
