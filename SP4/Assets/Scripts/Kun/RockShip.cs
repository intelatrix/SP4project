using UnityEngine;
using System.Collections;

public class RockShip : MonoBehaviour {

	public GameObject ship;

	private int startRotate = 0;
	private float randomChance = 0.0f;
	private float angle = 0.06f;
	private bool turn = false;

	//Play ship rocking sound if possible
	// Update is called once per frame
	void Update () {
		if (turn == false) {
			randomChance = Random.Range (0.0f, 100.0f);
			if (randomChance <= 30.0f) {
				startRotate = 1;
				turn = true;
			} else if (randomChance >= 70.0f) {
				startRotate = 2;
				turn = true;
			} else {
				startRotate = 0;
			}
		}


		RotateShip ();
	}

	void RotateShip() {
		if ((transform.rotation.z > 0.03f && startRotate == 1)|| (transform.rotation.z < -0.03f && startRotate == 2)) {
			turn = false;
		}

		if (startRotate == 1 && turn) {
			//transform.Rotate(new Vector3 (0.0f, 0.0f, 1.0f), angle);
		}

		if (startRotate == 2 && turn) {
			//transform.Rotate(new Vector3 (0.0f, 0.0f, 1.0f), -angle);
		}
	}
}
