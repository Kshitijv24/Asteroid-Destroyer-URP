using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosionVFX;
    [SerializeField] ShieldPickUp shieldPickUp;
    [SerializeField] HealthPickUp healthPickUp; 
    [SerializeField] float spawnChanceOfShieldPickUp;
    [SerializeField] float spawnChanceOfHealthPickUp;
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
        SpawnHealthPickUp();
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
        if (Random.value < spawnChanceOfShieldPickUp)
        {
            Instantiate(shieldPickUp, transform.position, Quaternion.identity);
        }
    }

    private void SpawnHealthPickUp()
    {
        if (Random.value < spawnChanceOfHealthPickUp)
        {
            Instantiate(healthPickUp, transform.position, Quaternion.identity);
        }
    }
}
