using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewRound : MonoBehaviour {

	// Use this for initialization
	int Round;
	float TimeLeft;
	void Start () 
	{
		Round = LevelLoader.GetRound();
		TimeLeft = 2;
		GameObject.Find("RoundNumber").GetComponent<Text>().text = "Round " + Round;
		//Render Round Number
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimeLeft -= Time.deltaTime;
		if(TimeLeft <= 0)
			LevelLoader.NextLevel();
	}
}
