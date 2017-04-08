using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {
	public static float map(float x, float fromMin, float fromMax, float toMin, float toMax)
	{
		return toMin + ((x - fromMin) / (fromMax - fromMin)) * (toMax - toMin);
	}
}
