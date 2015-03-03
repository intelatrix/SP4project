using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject LeeKuanYewTears;
	string Check = "LKYCRY";
	int LetterPosition = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!LeeKuanYewTears.activeSelf)
		{
			foreach (char c in Input.inputString) 
			{
				if (char.ToLower(c) == char.ToLower(Check[LetterPosition]))
				{
					LetterPosition++;
					if(LetterPosition == Check.Length)
					{
						LeeKuanYewTears.SetActive(true);
					}
				}
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
