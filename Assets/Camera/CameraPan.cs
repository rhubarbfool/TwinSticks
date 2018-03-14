using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	private GameObject player;

	private Vector3 toPlayer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		toPlayer = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//transform.position = player.transform.position + toPlayer;
		transform.LookAt (player.transform);
	}
}
