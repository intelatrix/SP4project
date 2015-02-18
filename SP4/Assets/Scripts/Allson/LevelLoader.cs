using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour 
{
	private enum Games
	{
		
		GAME_TOTAL
	} ;
	

	static int Lives;
	static int Level;
	static int Round;
	static Games[] ListOfGames = new Games[(int)Games.GAME_TOTAL];

	static void WinLevel()
	{
		NextLevel();
	}

	static void LoseLevel()
	{
		--Lives;
		if(Lives == 0)
		{
			
		}
		else
		{
			NextLevel();
		}
	}
	
	static void NewGame()
	{
		Lives = 3;
		Round = 1;
		Level = 0;
	}
	
	static void RandomLinkedList()
	{
		ReShuffleList();
	}
	
	public static void ReShuffleList()  
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
	
	static void NextLevel()
	{
		++Level;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
