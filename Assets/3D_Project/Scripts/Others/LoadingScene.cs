using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

	public bool isPressedStart = false;
	public bool isPressedQuit = false;
	public bool isPressedContinue = false;
	private AsyncOperation async;
	public GameObject OtherUi;
	public GameObject Slider;
	public GameObject Panel;

	void Update () {
		if (isPressedStart) {
			ChangeToGameScene ();
		}
	}

	void ChangeToGameScene () {
		OtherUi.SetActive (false);
		Slider.SetActive (true);
		Panel.SetActive (true);
		StartCoroutine (LoadScene ("GameScene"));
		isPressedStart = false;
	}

	void ChangeToBossScene () {
	}

	void ChangeToGameRestart () {
		
	}

	IEnumerator LoadScene (string Scene) {
		async = SceneManager.LoadSceneAsync(Scene);

		while (!async.isDone) {
			Slider.GetComponent<Slider> ().value = async.progress;
			yield return null;
		}
	}


}
