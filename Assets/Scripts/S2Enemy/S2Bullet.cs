using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is tagged "Enemy"
        if (collision.gameObject.tag == "Enemy")
        {
            // Ignore collision with enemies
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            return; // Don't destroy the bullet
        }
        
        // Destroy the bullet for all other collisions
        Destroy(gameObject);
    }
}
