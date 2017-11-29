using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public string[] scenarios;
	public Text uiText;
	public GameObject textBox;
	GameObject eventsCtr;
	public bool finishedZoom = false;
	public GameObject GameOver;
	public GameObject BackGround;
	public GameObject Continue;
	bool startFlag = true;
	bool startBackGroundFlag = true;
	float gameOverColor = 0f;
	float backGroundColor = 0f;
	public GameObject ContinueButton;
	float continueColor = 0f;
	int counter = 0;
	bool appearText = false;
	bool appearBackGround = false;
	bool appearButton = false;
	int currentIndex = 0;


	// Use this for initialization
	void Start () {

		eventsCtr = GameObject.FindGameObjectWithTag ("EventsController");
		TextUpdate ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("return")) {
			
			TextUpdate ();
		}

		if (eventsCtr.GetComponent<EventsController> ().isZoom == false) {
			GameOverText ();
			GameOverBackGround ();
		}

		if (gameOverColor == 1.0f && backGroundColor == 0.8f) {
			FlashContinue ();
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

	void GameOverText () {
		if (startFlag) {
			if (appearText == false) {
				GameOver.SetActive (true);
				appearText = true;
			}

			GameOver.GetComponent<Text>().color = new Color (255, 0, 0, gameOverColor);
			gameOverColor += Time.deltaTime;

			if (gameOverColor > 1) {
				gameOverColor = 1;
				startFlag = false;
			}
		}
	}

	void GameOverBackGround () {
		if (startBackGroundFlag) {
			if (appearBackGround == false) {
				BackGround.SetActive (true);
				appearBackGround = false;
			}

			BackGround.GetComponent<Image>().color = new Color (0, 0, 0, backGroundColor);
			backGroundColor += Time.deltaTime;

			if (backGroundColor > 0.8f) {
				backGroundColor = 0.8f;
				startBackGroundFlag = false;
			}
		}
	}

	void FlashContinue () {

		if (appearButton == false) {
			ContinueButton.SetActive (true);
			appearButton = true;
		}

		counter++;
		Continue.GetComponent<Text>().color = new Color (249, 255, 0, continueColor);
		continueColor = 1.0f * Mathf.Sin( counter * 0.1f) / 1.5f;
	}
}
