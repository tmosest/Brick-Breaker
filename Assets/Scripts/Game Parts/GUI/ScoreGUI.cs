using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	string text = "Score: ";

	LevelManager levelManager;
	Text scoreText;

	/***********************************
	 * Private Functions
	***********************************/

	private void findLevelManager() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void findText() {
		scoreText = gameObject.GetComponent<Text> ();
	}

	private Color randomColor() {
		return new Color(Random.value, Random.value, Random.value);
	}

	/***********************************
	* Public Functions
	***********************************/

	public void updateText() {
		if (levelManager == null) {
			findLevelManager ();
		}
		if (scoreText == null) {
			findText ();
		}
		scoreText.text = text + levelManager.getScore ();
		scoreText.color = randomColor ();
	}

	/***********************************
	* Unity functions
	***********************************/

	// Use this for initialization
	void Start () {
		updateText ();
	}

}
