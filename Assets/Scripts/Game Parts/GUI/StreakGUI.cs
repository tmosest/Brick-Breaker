using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakGUI : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	private string text = "Streak: ";

	private LevelManager levelManager;
	private Text streakText;

	/***********************************
	* Private Functions
	***********************************/

	private void findLevelManager() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void findText() {
		streakText = gameObject.GetComponent<Text> ();
	}

	/***********************************
	* Public Functions
	***********************************/

	public void updateText() {
		if (levelManager == null) {
			findLevelManager ();
		}
		if (streakText == null) {
			findText ();
		}
		streakText.text = text + levelManager.getStreak ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Use this for initialization
	void Start () {
		updateText ();
	}
	
	// Update is called once per frame
	void Update () {
		updateText ();
	}
}
