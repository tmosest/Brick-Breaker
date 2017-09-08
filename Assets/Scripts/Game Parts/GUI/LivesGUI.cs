using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesGUI : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	private Text livesText;
	private LevelManager levelManager;

	/***********************************
	 * Private Functions
	***********************************/

	private void findLevelManager() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void findLivesText() {
		livesText = gameObject.GetComponent<Text> ();
	}

	/***********************************
	 * Public Functions
	***********************************/

	public void updateLives() {
		if (livesText == null || levelManager == null) {
			findLivesText ();
			findLevelManager ();
		}
		livesText.text = "Lives: " + levelManager.getLives ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Use this for initialization
	void Start () {
		findLevelManager ();
		findLivesText ();
		updateLives ();
	}
}
