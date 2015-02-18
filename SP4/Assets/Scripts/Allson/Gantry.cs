using UnityEngine;
using System.Collections;

public class Gantry : MonoBehaviour {

	Vector3 CenterPosition;
	bool InfectedDetected;
	// Use this for initialization
	void Start () 
	{
		InfectedDetected = false;
//		foreach (Transform child in this.transform) 
//		{
//			if(child.name == "ListOfPages")
//			{
//			}
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(InfectedDetected)
		{
			foreach (Transform child in this.transform) 
			{
				child.renderer.material.color = Color.red;
			}
		}
		else 
		{
			foreach (Transform child in this.transform) 
			{
				child.renderer.material.color = Color.white;
			}
		}
		InfectedDetected = false;
	}
	
	Vector3 GetCenterPoint()
	{
	
		return transform.position;
	}
	
	public void FoundInfected()
	{
		InfectedDetected = true;
	}
}
