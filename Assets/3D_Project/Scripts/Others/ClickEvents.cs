using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvents : MonoBehaviour {

	public LoadingScene LoadingScene;
	AudioSource pressAudio;

	void Start () {
		pressAudio = GetComponent<AudioSource> ();
	}

	public void OnClickToGameScene () {
		StartCoroutine (DeraySettingFlag ("start", 1.0f));
	}

	public void OnClickToQuit () {
		LoadingScene.isPressedQuit = true;
	}

	public void OnClickToGameRestart () {
		pressAudio.Play ();
		StartCoroutine (DeraySettingFlag ("continue", 1.0f));
	}

	// 物理的に遅らせて、音を最後まで流す
	IEnumerator DeraySettingFlag (string name,float waitTime) {
		pressAudio.Play ();
		yield return new WaitForSeconds(waitTime);

		if (name == "start") {
			LoadingScene.isPressedStart = true;
		} else if (name == "quit") {
			LoadingScene.isPressedQuit = true;
		} else if (name == "continue") {
			LoadingScene.isPressedContinue = true;
		}
	}
}
