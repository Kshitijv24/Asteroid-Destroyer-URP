using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public float elapsedTime = 0.0f;

    float timeToWait = 5.0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= timeToWait)
        {
            elapsedTime = 0.0f;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();

        if (asteroid == null) return;

        asteroid.AsteroidDestroyedByPlayer();
    }
}
