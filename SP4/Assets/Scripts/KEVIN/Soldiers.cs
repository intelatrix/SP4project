﻿using UnityEngine;
using System.Collections;

public class Soldiers : MonoBehaviour {
	public float x = -15.2f;
	public string strtoenter;
	public int random;
	public GameObject soldiers;
	public GameObject soldierfire;
	public bool stop;
	public bool check;
	public callchar swag;
	// Use this for initialization
	void Start () {
		stop = false;
		swag = FindObjectOfType<callchar> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//print (random);

		if (random == 5) 
		{
			if (stop == false) 
			{
				if (x < 13.5f)
				{
					x += 0.05f;
					check = true;
				}
			}
		} 
		else
		{
			random = Random.Range (1, 200);	
			check=false;
		}
		if (Input.GetKeyDown ("space")) {
			stop = true;
			x -= 1.5f;
			if(check==true)
			{
			stop = false;
			random = 0;
			}
			else 
			{
				swag.TimeCountDown -= 2;
				stop = false;
				random = 0;
			}
		}


		 
		if (x >= 13.5)
		{
			GameObject.Destroy (GameObject.Find ("soldiers(Clone)"));

			Instantiate (soldierfire, new Vector3 (13.9f, -9.9f, 0), Quaternion.identity).name = "soldierfire";
			//LevelLoader.LoseLevel();
		}
		transform.position = new Vector3 (x, -9.9f, 0);
	}
}
