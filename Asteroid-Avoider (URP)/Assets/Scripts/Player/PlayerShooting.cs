using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting Instance { get; private set; }

	[SerializeField] Transform bulletSpawnPoint;
	[SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletFireRate;
    [SerializeField] float bulletMoveSpeed = 10f;
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

    public float GetBulletFireRate()
    {
        return bulletFireRate;
    }

    public void SetBulletFiringRate(float bulletFireRate)
    {
        this.bulletFireRate = bulletFireRate;
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
            bulletRb.AddForce(bulletSpawnPoint.forward * bulletMoveSpeed, ForceMode.Impulse);
        }
    }

}
