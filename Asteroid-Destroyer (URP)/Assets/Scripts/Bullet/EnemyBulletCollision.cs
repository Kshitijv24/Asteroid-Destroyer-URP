using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] GameObject[] bulletCollisionParticleEffectArray;

    private void OnTriggerEnter(Collider other) => DestroyPlayerWithBullet(other);

    private void DestroyPlayerWithBullet(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        PlayerBulletCollision playerBullet = other.GetComponent<PlayerBulletCollision>();
        EnemyBulletCollision enemyBullet = other.GetComponent<EnemyBulletCollision>();

        if (player != null)
        {
            InstantiateBulletDestroyVFX();
            player.DamagePlayer(1);
        }
        else if (playerBullet != null)
            InstantiateBulletDestroyVFX();

        else if (enemyBullet != null)
            InstantiateBulletDestroyVFX();
    }

    public void InstantiateBulletDestroyVFX()
    {
        Instantiate(
            bulletCollisionParticleEffectArray[Random.Range(0, bulletCollisionParticleEffectArray.Length)],
            transform.position, transform.rotation);

        gameObject.SetActive(false);
    }
}
