using UnityEngine;
using System.Collections;


public class callchar : MonoBehaviour {

	public GameObject soldiers;
	public GameObject charater1;
	public string test;
	// Use this for initialization
	void Start () {
		Instantiate (charater1, new Vector3 (18.8f, -10.9f, 0), Quaternion.identity).name = "character1(Clone)";
		//Instantiate (soldiers, new Vector3 (0.0f, 0.0f, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*foreach (char c in Input.inputString) 
		{
			if (test == "shoot")
			{
				Destroy(soldiers.gameObject);
			}
			if (c == '\b')
			{
				if (test.Length > 0)
				{
					test =""; 	
				}
			}
			else
				test += c;
		}*/

	}
}
