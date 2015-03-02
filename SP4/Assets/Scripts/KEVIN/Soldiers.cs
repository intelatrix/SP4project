using UnityEngine;
using System.Collections;

public class Soldiers : MonoBehaviour {
	public float x = -15.2f;
	public string strtoenter;
	public int random;
	public GameObject soldiers;
	public GameObject soldierfire;
	public GameObject soldieridle;
	public int randomer;
	public bool stop;
	public bool check;
	public callchar swag;
	public int firingtime;

	// Use this for initialization
	void Start () {
		stop = false;
		swag = FindObjectOfType<callchar> ();

		if (LevelLoader.GetRound () == 1)
		{	
			random = Random.Range (1, 100);	
		}
		if (LevelLoader.GetRound () == 2) 
		{
			random = Random.Range (1, 80);	
		} 
		else if (LevelLoader.GetRound () >= 3) 
		{
			random = Random.Range (1, 30);	
		}

	}
	
	// Update is called once per frame
	void Update () 
	{

			if (x == -15.2f) {
				random = 5;
			}

			//print (random);
	
			if (random == 5) {
				if (stop == false) {
					if (x < 13.5f) {
						x += 0.15f;
						check = true;
					}
				}
			} else {
			random = Random.Range (1, 100);	
				check = false;
			}
			if (Input.GetKeyDown ("space")) {
				stop = true;
				x -= 1.5f;
				if (check == true) {
					stop = false;
					random = 0;
					//Instantiate (soldieridle, new Vector3 (-15.2f, 9.9f, 0), Quaternion.identity);
				} else {
					swag.TimeCountDown -= 2;
					stop = false;
					random = 0;
				}
			}

		if (swag.TimeCountDown <= 0)
		{
			swag.TimeCountDown=0;
		}
		 
		if (x >= 13.5)
		{
			GameObject.Destroy (GameObject.Find ("soldiers(Clone)"));
			Instantiate (soldierfire, new Vector3 (13.9f, -9.9f, 0), Quaternion.identity).name = "soldierfire";
		
		}
		transform.position = new Vector3 (x, -9.9f, 0);
	}
}
