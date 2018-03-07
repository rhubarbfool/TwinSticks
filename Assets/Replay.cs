using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {

	private const int bufferSize = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferSize];

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Record ();

	}
	void PlayBack (){
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferSize;
		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
	}

	void Record ()
	{
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferSize;
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
