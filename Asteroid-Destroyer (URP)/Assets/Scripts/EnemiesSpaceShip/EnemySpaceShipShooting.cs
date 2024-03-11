using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemySpaceShipShooting : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletFireRate;
    [SerializeField] float nextFireTime;

    PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        LookAtPlayerSpaceShip();
        ShootAtThePlayer();
    }

    private void LookAtPlayerSpaceShip()
    {
        if(player == null) return;

        transform.LookAt(player.transform.position);
    }

    public bool CanFire() => Time.time >= nextFireTime;

    private void ShootAtThePlayer()
    {
        if(CanFire())
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        //AudioManager.Instance.PlaySound(bulletSFX, 0.3f);
        nextFireTime = Time.time + bulletFireRate;

        GameObject pooledBulletsPrefab = EnemyBulletObjectPool.Instance.GetPooledGameObject();

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
