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
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletSpawnPoint.forward * bulletMoveSpeed, ForceMode.Impulse);
    }
}
