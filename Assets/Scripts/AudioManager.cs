using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // getting player invincibility duration
    PlayerController player;

    [SerializeField] AudioSource SFXSource;
    public AudioClip gunSound;
    public AudioClip laserSound;
    public AudioClip cannonSound;
    public AudioClip EnemyHit;
    public AudioClip EnemyDead;
    public AudioClip Invincible;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void PlaySFX(AudioClip clip)
    {
        if (clip == Invincible)
        {
            StartCoroutine(PlayInvincibleSound(clip, player.invincibilityTime)); // Use player's invincibility time
        }
        else
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    private IEnumerator PlayInvincibleSound(AudioClip clip, float duration)
    {
        SFXSource.clip = clip;         // Assign the Invincible audio clip
        SFXSource.Play();              // Play the sound
        yield return new WaitForSeconds(duration); // Wait for the duration
        SFXSource.Stop();              // Stop the sound
    }
}
