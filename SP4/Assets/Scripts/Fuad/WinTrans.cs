﻿using UnityEngine;
using System.Collections;

public class WinTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Screen.showCursor = true;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!audio.isPlaying) 
			
			LevelLoader.WinLevel();

	
	}
}