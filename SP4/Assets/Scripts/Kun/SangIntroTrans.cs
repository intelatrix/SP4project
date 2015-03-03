using UnityEngine;
using System.Collections;

public class SangIntroTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying) 
		{
			Application.LoadLevel("Sang_Tutorial");
		}
	}
}
