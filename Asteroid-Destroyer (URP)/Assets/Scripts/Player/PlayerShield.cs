using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();
        EnemySpaceShipCollision enemySpaceShipCollision = other.GetComponent<EnemySpaceShipCollision>();

        if (asteroid != null)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }

        if (enemySpaceShipCollision != null)
        {
            enemySpaceShipCollision.EnemySpaceShipDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }
}
