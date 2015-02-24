using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SarsLoader : MonoBehaviour {

	public GameObject TypeCitizen;
	private float StartCount = 3;
	bool StartBool = false;
	
	// Use this for initialization
	void Start () 
	{
		List<GameObject> ListOfCitizen = new List<GameObject>();
		int NumberOfInfected = 3 + LevelLoader.GetRound()-1; 
		GameObject.Find("Controls").GetComponent<Controls>().SetNoInfected(NumberOfInfected);
		for(int i = 0; i < 10 + LevelLoader.GetRound()*2; i ++)
		{
			GameObject ChildCitizen;
			ChildCitizen = Instantiate(TypeCitizen, new Vector3(Random.Range(-30f, 30f),1.5f,Random.Range(-28f, -4f)), Quaternion.identity) as GameObject;
			if(NumberOfInfected > 0)
			{
				--NumberOfInfected;
				ChildCitizen.GetComponent<CitizenBehaviour>().SetInfected(true);
				ListOfCitizen.Add(ChildCitizen);
			}
		}
		GameObject.Find("Controls").GetComponent<Controls>().StartUpList(ListOfCitizen);
	}
	
	// Update is called once per frame
	void Update () {
		if(!StartBool)
		{
			StartCount -=  Time.deltaTime;
			GameObject.Find("StartCount").GetComponent<Text>().text = ((int)StartCount+1).ToString();
			if(StartCount <= 0)
			{
				StartBool = true;
				GameObject.Find("StartCount").SetActive(false);
				GameObject.Find("Controls").GetComponent<Controls>().DisableControls(true);
				foreach(GameObject Citizen in GameObject.FindGameObjectsWithTag("Citizen"))
				{
					Citizen.GetComponent<CitizenBehaviour>().StartCitizen(true);
				}
			}
		}
	}
}
