using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrantController : MonoBehaviour {

	ParticleSystem jet;
	// Use this for initialization
	void Start () {
		jet = GetComponentInChildren<ParticleSystem>();
		
	}
	
	// Update is called once per frame
	void Update () {
		jet.Play();

	}
}
