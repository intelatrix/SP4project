using UnityEngine;
using System.Collections;

public class ReturnToMain : MonoBehaviour {

	// Use this for initialization
	public GameObject PauseGame; 
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				PauseGame.SetActive(false);
			}
			else 
			{
				Time.timeScale = 0;
				PauseGame.SetActive(true);
			}
		}
	}
	
	public void ResumePressed()
	{
		Time.timeScale = 1;
		PauseGame.SetActive(false);
	}
	
	public void MainMenuPressed()
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}
	
	public void QuitPressed()
	{
		Application.Quit();
	}
}
