using UnityEngine;
using System.Collections;

public class YOG_Splash : MonoBehaviour {

	private float TimeCount = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(audio.isPlaying == false) 
		{
			Application.LoadLevel("YOG");
		}
	}
}
