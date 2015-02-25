using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {
	// Use this for initialization
	public GameObject charater1;
	public GameObject charater;
	public GameObject charater2;
	public GameObject charater3;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("u"))
		{	
			if(GameObject.Find ("character(Clone)"))
			{
				Instantiate (charater1, new Vector3 (18.8f, -10.9f, 0), Quaternion.identity) ;
				GameObject.Destroy (GameObject.Find ("character(Clone)"));

			}
			else if(GameObject.Find ("character2(Clone)"))
			{
				Instantiate (charater3, new Vector3 (22.1f, -10.9f, 0), Quaternion.identity) ;
				GameObject.Destroy (GameObject.Find ("character2(Clone)"));
				
			}

		}
		else if (Input.GetKeyDown ("p")) 
		{
			if(GameObject.Find ("character1(Clone)"))
			{
				Instantiate (charater, new Vector3 (18.8f, -10.9f, 0), Quaternion.identity) ;
				GameObject.Destroy (GameObject.Find ("character1(Clone)"));
			}
			else if(GameObject.Find ("character3(Clone)"))
			{
				Instantiate (charater2, new Vector3 (22.1f, -10.9f, 0), Quaternion.identity) ;
				GameObject.Destroy (GameObject.Find ("character3(Clone)"));
			}
		}
	
	

		if (Input.GetKeyDown ("k"))
		{
			if(GameObject.Find ("character1(Clone)"))
			{
				GameObject.Destroy (GameObject.Find ("character1(Clone)"));
				Instantiate (charater2, new Vector3 (22.1f, -10.9f, 0), Quaternion.identity) ;
			}
			else if(GameObject.Find ("character(Clone)"))
			{
				GameObject.Destroy (GameObject.Find ("character(Clone)"));
				Instantiate (charater3, new Vector3 (22.1f, -10.9f, 0), Quaternion.identity) ;
			}

		}
			
	
		else if (Input.GetKeyDown ("l"))
		{
			if(GameObject.Find ("character2(Clone)"))
			{
				GameObject.Destroy (GameObject.Find ("character2(Clone)"));
				Instantiate (charater, new Vector3 (18.8f, -10.9f, 0), Quaternion.identity) ;
			}
			else if(GameObject.Find ("character3(Clone)"))
			{
				GameObject.Destroy (GameObject.Find ("character3(Clone)"));
				Instantiate (charater1, new Vector3 (18.8f, -10.9f, 0), Quaternion.identity) ;
			}
		}

}
}