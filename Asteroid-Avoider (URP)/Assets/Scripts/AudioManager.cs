using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }

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
            Debug.Log("There are more than one AudioManager");
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip, float volumeLevel)
    {
        audioSource.PlayOneShot(clip, volumeLevel);
    }
}
