using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipController : MonoBehaviour {

	public GameObject arm;
	public SceneLoader loader;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown()
	{
		if (Vector3.Distance(transform.position, arm.transform.position) < 50)
		{
			
		}
	}


}
