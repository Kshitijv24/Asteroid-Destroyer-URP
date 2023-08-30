using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public static PlayerShield Instance { get; private set; }

    SpriteRenderer spriteRenderer;
    CapsuleCollider capsuleCollider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void ActivatePlayerShield()
    {
        spriteRenderer.enabled = true;
        capsuleCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();

        if (asteroid == null) return;

        asteroid.AsteroidDestroyedByPlayer();
    }
}
