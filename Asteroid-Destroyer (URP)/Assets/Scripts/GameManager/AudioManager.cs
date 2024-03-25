using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }

    [SerializeField] AudioClip enemySpaceShipDestroySFX;
    [SerializeField] AudioClip playerSpaceShipDeathSFX;
    [SerializeField] AudioClip asteroidDestroySFX;
    [SerializeField] AudioClip bulletSFX;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    public void PlaySound(AudioClip clip, float volumeLevel) => 
        audioSource.PlayOneShot(clip, volumeLevel);

    public void PlayAsteroidDestroyedSFX(float volumeLevel) => 
        audioSource.PlayOneShot(asteroidDestroySFX, volumeLevel);

    public void PlayEnemySpaceShipDestroyedSFX(float volumeLevel) => 
        audioSource.PlayOneShot(enemySpaceShipDestroySFX, volumeLevel);

    public void PlayPlayerShipDestroyedSFX(float volumeLevel) =>
        audioSource.PlayOneShot(playerSpaceShipDeathSFX, volumeLevel);

    public void PlayBulletSFX(float volumeLevel) =>
        audioSource.PlayOneShot(bulletSFX, volumeLevel);
}
