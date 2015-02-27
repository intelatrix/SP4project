using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
	
	public float flagpos;
	public AudioClip majulah;
	public AudioSource majulah_s;
	bool playTrue = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKeyDown ("u")) 
		{
			if(GameObject.Find ("character(Clone)")||GameObject.Find ("character2(Clone)"))
			{
			flagpos+=0.4f;
			if (flagpos < 5.9f)
			{
					transform.position = new Vector3 (23.8f, flagpos, 0);
			}
			if (flagpos >= 5.9f)
			{
				flagpos = 5.9f;
					transform.position = new Vector3 (23.8f, flagpos, 0);
					playTrue = true;
					playSound();

					LevelLoader.NextLevel();
			}
			}
		}
		else if(Input.GetKeyDown ("p"))
		{
			if(GameObject.Find ("character1(Clone)")||GameObject.Find ("character3(Clone)"))
			{
			flagpos+=0.4f;
			if (flagpos < 5.9f)
			{
					transform.position = new Vector3 (23.8f, flagpos, 0);
			}
			if (flagpos >= 5.9f)
			{
				flagpos = 5.9f;
					transform.position = new Vector3 (23.8f, flagpos, 0);
					playTrue = true;
					playSound();

					LevelLoader.NextLevel();
			}
			}
		}
		if (flagpos <= 5.9f)
		{
			flagpos-=0.01f;
			transform.position = new Vector3 (23.8f, flagpos, 0);
			//LevelLoader.NextLevel();
		}
		if (flagpos <= -12.1f)
		{
			//Debug.Log ("lol");
			flagpos=-12.1f;
			transform.position = new Vector3 (23.8f, flagpos, 0);
		
		}
	}

	void playSound (){

		if (playTrue == true && majulah_s.isPlaying == false) {
			playTrue = false;
			majulah_s.PlayOneShot (majulah);
		} else if (playTrue == true && majulah_s.isPlaying == true) {
			playTrue = false;
		}


	}
	
}
