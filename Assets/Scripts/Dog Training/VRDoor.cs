using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VRDoor : MonoBehaviour {

	public Pettable[] pettables;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool allPetted = true;
		foreach (Pettable pettable in pettables)
		{
			if (!pettable.petted) allPetted = false;
		}
		if (allPetted)
		{
			print("moving");
			TweenParams tParms = new TweenParams().SetEase(Ease.InExpo);
			transform.DOMoveY(-5, 0.08f).SetAs(tParms);
		}
		print(transform.position.y);
	}
}
