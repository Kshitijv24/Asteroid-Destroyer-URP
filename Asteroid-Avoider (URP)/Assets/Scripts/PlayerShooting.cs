using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] Transform bulletSpawnPoint;
	[SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletFireRate;
    [SerializeField] float bulletMoveSpeed = 10f;

    float nextFireTime;

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
