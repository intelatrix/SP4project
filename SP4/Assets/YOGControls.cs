using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YOGControls : MonoBehaviour {

	bool StartUp = false;
	public GameObject RunningMan;
	public GameObject StandingMan;
	private GameObject Torch;
	private float StartCount = 3;
	// Use this for initialization
	void Start () 
	{
		StandingMan.SetActive(false);
		Torch = GameObject.Find("Torch");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(StartUp == false)
		{
			StartCount = Mathf.MoveTowards(StartCount, 0, Time.deltaTime);
			GameObject.Find("StartCount").GetComponent<Text>().text = ((int)StartCount+1).ToString();
			
			RunningMan.transform.position = Vector3.MoveTowards(RunningMan.transform.position, new Vector3(-5,0,0) , Time.deltaTime*3);
			RunningMan.GetComponent<Animator>().speed = 0.5f;
			if(RunningMan.transform.position == new Vector3(-5,0,0))
			{
				StandingMan.SetActive(true);
				StandingMan.transform.position = RunningMan.transform.position;
				RunningMan.SetActive(false);
				Torch.transform.position = new Vector3(StandingMan.transform.position.x, 1.75f ,Torch.transform.position.z);
				if(StartCount <= 0)
				{
					StartUp = true;
					GameObject.Find("StartCount").SetActive(false);
					StandingMan.SetActive(false);
					RunningMan.SetActive(true);
					RunningMan.GetComponent<Animator>().speed = 1.1f;
					
					Torch.transform.parent = RunningMan.transform;
					Torch.transform.position = RunningMan.transform.position + new Vector3(0.6f,0.8f ,0);
					Torch.transform.Rotate(new Vector3(0,0,340));
				}
			}
		}
		else
		{
			
			RunningMan.transform.position += new Vector3(10,0,0) * Time.deltaTime;
			
		}
		
	}
}
