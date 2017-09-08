using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	/***********************************
	 * Public Variables
	***********************************/

	public int lives;

	/***********************************
	 * Private Variables
	***********************************/

	LevelManager level;
	SpriteRenderer spriteRenderer;
	BrickCountGUI brickCountGUI;
	ScoreGUI scoreGui;

	private static string[] colors = {"yellow", "green", "red", "blue"};

	/***********************************
	 * Private Functions
	***********************************/

	private void decrementBrickCount() {
		if (level == null) {
			findLevelManager ();
		}
		level.decrementBrickCount ();
	}

	private void findBrickCountGUI() {
		brickCountGUI = GameObject.FindObjectOfType<BrickCountGUI> ();
	}

	private void findLevelManager() {
		level = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void findScoreGUI() {
		scoreGui = GameObject.FindObjectOfType<ScoreGUI> ();
	}

	private void findSpriteRenderer() {
		spriteRenderer = (SpriteRenderer)GetComponent<SpriteRenderer> ();
	}

	private string getBrickColorName(int brickLives) {
		print (colors.Length);
		return (brickLives - 1 < colors.Length) ? 
			colors [brickLives - 1] : colors[colors.Length - 1];
	}

	private Color getBrickColor(int brickLives) {
		Color result = Color.yellow;
		switch (getBrickColorName (brickLives)) {
		case "green":
			result = Color.green;
			break;
		case "red":
			result = Color.red;
			break;
		case "blue":
			result = Color.blue;
			break;
		}
		return result;
	}

	private void handleDeath() {
		Destroy (gameObject);
		decrementBrickCount ();
	}

	private void increaseBrickCount() {
		if (level == null) {
			findLevelManager ();
		}
		level.incrementBrickCount ();
	}

	private void increaseHits() {
		if (level == null) {
			findLevelManager ();
		}
		level.incrementHits ();
	}

	private bool isAlive() {
		return lives > 0;
	}

	private bool isBreakable() {
		return lives != -1;
	}

	private bool isDead() {
		return lives == 0;
	}

	private bool isUnbreakable() {
		return lives == -1;
	}

	private void updateBrickColor() {
		print (getBrickColorName(lives));
		spriteRenderer.color = getBrickColor(lives);
	}

	private void updateGui() {
		if (brickCountGUI == null) {
			findBrickCountGUI ();
		}
		brickCountGUI.updateText ();
		if (scoreGui == null) {
			findScoreGUI ();
		}
		scoreGui.updateText ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Use this for initialization
	void Start () {
		findLevelManager ();
		findSpriteRenderer ();
		findBrickCountGUI ();
		increaseBrickCount ();
	}

	void OnCollisionEnter2D(Collision2D collider) {
		--lives;
		if (isBreakable()) {
			increaseHits ();
			updateGui ();
			if (isAlive()) {
				updateBrickColor ();
			} else if (isDead()) {
				handleDeath ();
			}
		} // if Breakable
	}
}
