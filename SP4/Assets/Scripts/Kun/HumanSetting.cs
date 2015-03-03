using UnityEngine;
using System.Collections;

public class HumanSetting : MonoBehaviour {	

	public GameObject waypoint1;
	public GameObject dental;

	private float timer;

	private bool switchDirection;
	private bool scenarioStuff;
	private bool scenarioTimerReset;
	private bool done;

	private float currentTime;
	private float randomX;
	private float randomY;
	private Vector3 waypoint;
	
	// Use this for initialization
	void Start () {
		done = false;
		scenarioStuff = false;
		randomX = waypoint1.GetComponent<Transform> ().transform.position.x;
		randomY = waypoint1.GetComponent<Transform> ().transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (done == false) {
			GetComponent<Transform>().transform.position = Vector3.MoveTowards(GetComponent<Transform>().transform.position, new Vector3(randomX, randomY, 6.2f), 1.2f*Time.deltaTime);
		}

		if (scenarioStuff && timer < Time.time) {
			randomX = dental.GetComponent<Transform>().transform.position.x;
			randomY = dental.GetComponent<Transform>().transform.position.y;
			scenarioStuff = false;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.name == "Dentist_Waypoint") {
			//done = true;
			if (scenarioStuff == false) {
				timer = Time.time + 0.5f;
			}
			scenarioStuff = true;
		}
		if (col.gameObject.name == "dentist") {
			GetComponent<Transform>().transform.position = new Vector3(GetComponent<Transform>().transform.position.x, GetComponent<Transform>().transform.position.y, GetComponent<Transform>().transform.position.z + 0.1f);
			randomX = dental.GetComponent<Transform>().transform.position.x;
			randomY = dental.GetComponent<Transform>().transform.position.y;
		}
	}
	
	void setDirection(int newDir) {
		GetComponent<Animator>().SetInteger("Direction", newDir);
	}
}	