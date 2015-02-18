using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 1.0f;

	// Update is called once per frame
	void Update () {

		transform.Translate (0, 0, speed);

	}
}
