using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosionVFX;
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
        HandleAsteroidCollisionWithOtherAsteroids(other);
        HandleAsteroidCollisionWithPlayer(other);
    }

    private void HandleAsteroidCollisionWithOtherAsteroids(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();

        if (asteroid != null)
            DestroyAsteroid();
    }

    private void HandleAsteroidCollisionWithPlayer(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.DamagePlayer(1);
            AsteroidDestroyedByPlayer();
        }
    }

    public void AsteroidDestroyedByPlayer()
    {
        SpawnShieldPickUp();
        SpawnHealthPickUp();
        IncrementScore();
        DestroyAsteroid();
    }

    public void DestroyAsteroid()
    {
        AudioManager.Instance.PlayAsteroidDestroyedSFX(1f);
        Instantiate(asteroidExplosionVFX, transform.position, Quaternion.identity);
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
            ShieldPickUp shieldGameObject = FindObjectOfType<ShieldPickUp>();

            if(shieldGameObject == null)
            {
                Instantiate(shieldPickUp, transform.position, shieldPickUp.transform.rotation);
            }
        }
    }

    private void SpawnHealthPickUp()
    {
        if (Random.value < healthPickUpDropRate)
        {
            HealthPickUp healthGameObject = FindObjectOfType<HealthPickUp>();

            if (healthGameObject == null)
            {
                Instantiate(healthPickUp, transform.position, healthPickUp.transform.rotation);
            }
        }
    }
}
