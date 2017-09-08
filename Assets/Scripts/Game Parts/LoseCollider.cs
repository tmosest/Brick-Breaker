using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	private LevelManager levelManager;
	private LivesGUI livesGUI;

	/***********************************
	 * Private Functions
	***********************************/

	private void findLevelManager() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void findLivesGUI() {
		livesGUI = GameObject.FindObjectOfType<LivesGUI> ();
	}

	private void decrementLives() {
		if (levelManager == null) {
			findLevelManager ();
		}
		levelManager.decrementLives ();
	}

	private void handleBallDeath() {
		decrementLives ();
		updateLivesText ();
	}

	private void updateLivesText() {
		if (livesGUI == null) {
			findLivesGUI ();
		}
		livesGUI.updateLives ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	void OnTriggerEnter2D (Collider2D trigger) {
		Debug.Log ("Tigger: Ball hit bottom");
		handleBallDeath ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Collision");
	}

	// Use this for initialization
	void Start () {
		findLevelManager ();
		findLivesGUI ();
	}

}
