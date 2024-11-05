using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public Score score;

    public void GameOverScreen()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        score.resetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        
    }

    public void LoadMenu()
    {
        score.resetScore();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
