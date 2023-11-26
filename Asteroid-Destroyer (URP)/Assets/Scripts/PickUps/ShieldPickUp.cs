using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player)
        {
            PlayerShieldManager.Instance.ActivatePlayerShield();
            Destroy(gameObject);
        }
    }
}
