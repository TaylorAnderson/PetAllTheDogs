using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogController : DogBase {
	// Update is called once per frame
	public GameObject leftWing;
	public GameObject rightWing;
	Vector3 transformRotation = new Vector3();
	public bool isDebug = false;
	public void Start()
	{
		base.Start();
		StartCoroutine("DoWander");

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

		
		if (rb.velocity.magnitude > 1)
		{
			transformRotation.x = rb.velocity.x;
			transformRotation.z = rb.velocity.z;
		}
		transformRotation.y = 0;

		transform.right = transformRotation;
		
		
		base.FixedUpdate();

		
	}
	void Wander()
	{
		if (isDebug) print("running");
		movement = Random.insideUnitSphere * Random.Range(80, 200);
		if (!isAngel) movement.y = 0;
		else movement.y += 5;
		if (moveSpeed > 0)
		{
			rb.AddForce(movement);
		}
		
	}
	IEnumerator DoWander()
	{
		while(true)
		{

			Wander();
			yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
		}
		
	}

}
