using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShipCollision : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpaceShipExplosionParticleEffectArray;
    [SerializeField] ShieldPickUp shieldPickUp;
    [SerializeField] HealthPickUp healthPickUp;

    float shieldPickUpDropRate;
    float healthPickUpDropRate;

    private void OnEnable()
    {
        shieldPickUpDropRate = PickUpsDropRateManager.Instance.GetShieldPickUpDropRate();
        healthPickUpDropRate = PickUpsDropRateManager.Instance.GetHealthPickUpDropRate();
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleEnemySpaceShipCollisionWithOtherEnemySpaceShip(other);
        HandleEnemySpaceShipCollisionWithPlayer(other);
    }

    private void HandleEnemySpaceShipCollisionWithOtherEnemySpaceShip(Collider other)
    {
        EnemySpaceShipCollision enemySpaceShip = other.GetComponent<EnemySpaceShipCollision>();

        if (enemySpaceShip != null)
            DestroyEnemySpaceShip();
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

    public void EnemySpaceShipDestroyedByPlayer()
    {
        SpawnShieldPickUp();
        SpawnHealthPickUp();
        IncrementScore();
        DestroyEnemySpaceShip();
    }

    public void DestroyEnemySpaceShip()
    {
        AudioManager.Instance.PlayEnemySpaceShipDestroyedSFX(1f);
        
        Instantiate(
            enemySpaceShipExplosionParticleEffectArray
            [Random.Range(0, enemySpaceShipExplosionParticleEffectArray.Length)], 
            transform.position, Quaternion.identity);

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
