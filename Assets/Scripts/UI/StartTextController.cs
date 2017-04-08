using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartTextController : MonoBehaviour {

	public GameObject reticule;
	public GameObject bg;
	private string[] messages = new string[5];
	private Text text;
	public bool finished = false;
	// Use this for initialization
	void Start () {
		messages[0] = "PET DOGS IN...";
		messages[1] = "3";
		messages[2] = "2";
		messages[3] = "1";
		messages[4] = "GO";
		
		text = GetComponent<Text>();
		StartCoroutine("CountDown");
		Time.timeScale = 0;
		reticule.SetActive(false);
		DOTween.defaultTimeScaleIndependent = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator CountDown()
	{
		for (int i=0; i < messages.Length; i++)
		{
			text.text = messages[i];

			if (messages[i] != "GO")
			{
				text.transform.DOScale(2f, 0.3f);
				text.transform.DOScale(1f, 0.3f).SetDelay(0.3f);
				yield return new WaitForSecondsRealtime(0.6f);
			} 
			else 
			{
				text.transform.DOScale(120f, 0.5f).SetEase(Ease.InExpo);
				yield return new WaitForSecondsRealtime(0.5f);
			}
			
			if (i == messages.Length - 1)
			{
				Destroy(this.gameObject);
				finished = true;
				bg.SetActive(false);
				Time.timeScale = 1;
				reticule.SetActive(true);
			} 

		}
		
	}
}
