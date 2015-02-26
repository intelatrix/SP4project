using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckOutOfBound : MonoBehaviour {
    
    public GameObject rightPlank;
    public GameObject leftPlank;
	public GameObject timer;
    
    private GameObject obj = null;
    public int numOfCorrect = 2;

	public float time = 10.0f;

	private bool falling = false;
	private bool gameover = false;
	private bool win = false;

	public AudioClip splash;

	void Start() {
		numOfCorrect = GameObject.Find ("Spawner").GetComponent<Spawner> ().setCorrectNo;
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

		if (Input.GetMouseButtonDown (0) && GameObject.Find("Spawner").GetComponent<Spawner> ().control == true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "Obj") {
					obj = hit.collider.gameObject;
				}
			}
		}

		if (Input.GetMouseButtonUp (0) && GameObject.Find("Spawner").GetComponent<Spawner> ().control == true) {
			falling = true;
		}

		if (numOfCorrect > 0 && falling == true) {
			if (obj != null) {
				Vector3 newVector = rightPlank.transform.position - obj.transform.position;
				
				float dotproduct = Vector3.Dot (newVector, rightPlank.transform.position);
				
				Vector3 newVector2 = leftPlank.transform.position - obj.transform.position;
				
				float dotproduct2 = Vector3.Dot (newVector2, leftPlank.transform.position);

				//Play the splash sound in the next if statement

				if ((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings> ().getActive () && obj.transform.position.y < 0.2f) {

					if (dotproduct < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 1) {
						AddCorrect();
						Debug.Log ("Right");
						obj = null;
						falling = false;
						audio.PlayOneShot(splash);
					} else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 2) {
						AddCorrect();
						Debug.Log ("Left");
						obj = null;
						falling = false;
						audio.PlayOneShot(splash);
					} else if (dotproduct < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 2) {
						Debug.Log ("Game Over! Suppose to be Left");
						gameover = true;
						obj = null;
						falling = false;
						audio.PlayOneShot(splash);
					} else if (dotproduct2 < 0 && obj.GetComponent<ObjSettings> ().getLeftOrRight () == 1) {
						Debug.Log ("Game Over! Suppose to be Right");
						gameover = true;
						obj = null;
						falling = false;
						audio.PlayOneShot(splash);
					}
				} else if (((dotproduct < 0 || dotproduct2 < 0) && obj.GetComponent<ObjSettings> ().getActive () == false) && obj.transform.position.y < 0.2f) {
					Debug.Log ("Game Over!");
					gameover = true;
					obj = null;
					falling = false;
				}
			}
		}

		//Victory sound?
		if (numOfCorrect <= 0) {
			win = true;
			LevelLoader.WinLevel();
			Debug.Log ("Victory! Sang Nila Utama has reached Temasek!");
		}
	}

	void AddCorrect() {
		--numOfCorrect;
	}
}
