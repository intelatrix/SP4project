using UnityEngine;
using System.Collections;

public class YOGintroTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!audio.isPlaying) 
		{
			Application.LoadLevel("YOG_Tutorial");
		}
	
	}
}
