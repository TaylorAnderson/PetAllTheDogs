using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour {
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public void PlayGame()
	{
		SceneManager.LoadScene("level1");
	}

	public void OnEnter()
	{
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	public void OnExit()
	{
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}
}
