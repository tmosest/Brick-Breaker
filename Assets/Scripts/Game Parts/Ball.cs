using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	private Paddle paddle;

	private Vector3 paddleToBallVector;
	private bool hasStarted = false; 

	/***********************************
	 * Private Functions
	***********************************/

	private void findPaddle() {
		paddle = GameObject.FindObjectOfType<Paddle> ();
	}

	private Vector3 getRelativePositionToPaddle() {
		if (paddle == null) {
			findPaddle ();
		}
		return new Vector3 (
			paddle.transform.position.x + 0.5f, 
			paddle.transform.position.y + 0.7f, 
			this.transform.position.z
		);
	}

	private void handleNewRound() {
		if (roundHasNotStarted()) {
			
			this.transform.position = getRelativePositionToPaddle();

			if (startBallEvent()) {
				startBall ();
			}
		}
	}

	private void startBall() {
		hasStarted = true;
		Debug.Log ("Mouse clicked launch ball!!!");
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
	}

	private bool startBallEvent() {
		return Input.GetMouseButtonDown (0);
	}

	private bool roundHasNotStarted() {
		return !hasStarted;
	}

	/***********************************
	 * Public Functions
	***********************************/

	public void resetBall() {
		hasStarted = false;
	}

	/***********************************
	 * Unity Functions
	***********************************/

	// Use this for initialization
	void Start () {
		findPaddle ();
	}
	
	// Update is called once per frame
	void Update () {
		handleNewRound ();
	}
}
