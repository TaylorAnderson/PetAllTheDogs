﻿// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{	
	void Start()
	{
		LockCursor(true);
	}

    void Update()
    {
    	// lock when mouse is clicked
    	if( Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f )
    	{
    		LockCursor(true);
    	}
    
    	// unlock when escape is hit
        if  ( Input.GetKeyDown(KeyCode.Escape) )
        {
        	LockCursor(!(Cursor.lockState == CursorLockMode.Locked));
        }
    }
    
    public void LockCursor(bool lockCursor)
    {
		CursorLockMode mode;
		if (lockCursor) mode = CursorLockMode.Locked;
		else mode = CursorLockMode.None;
		Cursor.lockState = mode;
    }
}