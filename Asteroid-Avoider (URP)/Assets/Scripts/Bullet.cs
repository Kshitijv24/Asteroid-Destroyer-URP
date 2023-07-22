using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();
        
        if(asteroid)
        {
            asteroid.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
