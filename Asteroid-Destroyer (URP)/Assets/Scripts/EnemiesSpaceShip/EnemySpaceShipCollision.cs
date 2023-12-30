using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShipCollision : MonoBehaviour
{
    [SerializeField] GameObject enemySpaceShipExplosionVFX;
    [SerializeField] ShieldPickUp shieldPickUp;
    [SerializeField] HealthPickUp healthPickUp;
    [SerializeField] AudioClip enemySpaceShipDestroySFX;

    float shieldPickUpDropRate;
    float healthPickUpDropRate;

    private void OnEnable()
    {
        shieldPickUpDropRate = PickUpsDropRateManager.Instance.GetShieldPickUpDropRate();
        healthPickUpDropRate = PickUpsDropRateManager.Instance.GetHealthPickUpDropRate();
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleEnemySpaceShipCollisionWithOtherAsteroids(other);
        HandleEnemySpaceShipCollisionWithPlayer(other);
    }

    private void HandleEnemySpaceShipCollisionWithOtherAsteroids(Collider other)
    {
        if (other.GetComponent<EnemySpaceShipCollision>())
        {
            EnemySpaceShipDestroyedByOtherEnemySpaceShip();
        }
    }

    private void HandleEnemySpaceShipCollisionWithPlayer(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.DamagePlayer(1);
            EnemySpaceShipDestroyedByPlayer();
        }
    }

    private void EnemySpaceShipDestroyedByOtherEnemySpaceShip() => DestroyEnemySpaceShip();

    public void EnemySpaceShipDestroyedByPlayer()
    {
        SpawnShieldPickUp();
        SpawnHealthPickUp();
        IncrementScore();
        DestroyEnemySpaceShip();
    }

    private void DestroyEnemySpaceShip()
    {
        AudioManager.Instance.PlaySound(enemySpaceShipDestroySFX, 1f);
        Instantiate(enemySpaceShipExplosionVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private static void IncrementScore()
    {
        PlayerLevelUpManager.Instance.IncrementKilledEnemiesAndPlayerPoints();
        ScoreSystem.Instance.IncrementScore();
    }

    private void SpawnShieldPickUp()
    {
        if (Random.value < shieldPickUpDropRate)
        {
            ShieldPickUp shieldGameObject = GameObject.FindObjectOfType<ShieldPickUp>();

            if (shieldGameObject == null)
            {
                Instantiate(shieldPickUp, transform.position, shieldPickUp.transform.rotation);
            }
        }
    }

    private void SpawnHealthPickUp()
    {
        if (Random.value < healthPickUpDropRate)
        {
            HealthPickUp healthGameObject = GameObject.FindObjectOfType<HealthPickUp>();

            if (healthGameObject == null)
            {
                Instantiate(healthPickUp, transform.position, healthPickUp.transform.rotation);
            }
        }
    }
}
