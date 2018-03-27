using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField] GameObject healthPack;


    float timer;
    bool canSpawn;

    public float Timer
    {
        set { timer = value; }
        get { return timer; }
    }

    public bool CanSpawn
    {
        set { canSpawn = value; }
        get { return canSpawn; }
    }
	// Use this for initialization
	void Start ()
    {
        timer = 10f;
        canSpawn = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Timer -= Time.deltaTime;
        Spawn(Timer);
	}

    void Spawn(float spawnTime)
    {
        if(spawnTime <= 0f && CanSpawn)
        {
			GameObject newPack = Instantiate(healthPack, transform.position, Quaternion.identity) as GameObject;
			newPack.transform.parent = gameObject.transform;
            CanSpawn = false;
        }
    }
}
