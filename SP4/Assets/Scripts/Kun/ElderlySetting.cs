using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElderlySetting : MonoBehaviour {
	//dental
	public GameObject waypoint1;
	public GameObject dental;
	
	//hospital
	public GameObject waypoint2;
	public GameObject hospital;
	
	//mart
	public GameObject waypoint3;
	public GameObject mart;
	
	//church
	public GameObject waypoint4;
	public GameObject church;

	//starting
	public GameObject waypoint5;

	public GameObject timerText;
	public GameObject expenseText;
	
	private int[] eventHolder;
	public int[] costOfEvent;
	public int[] eventDiscount;
	private int numOfEvents;
	private int numOfDentist;
	private int numOfHospital;
	private int numOfMart;
	private int numOfChurch;
	
	private float timer;
	private float currentTime;
	private float wayPointX;
	private float wayPointY;
	private float wayPointZ;
	public float estimatedExpense;
	public float actualExpense;
	
	private bool stopSimulation;
	private bool spentLess;
	private bool spentEqual;
	private bool spentMore;
	private bool visitingDentist;
	private bool visitingHospital;
	private bool visitingMart;
	private bool visitingChurch;
	private bool visitedDentist;
	private bool visitedHospital;
	private bool visitedMart;
	private bool visitedChurch;
	private bool goUp;
	private bool noClip;
	
	// Use this for initialization
	void Start () {
		stopSimulation = false;
		spentLess = false;
		spentEqual = false;
		spentMore = false;
		visitingDentist = false;
		visitingHospital = false;
		visitingMart = false;
		visitingChurch = false;
		visitedDentist = false;
		visitedHospital = false;
		visitedMart = false;
		visitedChurch = false;
		noClip = false;
		goUp = false;
		actualExpense = 0.0f;
		estimatedExpense = 0.0f;
		numOfDentist = 0;
		numOfHospital = 0;
		numOfMart = 0;
		numOfChurch = 0;
		Init();
		timer = 20.0f;
		currentTime = 0.0f;
		//sets elderly waypoint to dentist waypoint
		wayPointX = waypoint1.GetComponent<Transform>().transform.position.x;
		wayPointY = waypoint1.GetComponent<Transform>().transform.position.y;
		wayPointZ = 6.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 5.0f) {
			timer = Mathf.MoveTowards (timer, 5.0f, Time.deltaTime);
		} else {
			timer = Mathf.MoveTowards(timer, 0.0f, Time.deltaTime);
			stopSimulation = true;
			//Check selection here
			if (timer <= 0.0f) {
				Check();
			}
		}
		
		if (stopSimulation == false) {
			if (goUp == false) {
				GetComponent<Transform> ().transform.position = Vector3.MoveTowards (GetComponent<Transform> ().transform.position, new Vector3 (wayPointX, wayPointY, 6.0f), 5.0f * Time.deltaTime);
			} else {
				//while simulation is happening, elderly is in constant movement
				GetComponent<Transform> ().transform.position = Vector3.MoveTowards (GetComponent<Transform> ().transform.position, new Vector3 (wayPointX, wayPointY, wayPointZ), 5.0f * Time.deltaTime);
			}
		}
		timerText.GetComponent<Text> ().text = "Time Left: " + timer.ToString("n2");
		expenseText.GetComponent<Text> ().text = "Estimated Spending: SGD$" + estimatedExpense.ToString();
	}
	
	void Init() {
		LevelLoader.SetRound (1);
		if (LevelLoader.GetRound () == 1) {
			numOfEvents = 4;
		} else if (LevelLoader.GetRound () == 2) {
			numOfEvents = 5;
		} else if (LevelLoader.GetRound() >= 3) {
			numOfEvents = 6;
		}
		eventHolder = new int[numOfEvents];
		costOfEvent = new int[4];
		eventDiscount = new int[4];
		//random each event
		for (int i = 0; i < numOfEvents; i++) {
			int randomNum = Random.Range(1, 5);
			eventHolder[i] = randomNum;
		}
		//random the cost of each event
		for (int i = 0; i < 4; i++) {
			int randomNum = Random.Range(1, 4);
			int money = 0;
			if (randomNum == 1) {
				money = 100;
			} else if (randomNum == 2) {
				money = 300;
			} else if (randomNum == 3) {
				money = 500;
			}
			costOfEvent[i] = money;
		}
		//random the discount price for each event
		for (int i = 0; i < 4; i++) {
			int randomNum = Random.Range(1, 4);
			int discount = 0;
			if (randomNum == 1) {
				discount = 10;
			} else if (randomNum == 2) {
				discount = 50;
			} else if (randomNum == 3) {
				discount = 75;
			}
			eventDiscount[i] = discount;
		}
		//Calculate the estimated and actual cost of the game
		for (int i = 0; i < numOfEvents; i++) {
			if (eventHolder[i] == 1) {
				numOfDentist += 1;
				actualExpense += costOfEvent[0] - (costOfEvent[0] * (eventDiscount[0] / 100.0f));
			} else if (eventHolder[i] == 2) {
				numOfHospital += 1;
				actualExpense += costOfEvent[1] - (costOfEvent[1] * (eventDiscount[1] / 100.0f));
			} else if (eventHolder[i] == 3) {
				numOfMart += 1;
				actualExpense += costOfEvent[2] - (costOfEvent[2] * (eventDiscount[2] / 100.0f));
			} else if (eventHolder[i] == 4) {
				numOfChurch += 1;
				actualExpense += costOfEvent[3] - (costOfEvent[3] * (eventDiscount[3] / 100.0f));
			}
			
			if (i == (numOfEvents-1)) {
				int randomNum = Random.Range(1, 4);
				if (randomNum == 1) {
					//Spent more
					estimatedExpense = actualExpense - 100.0f;
				} else if (randomNum == 2) {
					//Spent equal
					estimatedExpense = actualExpense;
				} else if (randomNum == 3) {
					//Spent less
					estimatedExpense = actualExpense + 100.0f;
				}
			}
		}
	}

	void Check() {
		if (spentLess) {
			if (estimatedExpense > actualExpense) {
				LevelLoader.WinLevel();
			} else {
				LevelLoader.LoseLevel();
			}
		}

		if (spentEqual) {
			if (estimatedExpense == actualExpense) {
				LevelLoader.WinLevel();
			} else {
				LevelLoader.LoseLevel();
			}
		}

		if (spentMore) {
			if (estimatedExpense < actualExpense) {
				LevelLoader.WinLevel();
			} else {
				LevelLoader.LoseLevel();
			}
		}

		if (spentLess == false && spentEqual == false && spentMore == false) {
			LevelLoader.LoseLevel();
		}
	}

	public void LessButton() {
		spentLess = true;
		spentEqual = false;
		spentMore = false;
		Check();
	}

	public void EqualButton() {
		spentLess = false;
		spentEqual = true;
		spentMore = false;
		Check();
	}

	public void MoreButton() {
		spentLess = false;
		spentEqual = false;
		spentMore = true;
		Check();
	}
	
	void OnTriggerStay2D(Collider2D col) {
		if (noClip == false) { 
			//if elderly reaches dentist waypoint
			if (col.gameObject.name == "Dentist_Waypoint" && numOfDentist > 0) {
				if (visitingDentist == false) {
					currentTime = Time.time + 0.2f;
					visitingDentist = true;
				}
				wayPointZ = 6.0f;
				DentalVisit ();
			} else if (col.gameObject.name == "Dentist_Waypoint" && numOfDentist == 0) {
				wayPointX = waypoint2.GetComponent<Transform> ().transform.position.x;
				wayPointY = waypoint2.GetComponent<Transform> ().transform.position.y;
				goUp = false;
			}

			//if elderly reaches the dental clince
			if (col.gameObject.name == "dentist" && numOfDentist > 0) {
				if (visitedDentist == false) {
					currentTime = Time.time + 0.5f;
					visitedDentist = true;
				}
				DentalVisited ();
			}

			//if elderly reaches hospital waypoint
			if (col.gameObject.name == "Hospital_Waypoint" && numOfHospital > 0) {
				if (visitingHospital == false) {
					currentTime = Time.time + 0.2f;
					visitingHospital = true;
				}
				wayPointZ = 6.0f;
				HospitalVisit ();
			} else if (col.gameObject.name == "Hospital_Waypoint" && numOfHospital == 0) {
				wayPointX = waypoint3.GetComponent<Transform> ().transform.position.x;
				wayPointY = waypoint3.GetComponent<Transform> ().transform.position.y;
				goUp = false;
			}
			
			//if elderly reaches the hospital
			if (col.gameObject.name == "hospital" && numOfHospital > 0) {
				if (visitedHospital == false) {
					currentTime = Time.time + 0.5f;
					visitedHospital = true;
				}
				HospitalVisited ();
			}

			//if elderly reaches mart waypoint
			if (col.gameObject.name == "Mart_Waypoint" && numOfMart > 0) {
				if (visitingMart == false) {
					currentTime = Time.time + 0.2f;
					visitingMart = true;
				}
				wayPointZ = 6.0f;
				MartVisit ();
			} else if (col.gameObject.name == "Mart_Waypoint" && numOfMart == 0) {
				wayPointX = waypoint4.GetComponent<Transform> ().transform.position.x;
				wayPointY = waypoint4.GetComponent<Transform> ().transform.position.y;
				goUp = false;
			}
			
			//if elderly reaches the mart
			if (col.gameObject.name == "shopping_mart" && numOfMart > 0) {
				if (visitedMart == false) {
					currentTime = Time.time + 0.5f;
					visitedMart = true;
				}
				MartVisited ();
			}

			//if elderly reaches church waypoint
			if (col.gameObject.name == "Church_Waypoint" && numOfChurch > 0) {
				if (visitingChurch == false) {
					currentTime = Time.time + 0.2f;
					visitingChurch = true;
				}
				wayPointZ = 6.0f;
				ChurchVisit ();
			} else if (col.gameObject.name == "Church_Waypoint" && numOfChurch == 0) {
				noClip = true;
			}
			
			//if elderly reaches the church
			if (col.gameObject.name == "church" && numOfChurch > 0) {
				if (visitedChurch == false) {
					currentTime = Time.time + 0.5f;
					visitedChurch = true;
				}
				ChurchVisited ();
			}
		} else if (noClip == true) {
			setDirection(3);
			wayPointX = waypoint5.GetComponent<Transform>().transform.position.x ;
			wayPointY = waypoint5.GetComponent<Transform>().transform.position.y;
			goUp = false;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "Dentist_Waypoint" && numOfDentist > 0) {
			goUp = true;
			wayPointZ = 6.25f;
		} else if (col.gameObject.name == "Dentist_Waypoint" && numOfDentist == 0) {
			goUp = false;
		}

		//if elderly leaves the dental clinc
		if (col.gameObject.name == "dentist" && numOfDentist > 0) {
			visitedDentist = false;
			--numOfDentist;
		}

		if (col.gameObject.name == "Hospital_Waypoint" && numOfHospital > 0) {
			goUp = true;
			wayPointZ = 6.25f;
		} else if (col.gameObject.name == "Hospital_Waypoint" && numOfHospital == 0) {
			goUp = false;
		}
		
		//if elderly leaves the hospital
		if (col.gameObject.name == "hospital" && numOfHospital > 0) {
			visitedHospital = false;
			--numOfHospital;
		}

		if (col.gameObject.name == "Mart_Waypoint" && numOfMart > 0) {
			goUp = true;
			wayPointZ = 6.25f;
		} else if (col.gameObject.name == "Mart_Waypoint" && numOfMart == 0) {
			goUp = false;
		}
		
		//if elderly leaves the mart
		if (col.gameObject.name == "shopping_mart" && numOfMart > 0) {
			visitedMart = false;
			--numOfMart;
		}

		if (col.gameObject.name == "Church_Waypoint" && numOfChurch > 0) {
			goUp = true;
			wayPointZ = 6.25f;
		} else if (col.gameObject.name == "Church_Waypoint" && numOfChurch == 0) {
			goUp = false;
		}
		
		//if elderly leaves the mart
		if (col.gameObject.name == "church" && numOfChurch > 0) {
			visitedChurch = false;
			--numOfChurch;
		}
	}

	void DentalVisit() {
		//if elderly collided with the dentist waypoint
		//set the elderly to move to the dental clinc
		if (visitingDentist && currentTime < Time.time) {
			wayPointX = dental.GetComponent<Transform> ().transform.position.x - 0.2f;
			wayPointY = dental.GetComponent<Transform> ().transform.position.y;
		}
	}

	void DentalVisited() {
		//if elderly collided with the dentist clinc
		//set the elderly to move to the dentist waypoint
		if (visitedDentist && currentTime < Time.time) {
			visitingDentist = false;
			wayPointX = waypoint1.GetComponent<Transform> ().transform.position.x;
			wayPointY = waypoint1.GetComponent<Transform> ().transform.position.y;
			goUp = true;
			wayPointZ = 6.0f;
		}
	}

	void HospitalVisit() {
		//if elderly collided with the hospital waypoint
		//set the elderly to move to the hospital
		if (visitingHospital && currentTime < Time.time) {
			wayPointX = hospital.GetComponent<Transform> ().transform.position.x - 0.2f;
			wayPointY = hospital.GetComponent<Transform> ().transform.position.y;
		}
	}
	
	void HospitalVisited() {
		//if elderly collided with the hospital
		//set the elderly to move to the hospital waypoint
		if (visitedHospital && currentTime < Time.time) {
			visitedHospital = false;
			wayPointX = waypoint2.GetComponent<Transform> ().transform.position.x;
			wayPointY = waypoint2.GetComponent<Transform> ().transform.position.y;
			goUp = true;
			wayPointZ = 6.0f;
		}
	}

	void MartVisit() {
		//if elderly collided with the mart waypoint
		//set the elderly to move to the mart
		if (visitingMart && currentTime < Time.time) {
			wayPointX = mart.GetComponent<Transform> ().transform.position.x - 0.2f;
			wayPointY = mart.GetComponent<Transform> ().transform.position.y;
		}
	}
	
	void MartVisited() {
		//if elderly collided with the mart
		//set the elderly to move to the mart waypoint
		if (visitedMart && currentTime < Time.time) {
			visitedMart = false;
			wayPointX = waypoint3.GetComponent<Transform> ().transform.position.x;
			wayPointY = waypoint3.GetComponent<Transform> ().transform.position.y;
			goUp = true;
			wayPointZ = 6.0f;
		}
	}

	void ChurchVisit() {
		//if elderly collided with the Church waypoint
		//set the elderly to move to the Church
		if (visitingChurch && currentTime < Time.time) {
			wayPointX = church.GetComponent<Transform> ().transform.position.x - 0.2f;
			wayPointY = church.GetComponent<Transform> ().transform.position.y;
		}
	}
	
	void ChurchVisited() {
		//if elderly collided with the Church
		//set the elderly to move to the Church waypoint
		if (visitedChurch && currentTime < Time.time) {
			visitedChurch = false;
			wayPointX = waypoint4.GetComponent<Transform> ().transform.position.x;
			wayPointY = waypoint4.GetComponent<Transform> ().transform.position.y;
			goUp = true;
			wayPointZ = 6.0f;
		}
	}
	
	void setDirection(int newDir) {
		GetComponent<Animator>().SetInteger("Direction", newDir);
	}
}
