using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controls : MonoBehaviour 
{

	bool Dragging;
	GameObject Dragged;
	Vector3 screenPoint;
	Vector3 offset;
	List<GameObject> ListOfCitizen = new List<GameObject>();
	int NumberOfInfected;
	// Use this for initialization
	void Start () 
	{
		Dragging = false;
	}

	
	// Update is called once per frame
	void Update () 
	{
		if(!Dragging)
		{
			if(Input.GetMouseButtonDown(0))
			{
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray,out hit))
				{
					if(hit.transform.gameObject.tag == "Citizen" && hit.transform.gameObject.GetComponent<CitizenBehaviour>().IfOverGantry())
					{
					Dragging = true;
					Dragged = hit.transform.gameObject;
					screenPoint = Camera.main.WorldToScreenPoint(Dragged.transform.position);
					offset = Dragged.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
					
					Dragged.GetComponent<CitizenBehaviour>().SetDragged(true);
					}
				}
			}
		}
		else
		{
			if(Input.GetMouseButtonUp(0))
			{
				Dragging = false;
				Dragged.GetComponent<CitizenBehaviour>().SetDragged(false);
				
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray,out hit))
				{
					if(hit.transform.gameObject.name == "GZ")
					{
						Destroy(Dragged);
//						if(Dragged.GetComponent<CitizenBehaviour>().IfInfected())
//							DestroyInfected();
					}
				}
				Dragged = null;
			}
			
			if(Dragging)
			{
				Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
				Dragged.transform.position = curPosition;
			}
		}
		
		if(Input.GetButton("LockG1"))
		{
			GameObject target =  GameObject.Find("Gantry1");
			target.transform.gameObject.GetComponent<Gantry>().Activation(false);
		}
		else
		{
			GameObject target =  GameObject.Find("Gantry1");
			target.transform.gameObject.GetComponent<Gantry>().Activation(true);
		}
		
		if(Input.GetButton("LockG2"))
		{
			GameObject target =  GameObject.Find("Gantry2");
			target.transform.gameObject.GetComponent<Gantry>().Activation(false);
		}
		else
		{
			GameObject target =  GameObject.Find("Gantry2");
			target.transform.gameObject.GetComponent<Gantry>().Activation(true);
		}
		
		if(Input.GetButton("LockG3"))
		{
			GameObject target =  GameObject.Find("Gantry3");
			target.transform.gameObject.GetComponent<Gantry>().Activation(false);
		}
		else
		{
			GameObject target =  GameObject.Find("Gantry3");
			target.transform.gameObject.GetComponent<Gantry>().Activation(true);
		}
		
		if(Input.GetButtonDown("LockG1") || Input.GetButtonDown("LockG2") || Input.GetButtonDown("LockG3") || Input.GetButtonUp("LockG1") || Input.GetButtonUp("LockG2") || Input.GetButtonUp("LockG3"))
		{
		
		}
		
		GameObject.Find("NoOfInfected").GetComponent<Text>().text = NumberOfInfected + " Infected Left";
	}
	
	public void StartUpList(List<GameObject> NewList)
	{
		ListOfCitizen = NewList;
	}
	
	public void SetNoInfected(int NoIn)
	{
		NumberOfInfected = NoIn;
	}
	
	public void DestroyInfected()
	{
		--NumberOfInfected;
	}
	
	void RearrangeCitizen()
	{
	
	
	}
}
