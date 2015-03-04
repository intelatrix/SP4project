using UnityEngine;
using System.Collections;

public class FlagTutTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying|| Input.anyKeyDown) 
		{
			Application.LoadLevel("raiseflagsplash");
		}
	}
}
