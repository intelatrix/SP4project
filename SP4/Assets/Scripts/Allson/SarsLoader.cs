using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SarsLoader : MonoBehaviour {

	public GameObject TypeCitizen;
	
	// Use this for initialization
	void Start () 
	{
		List<GameObject> ListOfCitizen = new List<GameObject>();
		int NumberOfInfected = 3;
		GameObject.Find("Controls").GetComponent<Controls>().SetNoInfected(NumberOfInfected);
		for(int i = 0; i < 10; i ++)
		{
			GameObject ChildCitizen;
			ChildCitizen = Instantiate(TypeCitizen, new Vector3(Random.Range(-30f, 30f),0,Random.Range(-28f, -4f)), Quaternion.identity) as GameObject;
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
	
	}
}
