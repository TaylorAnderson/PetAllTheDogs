// original by Eric Haines (Eric5h5)
// adapted by @torahhorse
// http://wiki.unity3d.com/index.php/FPSWalkerEnhanced

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class SpaceDrifter : FPBase
{
	public float walkSpeed = 6.0f;
	public float runSpeed = 10.0f;
 
 
	private Vector3 moveDirection = Vector3.zero;
	public Camera camera;
	private CharacterController controller;
	private Transform myTransform;
	private float speed;
	private RaycastHit hit;

	[HideInInspector]
	public float oxygen = 30;
 
	void Start()
	{
		controller = GetComponent<CharacterController>();
		speed = walkSpeed;
	}
 
	void FixedUpdate() {
		oxygen -= Time.deltaTime;
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		if (enableRunning)
		{
			speed = Input.GetButton("Run") ? runSpeed : walkSpeed;
		}
		else speed = walkSpeed;

		moveDirection = (camera.transform.forward.normalized * inputY * speed) + (camera.transform.right * inputX * speed);
		//moveDirection = camera.transform.TransformDirection(moveDirection) * speed;

		controller.Move(moveDirection * Time.deltaTime);
	}
 
	// If falling damage occured, this is the place to do something about it. You can make the player
	// have hitpoints and remove some of them based on the distance fallen, add sound effects, etc.
	void FallingDamageAlert (float fallDistance)
	{
		//print ("Ouch! Fell " + fallDistance + " units!");   
	}
}