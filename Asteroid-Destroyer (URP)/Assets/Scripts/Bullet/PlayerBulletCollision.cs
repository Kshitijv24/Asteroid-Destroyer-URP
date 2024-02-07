using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestroyAsteroidWithBullet(other);
        DestroyEnemySpaceShipWithBullet(other);
    }

    private void DestroyAsteroidWithBullet(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();

        if (asteroid != null)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }

    private void DestroyEnemySpaceShipWithBullet(Collider other)
    {
        EnemySpaceShipCollision enemySpaceShip = other.GetComponent<EnemySpaceShipCollision>();

        if (enemySpaceShip != null)
        {
            enemySpaceShip.EnemySpaceShipDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }
}
