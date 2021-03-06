﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject Wind;
	private float SpawnInterval = 0;
	private float IntervalCounter = 0;
	
	List<string> ListOfRandomness = new List<string> { 
	"LEO",
	"WIN",
	"YOG",
	"CUBA",
	"FUAD",
	"BALL",
	"WIND",
	"LOSE",
	"GOLD",
	"FIRE",
	"SG50",
	"MERLY", 
	"TORCH",
	"YOUTH",
	"KEVIN",
	"BRIAN",
	"CHINA",
	"JAPAN",
	"ITALY",
	"RUSSIA",
	"SPORTS",
	"FRANCE",
	"BRONZE",
	"SILVER",
	"ALLSON",
	"WEIKUN",
	"REFEREE",	
	"NANYANG",
	"MERLION",
	"UKRAINE",
	"ARCHERY",
	"HUNGARY",
	"CYCLING",
	"FENCING",
	"FOOTBALL",
	"OLYMPICS",
	"AUSTRALIA",
	"TAEKWONDO",
	"BADMINTON",
	"WRESTLING",
	"SINGAPORE",
	"SOUTHKOREA",
	"VOLLEYBALL",
	"BASKETBALL",
	"LEEKUANYEW",
	"POLYTECHNICS",
	"WEIGHTLIFTING",
	}; 
	bool StartUp = false;
	
	void Start () 
	{
		NewInterval();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!StartUp)
		{
		
		}
		else
		{
			IntervalCounter += Time.deltaTime;
			if(IntervalCounter >= SpawnInterval && Vector3.Distance(GameObject.Find("RunningMan").transform.position, GameObject.Find("Flag").transform.position- new Vector3(7,0,0)) > 20.59f)
			{
				IntervalCounter = 0;
				NewInterval();
				Vector3 RunningManPosition = GameObject.Find("RunningMan").transform.position;
				GameObject NewWind= Instantiate(Wind, RunningManPosition + new Vector3(15,Random.Range(0,5)*2,0), Quaternion.identity) as GameObject;
				NewWind.GetComponent<Wind>().SetCurrentWord(RandomWord());
				NewWind.GetComponent<Wind>().SetSpeed(Random.Range(0.7f, 1f)+ (LevelLoader.GetRound()-1)*0.5f);
			}
		}
	
	}
	
	public void StartSpawning()
	{
		StartUp = true;
	}
	
	void NewInterval()
	{
		SpawnInterval = Random.Range(1.5f,3f) - (LevelLoader.GetRound()-1)*0.5f;
	}
	
	string RandomWord()
	{
		return ListOfRandomness[Random.Range(0, ListOfRandomness.Count)];
	}
}
