using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager> {

    public int enemyCount;

    //Declare variables to hold our prefabs
    public GameObject[] enemies;


    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
           for (int i = 0; i < 2; i++)
            {
                // get random position
                Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, (Random.Range(-10, 10)));

                // Instantiate the (random) prefab at a random position
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, transform.rotation);
            }
        }
    }
}
