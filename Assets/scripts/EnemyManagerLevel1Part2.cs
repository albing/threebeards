using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManagerLevel1Part2 : MonoBehaviour {
	
	public GameObject enemy;
	public float spawnTime = 1f;
	public List<Transform> spawnPoints;
	public bool enableSpawning = false;
	private static int maxScore = 1000;
	
	void Start () {
		if (Shoot.score < maxScore) {
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
			var spawns = GameObject.FindGameObjectsWithTag ("enemyspawn2");
			foreach (var spawn in spawns) {
				spawnPoints.Add (spawn.transform);
			}
		}
	}
	
	void Spawn () {
		if (Shoot.score > maxScore - 2) {
			StopSpawning ();
		}
		if ( enableSpawning )
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Count - 1);
			int secondSpawnPointIndex = Random.Range (0, spawnPoints.Count - 1);
			while(spawnPointIndex == secondSpawnPointIndex)
				secondSpawnPointIndex = Random.Range (0, spawnPoints.Count - 1);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			Instantiate (enemy, spawnPoints [secondSpawnPointIndex].position, spawnPoints [secondSpawnPointIndex].rotation);
		}
	}
	
	void StartSpawning()
	{
		maxScore = Shoot.score + 51;
		enableSpawning = true;
	}
	
	void StopSpawning() 
	{
		enableSpawning = false;
	}
}
