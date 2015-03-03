using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {
	
	// Use this for initialization
	public AudioClip FLAG;
	void Start () {
		audio.PlayOneShot (FLAG);
	}
	
	// Update is called once per frame
	void Update () {

		if(!audio.isPlaying) 
		{
			Application.LoadLevel("raiseflag");
		}
	}
}
