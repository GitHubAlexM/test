﻿//Alexander Man
//File: EnemySpawner.cs
//Creation Date: Sept 28, 2015
// Description: Spawns the enemy.
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject EnemyGO;
	float maxSpawnRateInSeconds = 1.01f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SpawnEnemy()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max =  Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		GameObject anEnemy = (GameObject)Instantiate (EnemyGO);
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		ScheduleNextEnemySpawn ();

	}
	void ScheduleNextEnemySpawn ()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 1f) {
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else 
			spawnInNSeconds = 1f;
			Invoke ("SpawnEnemy", spawnInNSeconds);

	}
		void IncreasedSpawnRate()
		{
			if(maxSpawnRateInSeconds > 1f)
				maxSpawnRateInSeconds --;
			if(maxSpawnRateInSeconds == 1f)
				CancelInvoke("IncreasedSpawnRate");
		}
	public void ScheduleEnemySpawner()
	{
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}

	public void UnscheduledEnemeySpawner()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
	}
	}


