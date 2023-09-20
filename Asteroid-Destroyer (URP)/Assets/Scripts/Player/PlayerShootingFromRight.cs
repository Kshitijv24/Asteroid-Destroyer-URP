using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingFromRight : MonoBehaviour
{
    public static PlayerShootingFromRight Instance { get; private set; }

    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletFireRate = 0.5f;
    [SerializeField] float bulletSpeed = 10f;
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
        }
    }

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed && CanFire())
        {
            FireBullet();
        }
    }

    public float GetBulletSpeed() => bulletSpeed;

    public float GetBulletFireRate() => bulletFireRate;

    public void SetBulletFiringRate(float bulletFireRate)
    {
        this.bulletFireRate = bulletFireRate;
    }

    public void SetBulletSpeed(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;
    }

    private bool CanFire() => Time.time >= nextFireTime;

    private void FireBullet()
    {
        AudioManager.Instance.PlaySound(bulletSFX, 0.3f);
        nextFireTime = Time.time + bulletFireRate;

        GameObject pooledBulletsPrefab = BulletObjectPool.Instance.GetPooledGameObject();

        if (pooledBulletsPrefab != null)
        {
            pooledBulletsPrefab.transform.position = bulletSpawnPoint.position;
            pooledBulletsPrefab.transform.rotation = bulletSpawnPoint.rotation;

            pooledBulletsPrefab.SetActive(true);

            Rigidbody bulletRb = pooledBulletsPrefab.GetComponent<Rigidbody>();
            bulletRb.velocity = Vector3.zero;
            bulletRb.angularVelocity = Vector3.zero;
            bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        }
    }
}
