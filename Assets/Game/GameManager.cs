using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class GameManager : MonoBehaviour {

	public bool recording;

	private bool gamePaused = false;

	private float standardFixedDeltaTime;
	// Use this for initialization
	void Start () {
		recording = true;
		standardFixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			Debug.Log ("Recognised fire 1 button");
			recording = false;		
		} else {
			recording = true;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			if (gamePaused) {
				ResumeGame ();
			} else {
				PauseGame ();
			}
		}
	}

	void PauseGame(){
		gamePaused = true;
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	void ResumeGame(){
		Time.timeScale = 1;
		Time.fixedDeltaTime = standardFixedDeltaTime;
		gamePaused = false;
	}

//	void OnApplicationPause(bool pausedState){
//		PauseGame ();
//	}
}
