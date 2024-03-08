using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioClip bulletSFX;

    float nextFireTime;

    private void Update()
    {
        if (!CanFire()) return;

        FireBullet();
    }

    public bool CanFire() => Time.time >= nextFireTime;

    private void FireBullet()
    {
        AudioManager.Instance.PlaySound(bulletSFX, 0.3f);
        nextFireTime = Time.time + PlayerShootingData.Instance.GetBulletFireRate();

        GameObject pooledBulletsPrefab = PlayerBulletObjectPool.Instance.GetPooledGameObject();

        if (pooledBulletsPrefab != null)
        {
            pooledBulletsPrefab.transform.position = transform.position;
            pooledBulletsPrefab.transform.rotation = transform.rotation;

            pooledBulletsPrefab.SetActive(true);

            Rigidbody bulletRb = pooledBulletsPrefab.GetComponent<Rigidbody>();
            bulletRb.velocity = Vector3.zero;
            bulletRb.angularVelocity = Vector3.zero;
            bulletRb.AddForce(transform.forward * PlayerShootingData.Instance.GetBulletSpeed(), ForceMode.Impulse);
        }
    }
}
