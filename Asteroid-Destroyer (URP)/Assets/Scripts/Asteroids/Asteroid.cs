using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosionVFX;
    [SerializeField] GameObject shieldPickUp;
    [SerializeField] float spawnChanceOfSpawningShieldPickUp;
    [SerializeField] AudioClip asteroidDestroySFX;

    private void OnTriggerEnter(Collider other)
    {
        HandleAsteroidCollisionWithOtherAsteroids(other);
        HandleAsteroidCollisionWithPlayer(other);
    }
    private void HandleAsteroidCollisionWithOtherAsteroids(Collider other)
    {
        if (other.GetComponent<Asteroid>())
        {
            AsteroidDestroyedByOtherAsteroid();
        }
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

    private void AsteroidDestroyedByOtherAsteroid()
    {
        PlayEffectsAndDisableAsteroid();
    }

    public void AsteroidDestroyedByPlayer()
    {
        SpawnShieldPickUp();
        IncrementScore();
        PlayEffectsAndDisableAsteroid();
    }

    private void PlayEffectsAndDisableAsteroid()
    {
        AudioManager.Instance.PlaySound(asteroidDestroySFX, 1f);
        Instantiate(asteroidExplosionVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private static void IncrementScore()
    {
        PlayerLevelUpManager.Instance.IncrementKilledEnemies();
        ScoreSystem.Instance.IncrementScore();
    }

    private void SpawnShieldPickUp()
    {
        if (Random.value < spawnChanceOfSpawningShieldPickUp)
        {
            Instantiate(shieldPickUp, transform.position, Quaternion.identity);
            Debug.Log("Shield Spawned");
        }
    }
}
