using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public ArmBase arm;
	private Text textCount;
	[HideInInspector]
	public int totalDogs;
	[HideInInspector]
	public int dogsPetted;
	public DogManager dogs;
	// Use this for initialization
	void Start () {
		textCount = GetComponent<Text>();
		totalDogs = dogs.transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
		dogsPetted = arm.score;
		textCount.text = arm.score.ToString() + " / " + totalDogs.ToString();
	}
}
