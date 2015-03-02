using UnityEngine;
using System.Collections;

public class YOG_Splash : MonoBehaviour {

	private float TimeCount = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TimeCount += Time.deltaTime;
		if(TimeCount >= 1) 
		{
			Application.LoadLevel("YOG");
		}
	}
}
