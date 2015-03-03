using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckOutOfBound : MonoBehaviour {
    
    public GameObject rightPlank;
    public GameObject leftPlank;
	public GameObject timer;
	public GameObject waterParticle;
    
    private GameObject obj = null;
    public int numOfCorrect;
	private int numOfObjects;
	public GameObject[] objectList;

	private float time = 20.0f;
	private Vector3 screenPoint;
	private Vector3 offset;

	private bool falling = false;
	private bool gameover = false;
	private bool win = false;
	private bool dragging = false;

	public AudioClip splash;

	void Start() {
		if (LevelLoader.GetRound() == 1) {
			numOfCorrect = 2;
			numOfObjects = 6;
		} else if (LevelLoader.GetRound() == 2) {
			numOfCorrect = 3;
			numOfObjects = 8;
		} else if (LevelLoader.GetRound () >= 3) {
			numOfCorrect = 4;
			numOfObjects = 10;
		}
		objectList = new GameObject[numOfObjects];
		objectList = GameObject.Find("Spawner").GetComponent<Spawner>().arrayList;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (GameObject.Find ("Spawner").GetComponent<Spawner> ().control == true && win == false && gameover == false) {
			time = Mathf.MoveTowards (time, 0, Time.deltaTime);
			timer.SetActive(true);
			timer.GetComponent<Text> ().text = "Time Left: " + time.ToString ("n2");
		} else {
			timer.SetActive(false);
		}

		//Maybe add in a sound for time's up?
		if (time <= 0.0f && win == false && gameover == false) {
			Debug.Log("Time's up! Gameover!");
			gameover = true;
		}

		if (dragging == false) {
			if (Input.GetMouseButtonDown (0) == true && GameObject.Find ("Spawner").GetComponent<Spawner> ().control == true) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit ();
			
				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.gameObject.tag == "Obj") {
						if (obj == null) {
							obj = hit.transform.gameObject;
							Debug.Log ("Already Nulled: " + obj.name);
						} else {
							Debug.Log ("Not Nulled: " + obj.name);
							dragging = false;
							obj = null;
							obj = hit.transform.gameObject;
							Debug.Log ("After nulling: " + obj.name);
						}
					
						if (obj != null) {
							screenPoint = Camera.main.WorldToScreenPoint (obj.transform.position);
							offset = obj.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
							dragging = true;
							Debug.Log ("Object getto: " + obj.name);
						}
					}
				}
			}
		} else {

			if (Input.GetMouseButtonDown(1)) {
				//Debug.Log ("Object dropped: " + obj.name);
				falling = true;
			}

			if (falling == true) {
				Check();
			}

			if (dragging == true && falling == false) {
				Debug.Log ("Object dragged: " + obj.name);
				Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
				if (curPosition.y < 0.0f) {
					curPosition = new Vector3 (curPosition.x, 0.5f, curPosition.z);
				}
				obj.transform.position = curPosition;
				obj.rigidbody.velocity = Vector3.zero;
			}
		}

		if (numOfCorrect <= 0) {
			CursorMode cursorMode = CursorMode.Auto;
			Cursor.SetCursor (null, Vector2.zero, cursorMode);
			win = true;
			LevelLoader.WinLevel();
			Debug.Log ("Victory! Sang Nila Utama has reached Temasek!");
		}

		if (gameover == true) {
			LevelLoader.LoseLevel();
			Debug.Log("You Lose!");
		}
	}
	
	void Check() {
		if (obj != null) {
				Debug.Log ("The check: " + obj.name);
				Vector3 newVector = rightPlank.transform.position - obj.transform.position;
			
				float dotproduct = Vector3.Dot (newVector, rightPlank.transform.position);
			
				Vector3 newVector2 = leftPlank.transform.position - obj.transform.position;
			
				float dotproduct2 = Vector3.Dot (newVector2, leftPlank.transform.position);
			
			if ((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings> ().getActive () && obj.transform.position.y < -1.0f) {
					if (dotproduct < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 1) {
						AddCorrect ();
						UnspawnObj ();
						Debug.Log ("Right");
						falling = false;
						dragging = false;
					} else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 2) {
						AddCorrect ();
						UnspawnObj ();
						Debug.Log ("Left");
						falling = false;
						dragging = false;
					} else if (dotproduct < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 2) {
						Debug.Log ("Game Over! Suppose to be Left");
						UnspawnObj ();
						gameover = true;
						falling = false;
						dragging = false;
					} else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 1) {
						Debug.Log ("Game Over! Suppose to be Right");
						UnspawnObj ();
						gameover = true;
						falling = false;
						dragging = false;
					}
				} else if (((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings> ().getActive () == false) && obj.transform.position.y < -1.0f) {
					Debug.Log ("Game Over! Wronng Obj");
					UnspawnObj ();
					gameover = true;
					falling = false;
					dragging = false;
				}
			
			if ((dotproduct == 0 || dotproduct2 == 0) || (dotproduct > 0 && dotproduct2 > 0)) {
					Debug.Log ("Nope, either its still in or either on top");
					falling = false;
					dragging = false;
				}
			}
	}

	void UnspawnObj() {
		Debug.Log ("Unspawn");
		waterParticle = Instantiate (waterParticle, new Vector3 (obj.transform.position.x, obj.transform.position.y + 2.0f, obj.transform.position.z), Quaternion.identity) as GameObject;
		if (obj != null) {
			Debug.Log ("Object is destroyed");
			Destroy(obj);
			obj = null;
		}
		falling = false;
		dragging = false;
		audio.PlayOneShot (splash);
	}
	
	void AddCorrect() {
		--numOfCorrect;
	}
}
