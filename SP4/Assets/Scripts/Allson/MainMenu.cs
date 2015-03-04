using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject LeeKuanYewTears;
	public GameObject LeftLaser, RightLaser;
	string Check1= "LKYCRY";
	int LetterPosition1 = 0;
	
	string Check2 = "420BLAZEIT";
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
					LetterPosition2++;
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
				LaserDirection1 = Random.Range(-1f,1f);
				LaserTime1 = Random.Range(2f,2.5f);
			}
			
			if(LaserTime2<= 0)
			{
				LaserDirection2 = Random.Range(-1f,1f);
				LaserTime2 = Random.Range(2f,2.5f);
			}
			LeftLaser.transform.Rotate(Vector3.right* LaserDirection1*Time.deltaTime*10);
			RightLaser.transform.Rotate(Vector3.right* LaserDirection2*Time.deltaTime*10);
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
