using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogController : DogBase {
	// Update is called once per frame
	public GameObject leftWing;
	public GameObject rightWing;
	public void Start()
	{
		base.Start();
		InvokeRepeating("Wander", 0.0f, moveInterval);
	}
	protected void FixedUpdate() {
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
			print(movement);
			rb.AddForce(movement);
			transform.right = movement;
		}
		base.FixedUpdate();
	}
	void Wander()
	{
		while (Physics.Raycast(transform.position, movement, 1.0f)) 
		{
			movement = Random.insideUnitSphere * Random.Range(moveSpeed-5, moveSpeed + 5);
			if (!isAngel) movement.y = 0;
			else movement.y += 5;
		}





	}

}
