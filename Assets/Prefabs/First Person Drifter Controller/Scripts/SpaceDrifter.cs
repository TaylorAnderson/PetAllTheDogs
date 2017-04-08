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
 
	// If true, diagonal speed (when strafing + moving forward or back) can't exceed normal move speed; otherwise it's about 1.4 times faster
	private bool limitDiagonalSpeed = true;
 
	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	public Camera camera;
	private CharacterController controller;
	private Transform myTransform;
	private float speed;
	private RaycastHit hit;
	private float rayDistance;
	private Vector3 contactPoint;
	private bool playerControl = false;

	[HideInInspector]
	public float oxygen = 30;
 
	void Start()
	{
		controller = GetComponent<CharacterController>();
		speed = walkSpeed;
		rayDistance = controller.height * .5f + controller.radius;
	}
 
	void FixedUpdate() {
		oxygen -= Time.deltaTime;
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		// If both horizontal and vertical are used simultaneously, limit speed (if allowed), so the total doesn't exceed normal move speed
		float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed)? .7071f : 1.0f;
		bool sliding = false;

		if (enableRunning)
		{
			speed = Input.GetButton("Run") ? runSpeed : walkSpeed;
		}
		else speed = walkSpeed;

		moveDirection = (camera.transform.forward.normalized * inputY * speed) + (camera.transform.right * inputX * speed);
		//moveDirection = camera.transform.TransformDirection(moveDirection) * speed;
		playerControl = true;

		controller.Move(moveDirection * Time.deltaTime);
	}
 
	// Store point that we're in contact with for use in FixedUpdate if needed
	void OnControllerColliderHit (ControllerColliderHit hit) {
		contactPoint = hit.point;
	}
 
	// If falling damage occured, this is the place to do something about it. You can make the player
	// have hitpoints and remove some of them based on the distance fallen, add sound effects, etc.
	void FallingDamageAlert (float fallDistance)
	{
		//print ("Ouch! Fell " + fallDistance + " units!");   
	}
}