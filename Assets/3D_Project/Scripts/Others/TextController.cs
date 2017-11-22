using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public string[] scenarios;
	public Text uiText;
	GameObject textBox;

	int currentIndex = 0;


	// Use this for initialization
	void Start () {

		textBox = GameObject.FindGameObjectWithTag ("TextBox");
		TextUpdate ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("return")) {
			
			TextUpdate ();
		}


	}

	void TextUpdate () {

		if (currentIndex >= scenarios.Length) {
			textBox.SetActive (false);

		} else {
			uiText.text = scenarios [currentIndex];

		}
		currentIndex++;
	}
}
