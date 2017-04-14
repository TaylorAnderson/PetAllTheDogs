using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class ShipController : Pettable {

	bool beganLoadingNextScene = false;
	public SceneLoader loader;
	public ScoreController score;
	public GameObject leaveNoDogBehind;
	private Text leaveNoDogsText;
	// Use this for initialization
	void Start () {
		maxDistance = 15.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void OnPet(ArmBase arm)
	{
		if (!beganLoadingNextScene && score.dogsPetted == score.totalDogs) 
		{
			StartCoroutine(loader.LoadNewScene(SceneManager.GetActiveScene().buildIndex + 1));
			beganLoadingNextScene = true;
		}
		else
		{
			leaveNoDogsText = leaveNoDogBehind.GetComponent<Text>();
			leaveNoDogBehind.SetActive(true);
			leaveNoDogsText.CrossFadeAlpha(1.0f, 0.0f, true);
			
			leaveNoDogsText.CrossFadeAlpha(0, 0.5f, true);
		}
	}


}
