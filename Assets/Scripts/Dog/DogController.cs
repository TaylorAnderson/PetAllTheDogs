using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogController : DogBase {
	// Update is called once per frame
	public GameObject leftWing;
	public GameObject rightWing;
	protected void FixedUpdate() {
		counter += Time.deltaTime;
	
		
		if (counter >= moveInterval)
		{
			if (!isAngel)
			{
				movement = Random.insideUnitSphere * Random.Range(moveSpeed / 1.5f, moveSpeed * 1.5f);
				movement.y = 0;
			}
			else
			{
				movement = (arm.transform.position - transform.position).normalized;
				movement.y += 5;

			}
			counter = 0;
		}
		if (moveSpeed > 0) transform.right = new Vector3(rb.velocity.x, 0, rb.velocity.z);


		if (transform.position.y < startY - 50)
		{
			isAngel = true;
			leftWing.GetComponent<MeshRenderer>().enabled = true;
			rightWing.GetComponent<MeshRenderer>().enabled = true;
		}


		if (isAngel)
		{

			rb.useGravity = false;
			rb.AddForce(new Vector3(0, 1, 0));
			waggingTail = false;
		}
		if (transform.position.y > 50) Destroy(this);
		if (moveSpeed > 0)
		{
			 rb.AddForce(movement);
		}
		
		base.FixedUpdate();
	}

}
