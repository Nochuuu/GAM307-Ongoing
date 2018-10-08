using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    /*
     * Use a coroutine to spawn enemy at random location
     * in game world every second
     * 
     * Spawn a random as above
     * 
     */
    
    //Declare variables to hold our prefabs
    public GameObject[] enemies;
    //int maxEnemyCount = 10;
    //int currentEnemyCount;
	// Use this for initialization
	void Start ()
    {
       // currentEnemyCount = 0;
       //StartCoroutine(SpawnEnemies());
        for (int i = 0; i < 5; i++)
        {
            // get random position
            Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, (Random.Range(-10, 10)));

            // Instantiate the (random) prefab at a random position
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, transform.rotation);
        }
	}







    /*
    IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemyCount)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-10, 10), 0, (Random.Range(-10, 10)));

            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, transform.rotation);

            yield return new WaitForSeconds(2);

            currentEnemyCount++;
        }

    }*/

}
