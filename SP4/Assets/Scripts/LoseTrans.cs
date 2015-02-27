using UnityEngine;
using System.Collections;

public class LoseTrans : MonoBehaviour {
	// Use this for initialization
	public GameObject Merlion;
	private GameObject BurstingMerlion;
	public GameObject Burst;
	private float TimeCount = 0;
	void Start () {
		Screen.showCursor = true;
		for(int i = 0; i <  LevelLoader.GetLives()+1; i++)
		{
			if(i == LevelLoader.GetLives())
			{
				BurstingMerlion = Instantiate(Merlion, new Vector3(i*4 - 4,1,0), Quaternion.identity) as GameObject;
			}
			else
			{
				Instantiate(Merlion, new Vector3(i*4 - 4,1,0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		TimeCount += Time.deltaTime;
		if(TimeCount >= 1 && BurstingMerlion != null) 
		{
			Instantiate(Burst,BurstingMerlion.transform.position, Quaternion.identity);
			Destroy(BurstingMerlion);
		}
		if (!audio.isPlaying && TimeCount >= 2) 
		{	
			if(LevelLoader.GetLives() != 0)
				LevelLoader.NextLevel();
			else
				Application.LoadLevel("LoseGame");
		}
		
	}
}
