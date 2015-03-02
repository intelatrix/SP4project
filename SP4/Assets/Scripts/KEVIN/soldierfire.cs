using UnityEngine;
using System.Collections;

public class soldierfire : MonoBehaviour {
	public float TimeCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TimeCount += Time.deltaTime;
		if(TimeCount >= 1) 
		{
			LevelLoader.LoseLevel();
		}
	}
}

	