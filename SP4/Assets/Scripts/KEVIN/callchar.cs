using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class callchar : MonoBehaviour {
	int leftx=0;
	int rightx=0;
	public GameObject soldiers;
	public GameObject charater1; 
	public GameObject shit_left;
	public GameObject shit_right;
	public string test;
	public float TimeCountDown;
	public float shittime;
	public int random;
	public int shitcount1;
	public int shitcount2;
	public Soldiers swag;
	public int round;
	// Use this for initialization
	void Start () {
		Instantiate (charater1, new Vector3 (18.8f, -10.9f, 0), Quaternion.identity).name = "character1(Clone)";
		Instantiate (soldiers, new Vector3 (-15.2f, 9.9f, 0), Quaternion.identity);
		TimeCountDown = 13;
		shittime = 0;
		shitcount1 = 0;
		shitcount2 = 0;
		swag = FindObjectOfType<Soldiers> ();
		round = LevelLoader.GetRound();
		LevelLoader.SetRound(3);
		if (LevelLoader.GetRound () == 2) {
			shittime=1.5f;
			swag.random = Random.Range (1, 80);	
		} 
		else if (LevelLoader.GetRound () >= 3) {
			shittime=1f;
			swag.random = Random.Range (1, 30);	
		}

	}
	
	// Update is called once per frame
	void Update () 
	{

		shittime += Time.deltaTime;
		if (shittime >=2)
		{
			
			if (rightx <= 20) {
				if (random == 1) {
					shittime = 0;
					shitcount1++;
					Instantiate (shit_right, new Vector3 (24.5f, 7f, 0), Quaternion.identity);
					//transform.position =new Vector2(-2.5f, y);
					rightx++;
				} else {
					random = Random.Range (1, 3);
				}
			}
			
			
			if (leftx <= 20)
			{
				if (random == 2)
				{
					shittime = 0;
					shitcount2++;	
					Instantiate (shit_left, new Vector3 (16.3f, 7f, 0), Quaternion.identity);
					leftx++;
				} else {
					random = Random.Range (1, 3);	
				}
			}
		}
		if (shitcount2 >= 4) {
			random = 1;
			shitcount2 = 0;
		} else if (shitcount1 >= 4) {
			random = 2;
			shitcount1 = 0;
		}

		TimeCountDown = Mathf.MoveTowards (TimeCountDown, 0, Time.deltaTime);
		GameObject.Find ("CountDown").GetComponent<Text> ().text = "Time Left: " + TimeCountDown.ToString ("n2");

		if (TimeCountDown <= 0)
		{
			LevelLoader.LoseLevel ();
		}
	

		//	swag.random = Random.Range (1, 30);	
	
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
