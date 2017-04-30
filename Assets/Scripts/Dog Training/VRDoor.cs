using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VRDoor : MonoBehaviour {

	public Pettable[] pettables;
	public delegate void OnOpen();
	public OnOpen onOpen;
	bool dispatchedOnOpen = false;
	public bool waitingForPlayerInput = false;
	bool playerDone = false;
	// Use this for initialization
	void Start () {
		ArmController.onPet += OnPlayerPet;
	}
	
	// Update is called once per frame
	void Update () {
		
		bool allPetted = true;
		foreach (Pettable pettable in pettables)
		{
			if (!pettable.petted) allPetted = false;
		}
		if (pettables.Length == 0) allPetted = false;


		if (allPetted || (waitingForPlayerInput && playerDone))
		{
			Open();
		}
	}
	public void Open() {
		if (onOpen != null && !dispatchedOnOpen)
		{
			print("hey, fired");
			onOpen();
			dispatchedOnOpen = true;
		}
		TweenParams tParms = new TweenParams().SetEase(Ease.InExpo);
		transform.DOMoveY(-5, .2f).SetAs(tParms);
	}
	void OnPlayerPet()
	{
		playerDone = true;
	}
}
