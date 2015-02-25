using UnityEngine;
using System.Collections;

public class BackgroundStart : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		int NumberOfBackgrounds = 0;
		foreach (Transform child in this.transform) 
		{
			child.transform.position = new Vector3(0+NumberOfBackgrounds*20.5f,4,0);
			++NumberOfBackgrounds;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
