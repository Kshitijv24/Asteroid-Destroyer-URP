using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] GameObject healthPickUpParticleEffect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        
        if (player)
        {
            PlayerHealth.Instance.IncrementPlayerHealth();
            Instantiate(healthPickUpParticleEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
