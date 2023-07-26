using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject asteroidExlostionVFX;

    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();
        
        if(asteroid)
        {
            DestroyAsteroidAndBullet(asteroid);
        }
    }

    private void DestroyAsteroidAndBullet(Asteroid asteroid)
    {
        Instantiate(asteroidExlostionVFX, transform.position, Quaternion.identity);
        asteroid.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
