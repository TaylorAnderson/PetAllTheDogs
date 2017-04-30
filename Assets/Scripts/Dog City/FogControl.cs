using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogControl : MonoBehaviour {
	void Update() {
		//getting player y
		RenderSettings.fogDensity = map(transform.position.y, 40, 0.8f, 0, 0.05f);
		
	}
	float map(float x, float fromMin, float fromMax, float toMin, float toMax)
	{
		return toMin + ((x - fromMin) / (fromMax - fromMin)) * (toMax - toMin);
	}
}
