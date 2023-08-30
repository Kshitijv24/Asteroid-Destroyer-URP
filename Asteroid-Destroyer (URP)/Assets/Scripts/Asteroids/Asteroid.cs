using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosionVFX;
    [SerializeField] AudioClip asteroidDestroySFX;
    [SerializeField] float targetFollowSpeed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>())
        {
            AsteroidDestroyedByOtherAsteroid();
        }

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth == null) { return; }

        playerHealth.DamagePlayer(1);
    }

    public void AsteroidDestroyedByOtherAsteroid()
    {
        AudioManager.Instance.PlaySound(asteroidDestroySFX, 1f);
        Instantiate(asteroidExplosionVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void AsteroidDestroyedByPlayer()
    {
        PlayerLevelUpManager.Instance.IncrementKilledEnemies();
        ScoreSystem.Instance.IncrementScore();
        AudioManager.Instance.PlaySound(asteroidDestroySFX, 1f);
        Instantiate(asteroidExplosionVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
