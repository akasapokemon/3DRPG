using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplayAndHidden : MonoBehaviour {

	public GameObject TextCtr;
	public GameObject TextBox;
	public GameObject EventsCtr;

	
	// Update is called once per frame
	void Update () {

		if (TextCtr.GetComponent<TextController> ().showText) {
			TextBox.SetActive (true);
		} else {
			TextBox.SetActive (false);
		}

		if (EventsCtr.GetComponent<EventsController> ().appearMagicSquare) {
			TextCtr.GetComponent<TextController> ().showText = true;
		}
	}
}
