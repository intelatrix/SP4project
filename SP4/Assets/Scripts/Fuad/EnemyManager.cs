using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
	public float playerHealth;
	public int TCount;
	public static int TCheck;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	int amount = 0;


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);

		GameObject.Find ("TLeft").GetComponent<Text> ().text = "Enemies Left: " + (TCount);
		TCheck = TCount;
	}
	
	
	void Spawn ()
	{
		// If the player has no health left
		if(playerHealth <= 0f)
		{
			// exit the function.
			return;
		}


			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		amount++;

	}

	void Update(){

		GameObject.Find ("TLeft").GetComponent<Text> ().text = "Enemies Left: " + (TCheck);

		if (amount >= TCount) {
		CancelInvoke();
		}
	}
}
