using UnityEngine;
using System.Collections;

public class Soldiers : MonoBehaviour {
	public float x = -15.2f;
	public string strtoenter;
	public int randomq;
	public GameObject soldiers;
	public GameObject soldierfire;
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
			randomer = Random.Range (1, 200);	
		}
		if (LevelLoader.GetRound () == 2) 
		{
			randomer = Random.Range (1, 80);	
		} 
		else if (LevelLoader.GetRound () >= 3) 
		{
			randomer = Random.Range (1, 30);	
		}
		randomq = randomer;
		//LevelLoader.SetRound (1);
	}
	
	// Update is called once per frame
	void Update () 
	{

			if (x == -15.2f) {
			randomq = 5;
			}

			//print (random);
	
		if (randomq == 5) {
				if (stop == false) {
					if (x < 13.5f) {
						x += 0.15f;
						check = true;
					}
				}
			} else {
			randomq = Random.Range (1, randomer);	
				check = false;
			}
			if (Input.GetKeyDown ("space")) {
				stop = true;
				x -= 1.5f;
				if (check == true) {
					stop = false;
				randomq = 0;
					//Instantiate (soldieridle, new Vector3 (-15.2f, 9.9f, 0), Quaternion.identity);
				} else {
					swag.TimeCountDown -= 2;
					stop = false;
				randomq = 0;
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
