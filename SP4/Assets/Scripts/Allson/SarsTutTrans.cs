using UnityEngine;
using System.Collections;

public class SarsTutTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying|| Input.anyKeyDown) 
		{
			Application.LoadLevel("Sars_Splash");
		}
	}
}
