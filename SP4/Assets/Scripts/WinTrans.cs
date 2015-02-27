using UnityEngine;
using System.Collections;

public class WinTrans : MonoBehaviour {

	// Use this for initialization
	public GameObject Merlion;
	private float TimeCount = 0;
	void Start () {
	
		Screen.showCursor = true;
		for(int i = 0; i < LevelLoader.GetLives(); i++)
		{
			Instantiate(Merlion, new Vector3(i*4 - 4,1,0), Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
		TimeCount += Time.deltaTime;
		if (!audio.isPlaying && TimeCount >= 5) 
			LevelLoader.NextLevel();

	
	}
}
