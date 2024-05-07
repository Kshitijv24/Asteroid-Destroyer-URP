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
            player.DamagePlayer(1);
            gameObject.SetActive(false);
        }

        if(playerBullet != null)
        {
            InstantiateBulletDestroyVFX();
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if(enemyBullet != null)
        {
            InstantiateBulletDestroyVFX();
            gameObject.SetActive(false);
        }
    }

    public void InstantiateBulletDestroyVFX()
    {
        Instantiate(
            bulletCollisionParticleEffectArray[Random.Range(0, bulletCollisionParticleEffectArray.Length)],
            transform.position, transform.rotation);
    }
}
