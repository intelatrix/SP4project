using UnityEngine;
using System.Collections;

public class StartSplash : MonoBehaviour {

	public GameObject Image;
	float SplashTime = 0;
	float SplashLimit = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		SplashTime += Time.deltaTime;
		float Temp = SplashTime*1.5f;
		if(Temp >= 1)
			Temp = 1;
		Image.renderer.material.color = new Color(1,1,1,Temp);
		if(SplashTime >=SplashLimit || Input.anyKeyDown)
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
