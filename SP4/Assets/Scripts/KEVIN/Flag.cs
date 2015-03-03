using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
	
	public float flagpos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			


		if (Input.GetKeyDown ("u")) 
		{
			if(GameObject.Find ("character(Clone)")||GameObject.Find ("character2(Clone)"))
			{
				flagpos+=26f* Time.deltaTime;

			if (flagpos < 5.9f)
			{
					transform.position = new Vector3 (23.8f, flagpos, 0);
			}
			if (flagpos >= 5.9f)
			{
					flagpos = 5.9f;
					transform.position = new Vector3 (23.8f, flagpos, 0);
					LevelLoader.WinLevel();
			}
			}
		}
		else if(Input.GetKeyDown ("p"))
		{
			if(GameObject.Find ("character1(Clone)")||GameObject.Find ("character3(Clone)"))
			{
				flagpos+=26f* Time.deltaTime;
			if (flagpos < 5.9f)
			{
					transform.position = new Vector3 (23.8f, flagpos, 0);
			}
			if (flagpos >= 5.9f)
			{
					flagpos = 5.9f;
					transform.position = new Vector3 (23.8f, flagpos, 0);
					LevelLoader.WinLevel();
			}
			}
		}
		if (flagpos <= 5.9f)
		{
			flagpos-=2* Time.deltaTime;
			transform.position = new Vector3 (23.8f, flagpos, 0);
		
		}
		if (flagpos <= -12.1f)
		{
			//Debug.Log ("lol");
			flagpos=-12.1f;
			transform.position = new Vector3 (23.8f, flagpos, 0);

		
		}
	}
	
}
