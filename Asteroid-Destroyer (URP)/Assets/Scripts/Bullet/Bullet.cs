using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();

        if (asteroid != null)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }
}
