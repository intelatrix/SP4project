﻿using UnityEngine;
using System.Collections;

public class HospitalIntroTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying) 
		{
			Application.LoadLevel("Hospital_Tutorial");
		}
	}
}
