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

    private void Update()
    {
        if(player != null)
        {
            if (timeBtwSpawns <= 0)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
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
