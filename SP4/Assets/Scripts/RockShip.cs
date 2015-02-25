using UnityEngine;
using System.Collections;

public class RockShip : MonoBehaviour {

	public GameObject ship;

	private int startRotate = 0;
	private float randomChance = 0.0f;
	private float angle = 0.1f;
	private float maxAngle = 10.0f;
	private bool turn = false;

	// Update is called once per frame
	void Update () {
		if (turn == false) {
			randomChance = Random.Range (0.0f, 100.0f);
			if (randomChance <= 40.0f) {
				startRotate = 1;
				turn = true;
			} else if (randomChance >= 60.0f) {
				startRotate = 2;
				turn = true;
			} else {
				startRotate = 0;
			}
		}


		RotateShip ();
	}

	void RotateShip() {
		if (startRotate == 1 && turn) {
			transform.Rotate (new Vector3 (0.0f, 0.0f, 1.0f), angle);
		}

		if (startRotate == 2 && turn) {
			transform.Rotate (new Vector3 (0.0f, 0.0f, 1.0f), -angle);
		}

		if (transform.eulerAngles.z > 3.0f || transform.eulerAngles.z < -3.0f) {
			turn = false;
		}
	}
}
