using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {
	
	// Use this for initialization
	private float TimeCount = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TimeCount += Time.deltaTime;
		if(TimeCount >= 1) 
		{
			Application.LoadLevel("raiseflag");
		}
	}
}
