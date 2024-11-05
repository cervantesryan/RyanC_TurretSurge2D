using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject bulletPrefab;
    public Transform fireBullet;
    public float fireForce = 20f;
    
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Fire(){
        GameObject bullet = Instantiate(bulletPrefab, fireBullet.position, fireBullet.rotation);
        audioManager.PlaySFX(audioManager.gunSound);
        bullet.GetComponent<Rigidbody2D>().AddForce(fireBullet.up * fireForce, ForceMode2D.Impulse);
    }

}
