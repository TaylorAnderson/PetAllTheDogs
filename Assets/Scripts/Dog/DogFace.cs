using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFace : DogBase {

	bool scaledHearts = false;

	void Start() {
		base.Start();
		distance = 1000000000;
	}
	void Update()
	{
		if (hearts && !scaledHearts)
		{
			scaledHearts = true;
			
		}
	}
}
