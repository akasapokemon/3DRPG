using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvents : MonoBehaviour {

	public LoadingScene LoadingScene;

	public void OnClickToGameScene () {
		LoadingScene.isPressedStart = true;
	}

	public void OnClickToQuit () {
		LoadingScene.isPressedQuit = true;
	}

	public void OnClickToGameRestart () {
		LoadingScene.isPressedContinue = true;
	}
}
