using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ArmController : ArmBase {
	public float rotationOffset = 0.0f;
	FPBase player;
	CharacterController playerChar;
	float stamina = 100;
	Vector3 initPos;
	Vector3 impact;

	float mass = 3.0F;

	public Image redFlash;
	void Start () {
		DOTween.Init();
		player = transform.parent.parent.GetComponent<FPBase>();
		initPos = player.transform.position;

		playerChar = player.GetComponent<CharacterController>();
	 }
	 // Update is called once per frame
	 void FixedUpdate ()
	 {
		// apply the impact force:
		if (impact.magnitude > 0.2F) playerChar.Move(impact * Time.deltaTime);
		// consumes the impact energy each cycle:
		impact = Vector3.Lerp(impact, Vector3.zero, 1 * Time.deltaTime);
		if (Input.GetButtonDown("Reset"))
		{
			player.transform.position = initPos;
		}
		if (Input.GetMouseButtonDown(0))
		{
			transform.Rotate(new Vector3(-rotationOffset, 0, 0));
			transform.Rotate(new Vector3(15, 0, 0));
			rotationOffset = 15;
		}
		if (Input.GetMouseButton(1))
		{
			stamina -= Time.deltaTime;
		}
		stamina = Mathf.Clamp(stamina, 0, 5);
		player.enableRunning = stamina > 0;
		if (rotationOffset > 0)
		{
			transform.Rotate(new Vector3(-1, 0, 0));
			rotationOffset -= 1;
		}
		  
	 }
	void OnParticleCollision(GameObject other)
	{
		AddImpact(new Vector3(0, 1, 0), 30);
	}
	// call this function to add an impact force:
	public void AddImpact(Vector3 dir, float force)
	{
		dir.Normalize();
		if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
		impact += dir.normalized * force / mass;
	}
	void OnTriggerEnter(Collider e)
	{
		if (e.CompareTag("Car"))
		{
			redFlash.gameObject.SetActive(true);
			redFlash.CrossFadeAlpha(1.0f, 0.0f, true);
			redFlash.CrossFadeAlpha(0.0f, 0.3f, true);
			player.transform.position = initPos;
			player.lockControls(0.5f);
		}

	}
}
