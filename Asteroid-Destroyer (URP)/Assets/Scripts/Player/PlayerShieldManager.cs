using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldManager : MonoBehaviour
{
    public static PlayerShieldManager Instance { get; private set; }

    [SerializeField] PlayerShield playerShield;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    public void ActivatePlayerShield()
    {
        if(!playerShield.gameObject.activeSelf)
        {
            playerShield.gameObject.SetActive(true);
        }
    }
}
