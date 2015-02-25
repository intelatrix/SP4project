using UnityEngine;
using System.Collections;

public class shit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D shit) 
	{
		if (shit.gameObject.name == "shit_left" ||shit.gameObject.name ==  "shit_right") {
			Destroy(shit.gameObject);
		}
	}
}
