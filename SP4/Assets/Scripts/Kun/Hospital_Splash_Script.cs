using UnityEngine;
using System.Collections;

public class Hospital_Splash_Script : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = Time.time + 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timer) {			
			Application.LoadLevel ("Hospital");
		}
	}
}
