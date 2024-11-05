using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // audio
    AudioManager audioManager;

    // defaults for player
    public int pLives = 3;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon gun;
 
    public float fireRate = 0.05f;
    private float nextFire = 0.0f;

    // movement references
    private Vector2 movement;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Game Over screen
    public GameOver gameOver;

    // get sprite flash for invincibility when player is hit by enemy
    private SpriteFlash spriteFlash;
    public bool isInvincible = false;
    public float invincibilityTime = 3.0f;
    public Color flashColor = Color.white;
    public int numberOfFlashes = 10;


    // Debug.Log to check player lives on start
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteFlash = GetComponent<SpriteFlash>();
        Debug.Log("Player Lives: " + pLives);
    }
    
    private void FixedUpdate() {

        // firing gun
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            gun.Fire();
            nextFire = Time.time + fireRate;
        }
        
        // moving the turret
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        
    }

    // player taking damage when it makes contact with an enemy or its bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet") && !isInvincible)
        {
            PlayerDamage();
        }
    }

    public void PlayerDamage(){
        pLives -= 1;
        Debug.Log("Player Lives: " + pLives);   

        // swap to GAME OVER screen when player lives reach 0
        if (pLives <= 0){
            gameOver.GameOverScreen();
            return;
        }

        // player will flash when hit by enemy, and become invincible for a short time
        StartCoroutine(Invincibility(invincibilityTime, flashColor, numberOfFlashes));
        

    }

    // player is invincible for a short time after being hit by enemy
    public IEnumerator Invincibility(float invincibilityDuration, Color flashColor, int numberOfFlashes){

        isInvincible = true;
        audioManager.PlaySFX(audioManager.Invincible);
        yield return spriteFlash.FlashCoroutine(invincibilityDuration, flashColor, numberOfFlashes);
        isInvincible = false;

    }

    // get player life amount
    public int GetLives(){
        return pLives;
    }

}
