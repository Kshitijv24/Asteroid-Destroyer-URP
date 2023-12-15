using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();

        if (asteroid == null) return;

        asteroid.AsteroidDestroyedByPlayer();
        gameObject.SetActive(false);
    }
}
