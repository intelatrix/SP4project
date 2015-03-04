using UnityEngine;
using System.Collections;

public class HospitalTutTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying|| Input.anyKeyDown) 
		{
			Application.LoadLevel("Hospital_Splash");
		}
	}
}
