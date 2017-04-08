using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour {

	 public GameObject arm;
	 public GameObject hearts;
	// Use this for initialization
	void Start () {
		foreach (Transform c in transform)
		{
			Transform chosen = null;
			if (c.GetComponent<DogBase>() != null)
			{
				chosen = c;
			}
			else if (c.GetComponentInChildren<DogBase>() != null)
			{
				chosen = c.GetComponentInChildren<DogBase>().transform;
			}
			if (chosen != null)
			{
				chosen.gameObject.GetComponent<DogBase>().hearts = this.hearts;
				chosen.gameObject.GetComponent<DogBase>().arm = this.arm;
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
