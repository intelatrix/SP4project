using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour 
{

	bool Dragging;
	GameObject Dragged;
	Vector3 screenPoint;
	Vector3 offset;
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
					if(hit.transform.gameObject.tag == "Citizen")
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
	}
}
