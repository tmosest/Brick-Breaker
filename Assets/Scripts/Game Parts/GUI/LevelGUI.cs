using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGUI : MonoBehaviour {

	/***********************************
	 * Private Functions
	***********************************/

	private int getLevel() {
		return GameObject.FindObjectOfType<LevelManager> ().getLevel();
	}

	private void setLevelText() {
		gameObject.GetComponent<Text> ().text = "Level " + getLevel ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Use this for initialization
	void Start () {
		setLevelText ();
	}
}
