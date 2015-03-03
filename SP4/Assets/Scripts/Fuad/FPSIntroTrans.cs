using UnityEngine;
using System.Collections;

public class FPSIntroTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying) 
		{
			Application.LoadLevel("FPS_Tutorial");
		}
	}
}
