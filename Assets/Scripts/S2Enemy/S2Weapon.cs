using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Weapon : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject S2BulletPrefab;
    public Transform fireS2Bullet;
    public float fireForce = 20f;
    
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Fire(){
        GameObject S1bullet = Instantiate(S2BulletPrefab, fireS2Bullet.position, fireS2Bullet.rotation);
        audioManager.PlaySFX(audioManager.cannonSound);
        S1bullet.GetComponent<Rigidbody2D>().AddForce(fireS2Bullet.up * fireForce, ForceMode2D.Impulse);
    }
}
