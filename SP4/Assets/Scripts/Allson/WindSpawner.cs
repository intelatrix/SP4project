using UnityEngine;
using System.Collections;

public class WindSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject Wind;
	bool StartUp = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!StartUp)
		{
		
		}
		else
		{
		
		}
	
	}
	
	public void StartSpawning()
	{
		StartUp = true;
	}
}
