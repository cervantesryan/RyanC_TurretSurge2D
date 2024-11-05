using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special1Enemy : MonoBehaviour
{
    // Audio
    AudioManager audioManager;

    // Enemy HP
    public int health = 250;

    // Move speed of enemy
    public float moveSpeed = 1.5f;
    public Rigidbody2D rb;

    // S1 Gun
    public S1Weapon s1weapon;
    public float timeBetweenShots = 5f;
    private float nextShotTime = 0f;

    // To find player
    private Transform player;

    // For level manager
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Taking damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        audioManager.PlaySFX(audioManager.EnemyHit);
        if (health <= 0)
        {
            Destroy(gameObject);
            audioManager.PlaySFX(audioManager.EnemyDead);
            // Tell the level manager that an enemy has been killed
            Debug.Log("Special 1 Enemy Killed");
            levelManager.EnemyKilled();
            Score.scoreValue += 500;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        MoveToPlayer();
        RotateTowardsPlayer();

        // Check if it's time to shoot
        if (Time.time >= nextShotTime)
        {
            ShootPlayer();
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    void MoveToPlayer()
    {
        // Find direction to player
        Vector2 moveDirection = (player.position - transform.position).normalized;
        // Move enemy
        rb.MovePosition((Vector2)transform.position + (moveDirection * moveSpeed * Time.deltaTime));
    }

    void RotateTowardsPlayer()
    {
        // Find direction to player
        Vector2 direction = (player.position - transform.position).normalized;
        // Find angle to player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Rotate enemy
        rb.rotation = angle - 90;
    }

    void ShootPlayer()
    {
        s1weapon.Fire();
    }
}

