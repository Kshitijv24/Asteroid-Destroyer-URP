using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestroyPlayerWithBullet(other);
    }

    private void DestroyPlayerWithBullet(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        PlayerBulletCollision playerBullet = other.GetComponent<PlayerBulletCollision>();

        if (player != null)
        {
            player.DamagePlayer(1);
            gameObject.SetActive(false);
        }

        if(playerBullet != null)
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
