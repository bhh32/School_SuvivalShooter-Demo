using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpawnerStruct
{
	private float timer;
	public float Timer
	{
		set { timer = value; }
		get { return timer; }
	}

	private bool canSpawn;
	public bool CanSpawn
	{
		set { canSpawn = value; }
		get { return canSpawn; }
	}

	private Vector3 spawnLocation;
	public Vector3 SpawnLocation
	{
		set { spawnLocation = value; }
		get { return spawnLocation; }
	}
}

public class Spawner : MonoBehaviour
{
	public SpawnerStruct spawner = new SpawnerStruct();
	public float startTimer;
	[SerializeField] GameObject objectToSpawn;
	[SerializeField] PlayerHealth player;

	public float StartTimer
	{
		get { return startTimer; }
	}

	void Start()
	{
		spawner.Timer = startTimer;
		spawner.CanSpawn = true;
		spawner.SpawnLocation = transform.position;
	}

	void Update()
	{
		if (player.health > 0) 
		{
			spawner.Timer -= Time.deltaTime;

			Spawn (spawner.Timer);
		}
	}

	void Spawn(float spawnTime)
	{
		if(spawnTime <= 0f && spawner.CanSpawn)
		{
			GameObject newObj = Instantiate(objectToSpawn, spawner.SpawnLocation, Quaternion.identity) as GameObject;

			if (!newObj.CompareTag ("Enemy")) 
			{
				if(player.health < player.healthSlider.maxValue)
					newObj.transform.parent = gameObject.transform;
			}
			spawner.CanSpawn = false;
		}
	}
}
