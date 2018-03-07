using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class GameManager : MonoBehaviour {

	private bool recording;
	// Use this for initialization
	void Start () {
		recording = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			recording = true;		
		} else {
			recording = false;
		}
	}
}
