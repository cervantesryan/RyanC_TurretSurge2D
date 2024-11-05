using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // this code is primarily to manage the level based on enemies remaining
    // it will be used to spawn enemies, and to determine when the level is over
    // and the player has won

    // each spawner will spawn this amount
    public int enemyCount = 1;
    public int special1Count = 2;
    public int special2Count = 1;

    // reg enemy HP
    //public int health = 50;

    // special enemy 1 hp
    //public int special1Health = 250;

    // keeps track of the number of enemies that have been spawned
    private int activeEnemies = 0;

    // used for moving to next level
    public LevelOver levelOver;
    public GameCompleted gameCompleted;

    // score for resetting
    public Score score;

    public void EnemySpawned()
    {
        activeEnemies++;
    }

    public void EnemyKilled()
    {
        activeEnemies--;
        Debug.Log(activeEnemies);
        if (activeEnemies == 0 && SceneManager.GetActiveScene().buildIndex != 3)
        {
            // all enemies are dead, level is over
            
            Debug.Log("Level Over");
            levelOver.LevelOverScreen();
        }
        else if (activeEnemies == 0 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            // all enemies are dead, level is over
            Debug.Log("Game Completed");
            gameCompleted.GameCompletedScreen();
        }
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public int GetSpecial1Count()
    {
        return special1Count;
    }

    public int GetSpecial2Count()
    {
        return special2Count;
    }
    // checking if levelOver is assigned
    void Awake()
    {
        // level 1 -> score reset to 0
        if (SceneManager.GetActiveScene().buildIndex == 1) score.resetScore();
    }
    
}
