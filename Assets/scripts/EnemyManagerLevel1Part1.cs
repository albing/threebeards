using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManagerLevel1Part1 : MonoBehaviour {
	
	public GameObject enemy;
	public GameObject Trees1;
	public GameObject Trees2;
	public GameObject Trees3;
	private GameObject rodTrig;
	public float spawnTime = 1f;
	public List<Transform> spawnPoints;
	public bool enableSpawning = false;
	private Object tree1;
	private Object tree2;
	private Object tree3;
	public bool lightIlluminated;
	private static int maxScore = 1000;
	
	void Start () {
		rodTrig = GameObject.FindGameObjectWithTag ("rockofdoomtrigger1");
		lightIlluminated = false;
		if (Shoot.score < maxScore) {
						tree1 = Instantiate (Trees1);
						tree2 = Instantiate (Trees2);
						tree3 = Instantiate (Trees3);
						InvokeRepeating ("Spawn", spawnTime, spawnTime);
						var spawns = GameObject.FindGameObjectsWithTag ("enemyspawn");
						foreach (var spawn in spawns) {
								spawnPoints.Add (spawn.transform);
						}
				}
	}
	
	void Spawn () {
		if (Shoot.score > maxScore - 2) {
			if (!lightIlluminated)
			{
				StopSpawning ();
				DestroyObject (tree1);
				DestroyObject (tree2);
				DestroyObject (tree3);
				rodTrig.SendMessage ("BeatSection");
				KillsRemainingUpdater.KillsRemainingText.SetActive (false);
				Shoot.killsRemaining = 50;
			}
			lightIlluminated = true;
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
