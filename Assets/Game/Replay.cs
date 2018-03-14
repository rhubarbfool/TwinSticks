using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {

	private const int bufferSize = 1000;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferSize];

	private Rigidbody rigidBody;

	private GameManager gameManager;

	private int maxFrame = 0;

	private int startFrame = 0;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		gameManager = FindObjectOfType<GameManager>() as GameManager;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.recording) {
			Record ();
		} else {
			PlayBack ();
		}
	}
	void PlayBack (){
		rigidBody.isKinematic = false;
		//int frame = Mathf.Clamp (Time.frameCount % bufferSize, startFrame, maxFrame); 
		int frame = Time.frameCount % (maxFrame+1 - startFrame) + startFrame; 
		Debug.Log ("Playing back frame " + frame + " from " + maxFrame);
		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
	}

	void Record ()
	{
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferSize;
		if (startFrame == 0) {
			startFrame = frame;
		}
		maxFrame = frame > maxFrame ? frame : maxFrame;
		keyFrames [frame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
	}
}

public class MyKeyFrame{
	public float 		time;
	public Vector3		position;
	public Quaternion	rotation;


	public MyKeyFrame( float inTime, Vector3 inPos, Quaternion inRot ){
		time = inTime;
		position = inPos;
		rotation = inRot;
	}
}
