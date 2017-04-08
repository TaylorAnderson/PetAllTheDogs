using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog2D : DogBase {

	
	// Update is called once per frame
	protected void FixedUpdate () {
		counter += Time.deltaTime;
		if (counter >= moveInterval)
		{
			if (!isAngel)
			{
				movement = Random.insideUnitSphere * Random.Range(moveSpeed / 1.5f, moveSpeed * 1.5f);
				movement.z = 0;
				movement.y = 0;
			}
			else
			{
				movement = (arm.transform.position - transform.position).normalized;
				movement.y += 10;

			}
			counter = 0;
		}
		rb.AddForce(movement);
		base.FixedUpdate();
	}
}
