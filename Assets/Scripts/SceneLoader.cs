using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	/***********************************
	 * Public Functions
	***********************************/
	
	public void loadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void quitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
