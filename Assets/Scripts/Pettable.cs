using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pettable : MonoBehaviour {

	[HideInInspector]
	public float maxDistance = 10.0f;
	[HideInInspector]
	public bool petted = false;

	[HideInInspector]
	public GameObject hearts;
	// Use this for initialization
	public void Start () {
		hearts = Resources.Load("Hearts") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public virtual void OnPet(ArmBase arm)
	{

		Instantiate(hearts, transform.position, Quaternion.identity);
		petted = true;
	}
}
