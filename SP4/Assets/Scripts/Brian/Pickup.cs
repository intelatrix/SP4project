using UnityEngine;
using System.Collections;

public class PeoplePickup : MonoBehaviour 
{
	#region PUBLIC VARIABLES
	
	public int peopleValue = 1;
	
	#endregion
	
	#region COLLIDER 2D COMPONENT METHODS [OnEnter]

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "Citizen")
		{
			//ControllerScript.CollectPeople(this.peopleValue);
			Destroy(this.gameObject);
		}
	}
	#endregion
}