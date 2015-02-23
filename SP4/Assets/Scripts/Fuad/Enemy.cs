using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public AudioClip enemyDeath;

	bool isDead;

	void Awake(){

		currentHealth = startingHealth;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage (int amount, Vector3 hitPoint){
		if (isDead) {
			
			audio.PlayOneShot (enemyDeath);

			return;
		}

		currentHealth -= amount;

		if (currentHealth <= 0) {
			isDead = true;

			Destroy(gameObject);
		}
	
	}


}
