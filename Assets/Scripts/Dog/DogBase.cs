using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogBase : Pettable
{

	protected float counter = 0f;
	public float moveInterval = 100;
	public float moveSpeed = 1;
	protected Rigidbody rb;
	protected Vector3 movement;
	protected GameObject tail;


	protected bool waggingTail = false;
	[HideInInspector]
	protected Canvas testCanvas;
	protected bool isAngel = false;
	protected float startY;
	protected void Start()
	{
		base.Start();
		rb = GetComponent<Rigidbody>();
		counter = moveInterval;
		foreach (Transform child in transform)
		{
			if (child.gameObject.CompareTag("Tail")) tail = child.gameObject;
		}
		startY = transform.position.y;
	}

	// Update is called once per frame
	protected void FixedUpdate()
	{
		
	}

	override public void OnPet(ArmBase arm)
	{
		if (!petted)
		{
			base.OnPet(arm);
			WagLeft();
			ArmBase controller = arm.GetComponent<ArmBase>();
			controller.score++;
		}
	}
	void WagLeft()
	{
		tail.transform.DOLocalRotate(new Vector3(50, 0, 0), 0.15f).OnComplete(WagRight);
	}
	void WagRight()
	{
		tail.transform.DOLocalRotate(new Vector3(-50, 0, 0), 0.15f).OnComplete(WagLeft);
	}
}
