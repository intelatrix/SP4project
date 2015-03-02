using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanSpawner : MonoBehaviour {
	
	public GameObject elderly;
	public GameObject man;
	public GameObject priceText;
	public GameObject timerOBJ;

	private int numOfHumans;
	private float yourPrice;
	private float timer;
	private GameObject[] arrayList;

	private bool stopAll;
	private bool checkPrice;
	static float totalPrice;

	// Use this for initialization
	void Start () {
		stopAll = false;
		checkPrice = false;
		yourPrice = 0.0f;
		timer = 20.0f;

		if (LevelLoader.GetRound () >= -1 || LevelLoader.GetRound() == 1) {
			numOfHumans = 8;
		} else if (LevelLoader.GetRound () == 2) {
			numOfHumans = 10;
		} else if (LevelLoader.GetRound() >= 3) {
			numOfHumans = 12;
		}
		SpawnHumans();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 8.0f) {
			timer = Mathf.MoveTowards (timer, 0, Time.deltaTime);

			if (stopAll == false) {
				for (int i = 0; i < numOfHumans; i++) {
					arrayList[i].GetComponent<HumanSetting>().movement = true;
				}
				stopAll = true;
			}

			if (timer == 0.0f) {
				CheckAnswer();
			}
		} else if (timer > 8.0f) {
			timer = Mathf.MoveTowards (timer, 8, Time.deltaTime);
		}
		KeyboardInputs();

		timerOBJ.GetComponent<Text>().text = "Time Left: " + timer.ToString ("n2");
		priceText.GetComponent<Text>().text = "Total Bill: $" + yourPrice.ToString();
	}

	void SpawnHumans() {
		arrayList = new GameObject[numOfHumans];
		for (int i = 0; i < numOfHumans; i++) {
			int random = Random.Range(0, 2);
			float posX = Random.Range(-8.0f, 8.0f);
			float posY = Random.Range(-2.5f, 4.5f);
			if (random == 0) {
				arrayList[i] = Instantiate(elderly, new Vector3(posX, posY, 6.2f), Quaternion.identity) as GameObject;
				arrayList[i].tag = "elderly";
			} else if (random == 1) {
				arrayList[i] = Instantiate(man, new Vector3(posX, posY, 6.2f), Quaternion.identity) as GameObject;
				arrayList[i].tag = "man";
			}
		}
	}
	
	void CheckAnswer() {
		if (checkPrice == false) {
			for (int i = 0; i < numOfHumans; i++) {
				totalPrice += arrayList [i].GetComponent<HumanSetting> ().price;
			}
			checkPrice = true;
		}

		if ((yourPrice - 20.0f) >= totalPrice || (yourPrice + 20.0f) <= totalPrice || yourPrice == totalPrice) {
			Debug.Log (totalPrice.ToString ());
			Debug.Log ("Win");
		} else {
			Debug.Log (totalPrice.ToString ());
			Debug.Log ("Lose");
		}
	}

	void KeyboardInputs() {
		if (Input.GetKeyDown(KeyCode.W)) {
			yourPrice += 10.0f;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			if ((yourPrice-10.0f) >= 0.0f)  {
				yourPrice -= 10.0f;
			}
		} else if (Input.GetKeyDown (KeyCode.D)) {
			yourPrice += 100.0f;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			if ((yourPrice-100.0f) >= 0.0f) {
				yourPrice -= 100.0f;
			}
		}
	}
}
