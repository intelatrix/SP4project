using UnityEngine;
using UnityEngine.UI;

public class CivilianManager : MonoBehaviour
{
	public float playerHealth;
	public int CCount;
	public static int CCheck;
	int CSpawnCheck;
	public GameObject Civilian;                // The enemy prefab to be spawned.
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


		int multiplier = LevelLoader.GetRound ();

		CCount = CCount * multiplier;

		CCheck = CCount;
		CSpawnCheck = CCount;
		
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
		
		
		
		for (int i = 0; i < CSpawnCheck; ++i) {
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
				Instantiate (Civilian, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				spawnCheck[i] = spawnPointIndex;
			}
			
			else
				++CSpawnCheck;
			
			
		}
		
		
		
		//amount++;
		
	}
	
	void Update(){
		

	}
}
