using UnityEngine;
using System.Collections;

public class HumanSetting : MonoBehaviour {	
	
	public GameObject text;
	private GameObject text2;
	private Transform target;
	private Transform newTransform;

	private int Type;
	private float timer;
	private float setDirectionTimer;
	
	public bool movement;
	private bool switchDirection;
	private bool scenarioStuff;
	private bool scenarioTimerReset;
	private bool done;
	public float price = 100.0f;
	private TextMesh theText;

	private float currentTime;
	private float randomX;
	private float randomY;
	private Vector3 waypoint;
	
	// Use this for initialization
	void Start () {
		done = false;
		movement = false;
		text2 = Instantiate (text, new Vector3 (GetComponent<Transform>().transform.position.x, GetComponent<Transform>().transform.position.y - 0.5f, GetComponent<Transform>().transform.position.z), Quaternion.identity) as GameObject;
		theText = text2.GetComponent<TextMesh>();
		currentTime = Time.time;
		RandomMovement ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movement == false) {
			//updates the position of the price according to the human, also updates the price
			theText.text = "Price: $" + price.ToString ();
			text2.transform.position = new Vector3 (GetComponent<Transform> ().transform.position.x, GetComponent<Transform> ().transform.position.y - 0.5f, GetComponent<Transform> ().transform.position.z);

			if (Time.time >= currentTime) {
				RandomMovement ();
				currentTime = Time.time + Random.Range (0.5f, 1.5f);
			}

			//make the ai moves within the set area
			if (GetComponent<Transform> ().transform.position.x > -8.3f && GetComponent<Transform> ().transform.position.x < 8.3f
				&& GetComponent<Transform> ().transform.position.y > -3.0f && GetComponent<Transform> ().transform.position.y < 4.85f) {
				GetComponent<Transform> ().transform.position = Vector3.MoveTowards (GetComponent<Transform> ().transform.position, waypoint, 0.05f);
			} else {
				RandomMovement ();
			}
		}
	}

	void RandomMovement() {
		randomX = Random.Range(-8.0f, 8.0f);
		randomY = Random.Range(-2.8f, 4.8f);
		waypoint = new Vector3(randomX, randomY, 6.2f);

		if (waypoint.x < GetComponent<Transform>().transform.position.x) {
			setDirection(3);
		} else if (waypoint.x >= GetComponent<Transform>().transform.position.x) {
			setDirection(2);
		} else if (waypoint.y > GetComponent<Transform>().transform.position.y) {
			setDirection(1);
		} else if (waypoint.y <= GetComponent<Transform>().transform.position.y) {
			setDirection(0);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Collided");
		if (tag == "elderly" && other.tag == "man" && other.GetComponent<HumanSetting>().done == false && done == false) {
			//they collided, do the scenario random chance here if it happens change price and set it to done, random their position agn
			Debug.Log("Price dropped");
			price = 50.0f;
			other.GetComponent<HumanSetting>().price = other.GetComponent<HumanSetting>().price - 20.0f;
			done = true;
			other.GetComponent<HumanSetting>().done = true;
		}
	}
	
	void setDirection(int newDir) {
		GetComponent<Animator>().SetInteger("Direction", newDir);
	}
}	