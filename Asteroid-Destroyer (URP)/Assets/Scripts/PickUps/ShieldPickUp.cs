using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>())
        {
            PlayerShieldManager.Instance.ActivatePlayerShield();
            Destroy(gameObject);
        }
    }
}
