using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickCountGUI : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	private LevelManager levelManager;
	private Text brickCountText;
	private string text = "Bricks Hit: ";

	/***********************************
	 * Private Functions
	***********************************/

	private void findLevelManager() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void findText() {
		brickCountText = gameObject.GetComponent<Text> ();
	}

	/***********************************
	 * Public Functions
	***********************************/

	public void updateText() {
		if (levelManager == null || brickCountText == null) {
			findLevelManager ();
			findText();
		} 
		brickCountText.text = text + levelManager.getBrickHits ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Use this for initialization
	void Start () {
		findLevelManager ();
		findText ();
		updateText ();
	}

}
