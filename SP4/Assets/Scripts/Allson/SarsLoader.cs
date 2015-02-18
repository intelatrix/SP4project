using UnityEngine;
using System.Collections;

public class SarsLoader : MonoBehaviour {

	public GameObject TypeCitizen;
	// Use this for initialization
	void Start () 
	{
		int NumberOfInfected = 3;
		for(int i = 0; i < 10; i ++)
		{
			GameObject ChildCitizen;
			ChildCitizen = Instantiate(TypeCitizen, new Vector3(Random.Range(-30f, 30f),0,Random.Range(-28f, -4f)), Quaternion.identity) as GameObject;
			if(NumberOfInfected > 0)
			{
				--NumberOfInfected;
				ChildCitizen.GetComponent<CitizenBehaviour>().SetInfected(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
