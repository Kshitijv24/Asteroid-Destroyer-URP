using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();
        EnemySpaceShipCollision enemySpaceShip = other.GetComponent<EnemySpaceShipCollision>();
        EnemyBulletCollision enemyBullet = other.GetComponent<EnemyBulletCollision>();

        if (asteroid != null)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }

        if (enemySpaceShip != null)
        {
            enemySpaceShip.EnemySpaceShipDestroyedByPlayer();
            gameObject.SetActive(false);
        }

        if(enemyBullet != null)
        {
            enemyBullet.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
