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
            Instantiate(asteroidExlostionVFX, transform.position, Quaternion.identity);
            asteroid.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
