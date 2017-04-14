using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour {
	public Image bar;
	public SpaceDrifter drifter;
	// Use this for initialization
	void Start () {
		bar.type = Image.Type.Filled;
		bar.fillMethod = Image.FillMethod.Horizontal;
	}
	
	// Update is called once per frame
	void Update () {
		bar.fillAmount = Helper.map(drifter.oxygen, 0, 30, 0, 1);
	}
}
