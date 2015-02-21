using UnityEngine;
using System.Collections;

public class CitizenBehaviour : MonoBehaviour {

	bool ThisDragged;
	bool PassGantry;
	bool Infected= false;
	bool DeathType = false;
	int TargetGantry;	
	Vector3 Direction;

	void Start () {
		ThisDragged = false;
		PassGantry = false;
		TargetGantry = Random.Range(1,4);
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject target =  GameObject.Find("Gantry" + TargetGantry);
		if(!ThisDragged)
		{
			transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
			if(!PassGantry)
			{
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x , 1.5f , target.transform.position.z) , Time.deltaTime*5);
				
				if(transform.position.z >= target.transform.position.z)
				{
					PassGantry = true;
					Direction = new Vector3(Random.Range(-1f,2f),0,Random.Range(0.5f,1f)).normalized;
				}
			}
			else
			{
				transform.position += Time.deltaTime*Direction*10;
			}
		}
		if(Vector3.Distance(new Vector3(transform.position.x, 1.5f, transform.position.z), new Vector3(target.transform.position.x , 1.5f , target.transform.position.z)) <= 1) 
		{
			if(Infected)
				target.GetComponent<Gantry>().FoundInfected();

		}
	}
		
	public void SetDragged(bool SDragged)
	{
		this.ThisDragged = SDragged;
	}
	
	public void SetInfected(bool IfInfected)
	{
		Infected = IfInfected;
	}

	public void SetDeath(bool Death)
	{
		DeathType = Death;
	}
	
	
	public bool IfInfected()
	{
		return Infected;
	}
	
	void OnBecameInvisible() 
	{
		GameObject Controls = GameObject.Find("Controls");
		if(Controls != null && Infected && !ThisDragged && !DeathType)
		{
			Controls.GetComponent<Controls>().MinusOneLife();
		}
		Destroy(gameObject);
	}
	
	public bool IfOverGantry()
	{
		return PassGantry;
	}
	
	void OnDestroy()
	{
		GameObject Controls = GameObject.Find("Controls");
		if(Controls != null  && Infected )
		{
			Controls.GetComponent<Controls>().DestroyInfected();
		}
	}
}
