using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();

        if (asteroid != null)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }
}
