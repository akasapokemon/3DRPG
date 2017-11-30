using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

	AudioSource[] AudioSources;
	public GameObject EventsController;
	bool oneTime = false;

	void Start () {
		AudioSources = GetComponents<AudioSource> ();
	}
		
	void Update () {
		if ( EventsController.GetComponent<EventsController>().BossEvent && oneTime == false) {
			AudioSources [0].Stop ();
			AudioSources [1].Play ();
			oneTime = true;
		}
	}

}
