using UnityEngine;
using System.Collections;

public class BackgroundStart : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		int NumberOfBackgrounds = 0;
		foreach (Transform child in this.transform) 
		{
			child.transform.position = new Vector3(0+NumberOfBackgrounds*20.59f,4,0);
			child.renderer.material.color = new Color (1f,1f,1f,0.9f);
			++NumberOfBackgrounds;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
