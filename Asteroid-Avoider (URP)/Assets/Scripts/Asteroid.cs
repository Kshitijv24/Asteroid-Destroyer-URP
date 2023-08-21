using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroidExlostionVFX;
    [SerializeField] AudioClip asteroidDestroySFX;
    [SerializeField] float targetFollowSpeed;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth == null) { return; }

        playerHealth.Crash();
    }

    public void DestroyAsteroid()
    {
        PlayerLevelUpManager.Instance.IncrementKilledEnemies();
        ScoreSystem.Instance.IncrementScore();
        AudioManager.Instance.PlaySound(asteroidDestroySFX, 1f);
        Instantiate(asteroidExlostionVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
