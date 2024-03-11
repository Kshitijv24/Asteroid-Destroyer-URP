using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    [SerializeField] GameObject shieldPickUpParticleEffect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player)
        {
            PlayerShieldManager.Instance.ActivatePlayerShield();
            Instantiate(shieldPickUpParticleEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
