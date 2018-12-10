using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{

    public int enemyCount;

    // Declare variables to hold our prefabs
    public GameObject[] enemies;

    #region EnemySpawn
    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        int spawnNumber = 0;
        if (GameManager.instance.difficulty == DifficultyLevel.EASY)
            spawnNumber = 1;
        if (GameManager.instance.difficulty == DifficultyLevel.MEDIUM)
            spawnNumber = 2;
        if (GameManager.instance.difficulty == DifficultyLevel.HARD)
            spawnNumber = 3;


            for (int i = 0; i < spawnNumber; i++)
            {
                // get random position
                Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, (Random.Range(-10, 10)));

                // Instantiate the (random) prefab at a random position
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, transform.rotation);
            }
        }
    #endregion

    private void OnEnable()
    {
        GameEvents.OnEnemyDie += OnEnemyDie;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDie -= OnEnemyDie;
    }

    void OnEnemyDie()
    {
        enemyCount--;
        SpawnEnemy();
    }
}
