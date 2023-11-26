using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        
        if (player)
        {
            PlayerHealth.Instance.IncrementPlayerHealth();
            Destroy(gameObject);
        }
    }
}
