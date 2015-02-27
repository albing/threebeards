﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 1f;
	public List<Transform> spawnPoints;
	public bool enableSpawning = false;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		var spawns = GameObject.FindGameObjectsWithTag ("enemyspawn");
		foreach (var spawn in spawns) 
		{
			spawnPoints.Add (spawn.transform);
		}
	}

	void Spawn () {
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
		enableSpawning = true;
	}

	void StopSpawning() 
	{
		enableSpawning = false;
	}
}
