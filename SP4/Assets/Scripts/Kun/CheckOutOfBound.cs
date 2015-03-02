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

	public float time = 10.0f;

	private bool falling = false;
	private bool gameover = false;
	private bool win = false;

	public AudioClip splash;

	void Start() {
		if (LevelLoader.GetRound() == 1) {
			numOfCorrect = 2;
		} else if (LevelLoader.GetRound() == 2) {
			numOfCorrect = 3;
		} else if (LevelLoader.GetRound () >= 3) {
			numOfCorrect = 4;
		}
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

		if (Input.GetMouseButtonDown(0) && GameObject.Find("Spawner").GetComponent<Spawner> ().control == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "Obj") {
					obj = hit.collider.gameObject;
				}
			}
		}

		if (Input.GetMouseButtonUp(0) && GameObject.Find("Spawner").GetComponent<Spawner> ().control == true) {
			falling = true;
		}

		if (falling == true) {
			if (obj != null) {
				Vector3 newVector = rightPlank.transform.position - obj.transform.position;
				
				float dotproduct = Vector3.Dot (newVector, rightPlank.transform.position);
				
				Vector3 newVector2 = leftPlank.transform.position - obj.transform.position;
				
				float dotproduct2 = Vector3.Dot (newVector2, leftPlank.transform.position);

				//Play the splash sound in the next if statement

				if ((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings> ().getActive () && obj.transform.position.y < 0.2f) {
					if (dotproduct < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 1) {
						AddCorrect();
						UnspawnObj();
						Debug.Log ("Right");
					} else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 2) {
						AddCorrect();
						UnspawnObj();
						Debug.Log ("Left");
					} else if (dotproduct < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 2) {
						Debug.Log ("Game Over! Suppose to be Left");
						UnspawnObj();
						gameover = true;
					} else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 1) {
						Debug.Log ("Game Over! Suppose to be Right");
						UnspawnObj();
						gameover = true;
					}
				} else if (((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings>().getActive() == false) && obj.transform.position.y < 0.2f) {
					Debug.Log ("Game Over!");
					UnspawnObj();
					gameover = true;
				}
			}
		}


		//Victory sound?
		if (numOfCorrect <= 0) {
			win = true;
			LevelLoader.WinLevel();
			Debug.Log ("Victory! Sang Nila Utama has reached Temasek!");
		}

		if (gameover == true) {
			LevelLoader.LoseLevel();
			Debug.Log("You Lose!");
		}
	}

	void UnspawnObj() {
		waterParticle = Instantiate (waterParticle, new Vector3 (obj.transform.position.x, obj.transform.position.y + 2.0f, obj.transform.position.z), Quaternion.identity) as GameObject;
		Destroy (obj);
		falling = false;
		audio.PlayOneShot (splash);
	}

	void AddCorrect() {
		--numOfCorrect;
	}
}
