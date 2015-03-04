using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject LeeKuanYewTears;
	public GameObject LeftLaser, RightLaser;
	string Check1= "LKYCRY";
	int LetterPosition1 = 0;
	
	string Check2 = "LASERS";
	int LetterPosition2 = 0;
	float LaserTime1 = 0, LaserTime2 = 0;
	float LaserDirection1 = 0, LaserDirection2 = 0;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!LeeKuanYewTears.activeSelf)
		{
			foreach (char c in Input.inputString) 
			{
				if (char.ToLower(c) == char.ToLower(Check1[LetterPosition1]))
				{
					LetterPosition1++;
					if(LetterPosition1 == Check1.Length)
					{
						LeeKuanYewTears.SetActive(true);
					}
				}
			}
		}
		
		if(!(LeftLaser.activeSelf && RightLaser.activeSelf))
		{
			foreach (char c in Input.inputString) 
			{
				if (char.ToLower(c) == char.ToLower(Check2[LetterPosition2]))
				{
					LetterPosition1++;
					if(LetterPosition2 == Check2.Length)
					{
						LeftLaser.SetActive(true);
						RightLaser.SetActive(true);
					}
				}
			}
		}
		else 
		{
			LaserTime1 -= Time.deltaTime;
			LaserTime2 -= Time.deltaTime;
			if(LaserTime1<= 0)
			{
				LaserDirection1 = Random(-1f,1f);
			}
			
			if(LaserTime2<= 0)
			{
				LaserDirection2 = Random(-1f,1f);
			}
		}
	}
	
	public void StartPressed()
	{
		LevelLoader.NewGame();
	}
	
	public void QuitPressed()
	{
		Application.Quit();
	}
	
	public void StartHover()
	{
		
	}
	
	public void QuitHover()
	{
		
	}
}
