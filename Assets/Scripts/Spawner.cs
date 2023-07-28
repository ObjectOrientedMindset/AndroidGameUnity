using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    //Difficulty adjustment
    public float minTimeBtwSpawns;
    public float decrease;

    public GameObject player;
    private int spawnPoint = 0;

    private void Start() {
    }

    private void Update()
    {
        if(player != null)
        {
            if (timeBtwSpawns <= 0)
            {
                // make sure the enemy spawns at a different spawn point each time
                int prevSpawnPoint = spawnPoint;
                while (spawnPoint == prevSpawnPoint)
                {
                    spawnPoint = Random.Range(0, spawnPoints.Length);
                }
                Transform randomSpawnPoint = spawnPoints[spawnPoint];
                GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

                //Spawn random enemy after wait time
                Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

                if (startTimeBtwSpawns > minTimeBtwSpawns)
                {
                    startTimeBtwSpawns -= decrease;
                }

                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }

}
