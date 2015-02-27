using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
	public float playerHealth;
	public int TCount;
	public static int TCheck;
	int TSpawnCheck;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	int[] spawnCheck;
	bool spawnUsed;
//	int amount = 0;


	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
//		InvokeRepeating ("Spawn", spawnTime, spawnTime);

		spawnCheck = new int[100];
	


		GameObject.Find ("TLeft").GetComponent<Text> ().text = "Enemies Left: " + (TCount);
		TCheck = TCount;
		TSpawnCheck = TCount;

		Spawn ();
	}
	
	
	void Spawn ()
	{
		// If the player has no health left
		if(playerHealth <= 0f)
		{
			// exit the function.
			return;
		}

		spawnCheck [0] = 100;

		
					
		for (int i = 0; i < TSpawnCheck; ++i) {
			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			spawnUsed = false;

			for (int j = 0; j < i; ++j){
				if (spawnCheck[j] == spawnPointIndex){
					spawnUsed = true;
				}

			}

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			if (!spawnUsed){
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				spawnCheck[i] = spawnPointIndex;
			}

			else
				++TSpawnCheck;


		}



		//amount++;

	}

	void Update(){

		GameObject.Find ("TLeft").GetComponent<Text> ().text = "Enemies Left: " + (TCheck);

//		if (amount >= TCount) {
//		CancelInvoke();
//		}
	}
}
