using UnityEngine;
using System.Collections;

public class WindSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject Wind;
	private float SpawnInterval = 0;
	private float IntervalCounter = 0;
	bool StartUp = false;
	
	void Start () 
	{
		NewInterval();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!StartUp)
		{
		
		}
		else
		{
			IntervalCounter += Time.deltaTime;
			if(IntervalCounter >= SpawnInterval)
			{
				IntervalCounter = 0;
				NewInterval();
				Vector3 RunningManPosition = GameObject.Find("RunningMan").transform.position;
				Instantiate(Wind, RunningManPosition, Quaternion.identity);
			}
		}
	
	}
	
	public void StartSpawning()
	{
		StartUp = true;
	}
	
	void NewInterval()
	{
		SpawnInterval = Random.Range(0f,4f);
	}
}
