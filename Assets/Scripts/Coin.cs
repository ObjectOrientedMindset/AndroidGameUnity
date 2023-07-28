using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int spawnPoint = 0;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            int prevSpawnPoint = spawnPoint;
                while (spawnPoint == prevSpawnPoint)
                {
                    spawnPoint = Random.Range(0, spawnPoints.Length);
                }
                Transform randomSpawnPoint = spawnPoints[spawnPoint];
            coins++;
            Instantiate(gameObject, randomSpawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnApplicationQuit() {
        
    }
}
