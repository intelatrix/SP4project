using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YOGControls : MonoBehaviour {

	bool StartUp = false;
	public GameObject RunningMan;
	public GameObject StandingMan;
	public GameObject Flag;
	private GameObject Torch;
	private float StartCount = 3;
	private int NumberOfBackgrounds;
	private GameObject DestroyingWind;
	bool CrossLast = false;
	public AudioClip windDissipate;
	public AudioClip Song;
	public AudioClip Bang;
	// Use this for initialization
	void Start () 
	{
		StandingMan.SetActive(false);
		Torch = GameObject.Find("Torch");
		LevelLoader.SetRound(3);
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
					
					GameObject.Find("WindSpawner").GetComponent<WindSpawner>().StartSpawning();
					GameObject.Find("RunningBackground").GetComponent<BackgroundStart>().StartScrolling();

					audio.PlayOneShot(Song);
					audio.PlayOneShot(Bang);

				}
			}
		}
		else
		{
			
			RunningMan.transform.position = Vector3.MoveTowards(RunningMan.transform.position, Flag.transform.position,Time.deltaTime*1f) ;
			if(RunningMan.transform.position.x >= Flag.transform.position.x)
			{
				LevelLoader.WinLevel();
			}
			
			if(Vector3.Distance(RunningMan.transform.position, Flag.transform.position - new Vector3(7,0,0)) > 10.295f - 5f && !CrossLast)
			{
				Camera.main.transform.position = new Vector3(RunningMan.transform.position.x+5, 4f, -10);
			}
			else
			{
				CrossLast = true;
			}
			
			if(CrossLast)
			{
				Camera.main.transform.position = new Vector3(Flag.transform.position.x-7, 4f, -10);
			}
				
			foreach (char c in Input.inputString) 
			{
				foreach(GameObject Wind in GameObject.FindGameObjectsWithTag("Wind"))
				{
					if(Wind.GetComponent<Wind>().CheckNextLetter(c))	
					{
						if(DestroyingWind == null || Wind.transform.position.x < DestroyingWind.transform.position.x)
						DestroyingWind = Wind;
					}
				}
				if(DestroyingWind != null)
				{
					Destroy(DestroyingWind);
					audio.PlayOneShot(windDissipate);
					ResetWords();
				}
			}
		}
		
	}
	
	public void SetNumberOfBG(int BG)
	{
		NumberOfBackgrounds = BG;
	}
	
	void ResetWords()
	{
		foreach(GameObject Wind in GameObject.FindGameObjectsWithTag("Wind"))
		{
			Wind.GetComponent<Wind>().ResetWord();
		}
	}
	
	public bool CrossedLast()
	{
		return CrossLast;
	}
}
