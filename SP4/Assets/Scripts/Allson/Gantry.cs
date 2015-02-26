using UnityEngine;
using System.Collections;

public class Gantry : MonoBehaviour {

	Vector3 CenterPosition;
	bool InfectedDetected;
	bool Activated = true;
	bool PlayBuzzer = true;

	// Use this for initialization
	void Start () 
	{
		InfectedDetected = false;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(!Activated)
		{
			foreach (Transform child in this.transform) 
			{
				child.renderer.material.color = Color.white;
				child.renderer.material.shader = Shader.Find("Outlined/Diffuse");
			}
		}
		else if(InfectedDetected)
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
				child.renderer.material.shader = Shader.Find("Diffuse");
			}
		}
		if(!InfectedDetected)
			PlayBuzzer = true;
		InfectedDetected = false;
	}
	
	Vector3 GetCenterPoint()
	{
	
		return transform.position;
	}
	
	public void FoundInfected()
	{
		if(Activated)
			InfectedDetected = true;
	}
	
	public void Activation(bool Active)
	{
		Activated = Active;
		transform.Find("GantryDoor").gameObject.SetActive(!Activated);
	}
	
	public bool IfActive()
	{
		return Activated;
	}
	
	public bool PlayBuzzerSound()
	{

		return PlayBuzzer ;
	}
}
