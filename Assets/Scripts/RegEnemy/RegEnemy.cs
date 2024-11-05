using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RegEnemy : MonoBehaviour
{

    // audio
    AudioManager audioManager;

    // enemy HP
    public int health = 50;

    // move speed of enemy
    public float moveSpeed = 3f;
    public Rigidbody2D rb;

    // to find player
    private Transform player;

    // for level manager
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // taking damage
    public void TakeDamage(int damage){
        health -= damage;
        audioManager.PlaySFX(audioManager.EnemyHit);
        if (health <= 0){
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.EnemyDead);
            // tell the level manager that an enemy has been killed
            levelManager.EnemyKilled();
            Score.scoreValue += 100;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        MoveToPlayer();
        RotateTowardsPlayer();
    }

    void MoveToPlayer(){
        // find direction to player
        Vector2 moveDirection = (player.position - transform.position).normalized;
        // move enemy
        rb.MovePosition((Vector2)transform.position + (moveDirection * moveSpeed * Time.deltaTime));
    }

    void RotateTowardsPlayer(){
        // find direction to player
        Vector2 direction = (player.position - transform.position).normalized;
        // find angle to player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // rotate enemy
        rb.rotation = angle;
    }
}
