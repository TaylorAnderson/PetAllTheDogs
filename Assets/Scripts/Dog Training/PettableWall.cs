using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettableWall : Pettable {

	public override void OnPet(ArmBase arm)
	{
		base.OnPet(arm);
		gameObject.SetActive(false);
	}
}
