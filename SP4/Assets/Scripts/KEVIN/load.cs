using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {
	
	// Use this for initialization
	public AudioClip FLAG;
	private float TimeCount = 0;
	void Start () {
		audio.PlayOneShot (FLAG);
	}
	
	// Update is called once per frame
	void Update () {
		TimeCount += Time.deltaTime;
		if(TimeCount >= 2) 
		{
			Application.LoadLevel("raiseflag");
		}
	}
}
