using UnityEngine;
using System.Collections;

public class BackgroundStart : MonoBehaviour {

	// Use this for initialization
	bool StartUp = false;
	void Start () 
	{
		int NumberOfBackgrounds = 0;
		foreach (Transform child in this.transform) 
		{
			if(GameObject.Find("Flag").transform != child)
			{
				child.transform.position = new Vector3(0+NumberOfBackgrounds*20.59f,4,0);
				child.renderer.material.color = new Color (1f,1f,1f,0.9f);
			
				if(transform.childCount-1 == NumberOfBackgrounds)
				{
					GameObject.Find("Flag").transform.parent = transform;
					GameObject.Find("Flag").transform.position = new Vector3(NumberOfBackgrounds*20.59f + 7,0,0);
					GameObject.Find("Controls").GetComponent<YOGControls>().SetNumberOfBG(NumberOfBackgrounds);
				}
			}
			
			++NumberOfBackgrounds;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(StartUp)
		{
			transform.position -= new Vector3(1,0,0) * Time.deltaTime * 4;
		}
	}
	
	public void StartScrolling()
	{
		StartUp = true;
	}
}