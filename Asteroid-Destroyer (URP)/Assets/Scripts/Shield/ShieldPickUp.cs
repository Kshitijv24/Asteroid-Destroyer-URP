using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>())
        {
            PlayerShield.Instance.ActivatePlayerShield();
            Destroy(gameObject);
        }
    }
}
