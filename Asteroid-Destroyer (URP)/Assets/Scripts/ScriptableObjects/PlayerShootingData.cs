using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingData : MonoBehaviour
{
    public static PlayerShootingData Instance { get; private set; }

    [SerializeField] float bulletFireRate = 0.5f;
    [SerializeField] float bulletSpeed = 10f;

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

    private void OnEnable()
    {
        bulletFireRate = 0.5f;
        bulletSpeed = 10f;
    }

    public float GetBulletSpeed() => bulletSpeed;

    public float GetBulletFireRate() => bulletFireRate;

    public float SetBulletFiringRate(float bulletFireRate)
    {
        this.bulletFireRate = bulletFireRate;
        return bulletFireRate;
    }

    public float SetBulletSpeed(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
        return bulletSpeed;
    }
}
