using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandEnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public int maxEnemies = 5; // Maximum number of enemies that can be spawned at a time
    public float spawnInterval = 1f; // Time interval between enemy spawns in seconds

    private int currentEnemyCount = 0;

    void Start()
    {
        // Start the coroutine to spawn enemies automatically
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // Spawn enemies as long as the current enemy count is less than the maximum limit
        while (currentEnemyCount < maxEnemies)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            currentEnemyCount++; // Increase the count of spawned enemies

            yield return new WaitForSeconds(spawnInterval); // Wait for the specified spawn interval
        }
    }

    // Call this method when an enemy is destroyed to decrease the enemy count
    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }
}