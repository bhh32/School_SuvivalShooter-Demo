using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
	[SerializeField] Spawner spawn;

    private int healthIncrease = 5;

    public int HealthIncrease
    {
        get { return healthIncrease; }
    }

    void Start()
    {
		spawn = transform.parent.GetComponent<Spawner> ();
    }

    void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (other.CompareTag("Player") && playerHealth != null)
        {
            playerHealth.IncreaseHealth(HealthIncrease);
            spawn.spawner.CanSpawn = true;
			spawn.spawner.Timer = spawn.StartTimer;
            Debug.Log("Health Increase: " + HealthIncrease);
            Destroy(gameObject);
        }
    }
}
