using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();

        if (asteroid)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }
}
