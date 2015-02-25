using UnityEngine;
using System.Collections;

public class CitizenBehaviour : MonoBehaviour {

	bool ThisDragged;
	bool PassGantry;
	bool Infected= false;
	bool DeathType = false;
	int TargetGantry;	
	Vector3 Direction;
	bool ActiveOr = false;

	void Start () {
		ThisDragged = false;
		PassGantry = false;
		TargetGantry = Random.Range(1,4);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ActiveOr)
		{
			GameObject target =  GameObject.Find("Gantry" + TargetGantry);
			if(!ThisDragged)
			{
				transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
				if(!PassGantry)
				{
					transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x , 1.5f , target.transform.position.z) , Time.deltaTime*(5+ LevelLoader.GetRound()));
					
					if(transform.position.z >= target.transform.position.z)
					{
						PassGantry = true;
						Direction = new Vector3(Random.Range(-1f,2f),0,Random.Range(0.5f,1f)).normalized;
					}
				}
				else
				{
					transform.position += Time.deltaTime*Direction*(10+ LevelLoader.GetRound());
				}
				
				if(transform.position.z > 19 || (transform.position.z > 0 && (transform.position.x > 35) || (transform.position.x < -35)))
				{
					//Play Wrong Sound
					GameObject Controls = GameObject.Find("Controls");
					if(Controls != null && Infected && !ThisDragged && !DeathType)
					{
						Controls.GetComponent<Controls>().MinusOneLife();
					}
					Destroy(gameObject);
				}
				
			}
			if(Vector3.Distance(new Vector3(transform.position.x, 1.5f, transform.position.z), new Vector3(target.transform.position.x , 1.5f , target.transform.position.z)) <= 1) 
			{
				if(Infected)
				{
					//if(target.GetComponent<Gantry>().PlayBuzzerSound())
						//Uncomment and play gantry buzzer sound
					target.GetComponent<Gantry>().FoundInfected();
				}
	
			}
		}
	}
		
	public void SetDragged(bool SDragged)
	{
		this.ThisDragged = SDragged;
	}
	
	public void SetInfected(bool IfInfected)
	{
		Infected = IfInfected;
		if(Infected)
		{
			foreach (Transform child in this.transform) 
			{
				child.renderer.material.color = Color.red;
			}
		}
	}

	public void SetDeath(bool Death)
	{
		DeathType = Death;
	}
	
	
	public bool IfInfected()
	{
		return Infected;
	}
	
	public bool IfOverGantry()
	{
		return PassGantry;
	}
	
	public void StartCitizen(bool Startup)
	{
		ActiveOr = Startup;
		if(Startup)
		{
			foreach (Transform child in this.transform) 
			{
				child.renderer.material.color = Color.white;
			}
		}
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
