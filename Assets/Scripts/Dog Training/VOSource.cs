using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOSource : MonoBehaviour {

	public VRDoor door;
	public bool playRightAway = false;
	public bool playWhenPlayerSeesDog = false;
	[HideInInspector]
	public AudioSource audio;
	[HideInInspector]
	public VOManager manager;
	public delegate void OnPlayVoice();
	public OnPlayVoice onPlayVoice;
	// Use this for initialization
	void Awake () {
		
		audio = GetComponent<AudioSource>();
		audio.maxDistance += 50;
		if (playRightAway) StartText.onCountDownEnd += PlayVoice;
		else if (playWhenPlayerSeesDog) ArmController.onEnteredDogTrigger += PlayVoice;
		else door.onOpen += PlayVoice;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void PlayVoice()
	{
		manager.PlayVoice(this);
		if (onPlayVoice != null) onPlayVoice();
	}
}
