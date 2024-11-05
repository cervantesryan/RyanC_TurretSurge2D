using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Spawn : MonoBehaviour
{

    // prefab of regular enemy
    public GameObject enemyPrefab;
    // spawn time of enemy
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 6f;
    // amount of enemies to spawn from LevelManager
    public LevelManager levelManager;
    public int S1EnemyCount;

    private int spawnedEnemies = 0; // Tracks the number of spawned enemies
    private float nextSpawnTime = 0f; // Time for the next spawn


    void Start(){
        // Get the LevelManager component from the LevelManager object
        levelManager = FindObjectOfType<LevelManager>();
        S1EnemyCount = levelManager.GetSpecial1Count();

        //Debug.Log("Enemy Count: " + enemyCount);
    }

    void FixedUpdate()
    {
        // Only spawn if we haven't reached the enemy count
        if (spawnedEnemies < S1EnemyCount && Time.time >= nextSpawnTime)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0,0,90)); // Spawn the enemy at spawner's position
            spawnedEnemies++; // Increase the count of spawned enemies

            // Set the next spawn time based on a random range
            nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);

            // Tell the LevelManager that an enemy has been spawned
            levelManager.EnemySpawned();
        }
    }
}
