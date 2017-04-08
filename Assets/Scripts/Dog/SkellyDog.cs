using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyDog : DogBase {

	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(0.1f, 0.1f, 0.1f);
	}
}
