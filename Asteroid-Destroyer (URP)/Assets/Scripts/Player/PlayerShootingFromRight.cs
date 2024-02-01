using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingFromRight : MonoBehaviour
{
    public static PlayerShootingFromRight Instance { get; private set; }

    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip bulletSFX;

    float nextFireTime;

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

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed && CanFire())
        {
            FireBullet();
        }
    }

    private bool CanFire() => Time.time >= nextFireTime;

    private void FireBullet()
    {
        AudioManager.Instance.PlaySound(bulletSFX, 0.1f);
        nextFireTime = Time.time + PlayerShooting.Instance.GetBulletFireRate();

        GameObject pooledBulletsPrefab = BulletObjectPool.Instance.GetPooledGameObject();

        if (pooledBulletsPrefab != null)
        {
            pooledBulletsPrefab.transform.position = bulletSpawnPoint.position;
            pooledBulletsPrefab.transform.rotation = bulletSpawnPoint.rotation;

            pooledBulletsPrefab.SetActive(true);

            Rigidbody bulletRb = pooledBulletsPrefab.GetComponent<Rigidbody>();
            bulletRb.velocity = Vector3.zero;
            bulletRb.angularVelocity = Vector3.zero;
            
            bulletRb.AddForce(
                bulletSpawnPoint.forward * 
                PlayerShooting.Instance.GetBulletSpeed(), 
                ForceMode.Impulse);
        }
    }
}
