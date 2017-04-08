using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TromboneController : MonoBehaviour {

	public StartTextController startText;
	private AudioSource sound;
	private bool soundPlayed = false;
	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startText.finished && !soundPlayed)
		{
			sound.Play();
			soundPlayed = true;
		}
	}
}
