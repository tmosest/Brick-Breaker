using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	/***********************************
	 * Private Variables
	***********************************/

	private static LevelManager instance = null;

	private const int maxLevel = 4;
	private const int startingLives = 3;
	private const int brickPoints = 10;

	private static int brickCount;
	private static int level;
	private static int lives;
	private static int hits;
	private static int score;
	private static int streak;

	/***********************************
	 * Private Functions
	***********************************/

	private void gameOver() {
		reset ();
		loadScene ("Win Screen");
	}

	private void handleLevelUp() {
		if (brickCount == 0) {
			if (level < maxLevel) {
				++level;
				print ("Level cap hit.");
			}
			print ("Level up to " + level);
			loadLevel (level);
		}
	}

	private int calculatePointsToAdd() {
		return (streak) * brickPoints;
	}

	private void incrementScore() {
		score += calculatePointsToAdd ();	
	}

	private void incrementStreak() {
		++streak;
	}

	private void loadLevel(int level){
		string name = "Level_" + level;
		loadScene (name);
	}

	private void loadScene(string name) {
		Debug.Log ("New Scene: " + name);
		SceneManager.LoadScene (name);
	}
		
	private void reset() {
		hits = 0;
		level = 0;
		brickCount = 0;
		score = 0;
		lives = startingLives;
		resetStreak ();
	}

	private void resetBall() {
		GameObject.FindObjectOfType<Ball> ().resetBall ();
	}

	/***********************************
	 * Public Functions
	***********************************/

	public void decrementBrickCount() {
		if (brickCount > 0) {
			brickCount--;
		}
		handleLevelUp ();
	}

	public void decrementLives() {
		--lives;
		if (lives < 1) {
			gameOver ();
		} else {
			resetBall ();
		}
	}

	public void incrementBrickCount() {
		brickCount++;
	}

	public void incrementHits() {
		++hits;
		incrementStreak ();
		incrementScore ();
	}

	public int getBrickHits() {
		return hits;
	}

	public int getLevel() {
		return level;
	}

	public int getLives() {
		return lives;
	}

	public int getScore() {
		return score;
	}

	public int getStreak() {
		return streak;
	}

	public void resetStreak() {
		streak = 0;
	}

	/***********************************
	 * Unity Functions
	***********************************/

	void Start () {
		if (instance != null) {
			Destroy (gameObject);
			Debug.Log ("Destroyed duplicate LevelManager");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			reset ();
		}
	}
}
