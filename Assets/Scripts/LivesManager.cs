using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    // get player life amount
    public PlayerController player;

    // heart vector for all lives
    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLives();
    }

    void UpdateLives()
    {
        int lives = player.GetLives();
        
        for (int i = 0; i < hearts.Length; i++){
            hearts[i].enabled = i < lives;
        }
    }
}
