using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	LevelManager levelManager;

	/***********************************
	 * Private Functions
	***********************************/

	private void findLevelManager() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void handleBallBounce() {
		if (levelManager == null) {
			findLevelManager ();
		}
		levelManager.resetStreak ();
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 15);

		position.x = Mathf.Clamp (mousePosInBlocks, 0f, 12.5f);		
		//print (mousePosInBlocks);

		this.transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Collision");
		handleBallBounce ();
	}

}
