using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TromboneController : MonoBehaviour
{

	private AudioSource sound;
	private bool soundPlayed = false;
	// Use this for initialization
	void Start()
	{
		sound = GetComponent<AudioSource>();
		StartText.onCountDownEnd += PlaySoundOnce;
	}

	void PlaySoundOnce()
	{
		if (!soundPlayed)
		{
			sound.Play();
			soundPlayed = true;
		}
	}
}
