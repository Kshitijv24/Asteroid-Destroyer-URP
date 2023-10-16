using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();

        if (asteroid == null) return;

        asteroid.AsteroidDestroyedByPlayer();
        gameObject.SetActive(false);
    }
}
