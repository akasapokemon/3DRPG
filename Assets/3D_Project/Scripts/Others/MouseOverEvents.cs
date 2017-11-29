using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverEvents : MonoBehaviour {

	AudioSource mouseOverAudio;

	// Use this for initialization
	void Start () {
		mouseOverAudio = GetComponent<AudioSource> ();
		
	}
	
	void OnMouseEnter () { 
		mouseOverAudio.Play ();
	}
}
