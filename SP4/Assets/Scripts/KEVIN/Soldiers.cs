using UnityEngine;
using System.Collections;

public class Soldiers : MonoBehaviour {
	public float x = -15.2f;
	public string strtoenter;
	public int random;
	public GameObject soldiers;
	public bool finish;
	// Use this for initialization
	void Start () {
		finish = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//print (random);

		if (random == 5) {
			//random = 5;
			if (finish == false) {
				if (x < 15.0f) {
					x += 0.1f;
					//random = 0;
				}
			}
		} else
			random = Random.Range (1, 100);	
		if (Input.GetKeyDown ("q")) {
			finish = true;
			finish = false;
			random = 0;
			
		}
		transform.position = new Vector3 (x, -9.9f, 0);
	}
}
