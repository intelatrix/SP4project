using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	float time;
	private float StartCount;
	public static bool isStart = false;

	// Use this for initialization
	void Start () {

		time = 15f;

	int multiplier = LevelLoader.GetRound ();

		time = time / multiplier;

		StartCount = 3;
		isStart = false;
	
		GameObject.Find ("Time").GetComponent<Text> ().text = "Time Left: " + time.ToString("n2");

	}
	
	// Update is called once per frame
	void Update () {



		if(isStart){

		time = Mathf.MoveTowards (time, 0, Time.deltaTime);		
		GameObject.Find ("Time").GetComponent<Text> ().text = "Time Left: " + time.ToString("n2");



		if (time <= 0 && EnemyManager.TCheck != 0) {
				LevelLoader.LoseLevel();
		} else if (EnemyManager.TCheck <= 0) {
			LevelLoader.WinLevel();
		}
		}

		else if (!isStart) {
			
			GameObject.Find("Countdown").GetComponent<Text>().text = ((int)StartCount + 1).ToString();
			StartCount -=  Time.deltaTime;

			if(StartCount <= 0)
			{
				isStart = true;
				GameObject.Find("Countdown").SetActive(false);

				
			}
			
		}
	
	}
}
