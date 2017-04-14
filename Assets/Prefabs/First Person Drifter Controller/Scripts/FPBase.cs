using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPBase : MonoBehaviour {
	public bool enableRunning = true;
	protected float controlLockTime = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		controlLockTime -= Time.deltaTime;
	}
	public void lockControls(float timeInSeconds)
	{
		controlLockTime = timeInSeconds;
	}
}
