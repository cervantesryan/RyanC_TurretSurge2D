using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 25;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a RegEnemy component
        RegEnemy regEnemy = collision.gameObject.GetComponent<RegEnemy>();
        if (regEnemy != null)
        {
            regEnemy.TakeDamage(bulletDamage);
        }
        
        // Check if the collided object has a Special1Enemy component
        Special1Enemy specialEnemy1 = collision.gameObject.GetComponent<Special1Enemy>();
        Special2Enemy specialEnemy2 = collision.gameObject.GetComponent<Special2Enemy>();
        
        if (specialEnemy1 != null)
        {
            specialEnemy1.TakeDamage(bulletDamage);
        }
        if (specialEnemy2 != null)
        {
            specialEnemy2.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
