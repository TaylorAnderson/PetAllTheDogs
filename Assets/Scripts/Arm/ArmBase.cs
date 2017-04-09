using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmBase : MonoBehaviour {
	[HideInInspector]
	public int score;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction);
			if (Physics.Raycast(ray, out hit))
			{
				GameObject go = hit.collider.gameObject;
				if (go.GetComponentInParent<Pettable>() != null)
				{
					Pettable pettable = go.GetComponentInParent<Pettable>();
					pettable.OnPet();
				}
			}
		}
	}
	void OnTriggerEnter(Collider e)
	{

	}

}
