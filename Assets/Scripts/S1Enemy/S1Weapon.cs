using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Weapon : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject S1BulletPrefab;
    public Transform fireS1Bullet;
    public float fireForce = 15f;
    
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Fire(){
        GameObject S1bullet = Instantiate(S1BulletPrefab, fireS1Bullet.position, fireS1Bullet.rotation);
        audioManager.PlaySFX(audioManager.laserSound);
        S1bullet.GetComponent<Rigidbody2D>().AddForce(fireS1Bullet.up * fireForce, ForceMode2D.Impulse);
    }
}
