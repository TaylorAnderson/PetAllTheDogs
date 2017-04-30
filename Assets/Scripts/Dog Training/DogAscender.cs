using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAscender : MonoBehaviour {

	public VOSource source;
	public VRDoor door;
	bool audioFinished = false;
	// Use this for initialization
	void Start () {
		source.onPlayVoice += StartTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (audioFinished)
		{

			transform.Translate(0, 0.6f, 0);
		}
	}
	void StartAscent() 
	{
		audioFinished = true;
		door.Open();
	}
	void StartTimer()
	{
		Invoke("StartAscent", source.audio.clip.length);
	}
}
