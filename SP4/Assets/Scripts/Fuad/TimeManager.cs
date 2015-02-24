using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	float time = 10f;

	// Use this for initialization
	void Start () {
	
		GameObject.Find ("Time").GetComponent<Text> ().text = "Time Left: " + time.ToString("n2");

	}
	
	// Update is called once per frame
	void Update () {

		time = Mathf.MoveTowards (time, 0, Time.deltaTime);		
		GameObject.Find ("Time").GetComponent<Text> ().text = "Time Left: " + time.ToString("n2");


		if (time <= 0 && EnemyManager.TCheck != 0) {
			Application.LoadLevel ("FPS_LoseScene");
		} else if (EnemyManager.TCheck <= 0) {
			Application.LoadLevel ("FPS_WinScene");
		}
	
	}
}
