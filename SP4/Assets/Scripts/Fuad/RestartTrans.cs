using UnityEngine;
using System.Collections;

public class RestartTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!audio.isPlaying) 
			
			LevelLoader.WinLevel();

	
	}
}
