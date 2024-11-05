using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // check if the game is paused
    public static bool GameIsPaused = false;
    // reference to the pause menu
    public GameObject pauseMenuUI;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    // resume the game
    public void Resume () {
        // disable the pause menu
        pauseMenuUI.SetActive(false);
        // set the time scale to 1
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // pause the game
    void Pause () {
        // enable the pause menu
        pauseMenuUI.SetActive(true);
        // set the time scale to 0
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu () {
        // set the time scale to 1
        Time.timeScale = 1f;
        // load the main menu
        SceneManager.LoadScene(0);
    }
}

