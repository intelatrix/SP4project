using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour 
{
	private enum Games
	{
		GAME_SARSGANTRY,
		GAME_FUAD,
		GAME_TOTAL
	} ;
	

	static int Lives;
	static int Level;
	static int Round;
	static Games[] ListOfGames = new Games[(int)Games.GAME_TOTAL];

	static public void WinLevel()
	{
		NextLevel();
	}

	//Wei Kun was here
	static public void SetRound(int newNum) {
		Round = newNum;
	}

	static public void LoseLevel()
	{
		--Lives;
		if(Lives == 0)
		{
			//Lose Game - Load Lose Level
			
		}
		else
		{
			NextLevel();
		}
	}
	
	static public void NewGame()
	{
		Lives = 3;
		Round = 1;
		Level = -1;
		for( int i = 0; i < (int)Games.GAME_TOTAL; i++)
		{
			ListOfGames[i] = (Games)i;
		}
		RandomLinkedList();
		//Screen Round 
		Application.LoadLevel("NewRound");
	}
	
	static void RandomLinkedList()
	{
		ReShuffleList();
	}
	
	static void ReShuffleList()  
	{  
		System.Random rng = new System.Random();  
		int n = (int)Games.GAME_TOTAL;  
		while (n > 1) 
		{  
			n--;  
			int k = rng.Next(n + 1);  
			Games value = ListOfGames[k];  
			ListOfGames[k] = ListOfGames[n];  
			ListOfGames[n] = value;  
		}  
	}
	
	static public void NextLevel()
	{
		++Level;
		if(Level == (int)Games.GAME_TOTAL)
		{
			++Round; 
			Level = -1;
			//New Round Screen
			Application.LoadLevel("NewRound");
			return;
		}
		switch(ListOfGames[Level])
		{	
		case Games.GAME_SARSGANTRY:
			Application.LoadLevel("Sars");
			break;
		case Games.GAME_FUAD:
			Application.LoadLevel("FPS");
			break;
		default:
			break;
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	static public int GetRound()
	{
		return Round;
	}
}
