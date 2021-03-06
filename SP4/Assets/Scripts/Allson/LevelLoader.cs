using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour 
{
	private enum Games
	{
		GAME_SARSGANTRY,
		GAME_FUAD,
		GAME_ULA,
		GAME_BURN,
		GAME_BIRDSHIT,
		GAME_HOSPITAL,
		GAME_YOG,
		GAME_TOTAL
	} ;
	

	static int Lives;
	static int Level;
	static int Round;
	static Games[] ListOfGames = new Games[(int)Games.GAME_TOTAL];

	static public void WinLevel()
	{
		Application.LoadLevel("WinLevel");
	}

	//Wei Kun was here
	static public void SetRound(int newNum) {
		Round = newNum;
	}

	static public void LoseLevel()
	{
		--Lives;
		Application.LoadLevel("LoseLevel");
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
		if(Round == 1)
		{
			switch(ListOfGames[Level])
			{	
			case Games.GAME_SARSGANTRY:
				Application.LoadLevel("Sars_Intro");
				break;
			case Games.GAME_FUAD:
				Application.LoadLevel("FPS_Intro");
				break;
			case Games.GAME_ULA:
				Application.LoadLevel("Sang_Intro");
				break;
			case Games.GAME_BURN:
				Application.LoadLevel("NWH_Intro");
				break;
			case Games.GAME_BIRDSHIT:
				Application.LoadLevel("raiseflagintro");
				break;
			case Games.GAME_HOSPITAL:
				Application.LoadLevel("Hospital_Intro");
				break;
			case Games.GAME_YOG:
				Application.LoadLevel("YOG_Intro");
				break;
			default:
				break;
			}
		}
		else if(Round >3)
		{
			Application.LoadLevel("WinGame");
		}
		else
		{
			switch(ListOfGames[Level])
			{	
			case Games.GAME_SARSGANTRY:
				Application.LoadLevel("Sars_Splash");
				break;
			case Games.GAME_FUAD:
				Application.LoadLevel("FPS_Splash");
				break;
			case Games.GAME_ULA:
				Application.LoadLevel("SinkingShip_Splash");
				break;
			case Games.GAME_BURN:
				Application.LoadLevel("BriSplash");
				break;
			case Games.GAME_BIRDSHIT:
				Application.LoadLevel("raiseflagsplash");
				break;
			case Games.GAME_HOSPITAL:
				Application.LoadLevel("Hospital_Splash");
				break;
			case Games.GAME_YOG:
				Application.LoadLevel("YOG_Splash");
				break;
			default:
				break;
			}
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
	
	static public int GetLives()
	{
		return Lives;
	}
}
