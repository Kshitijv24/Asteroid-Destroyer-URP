using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroidExlostionVFX;
    [SerializeField] AudioClip asteroidDestroySFX;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth == null) { return; }

        playerHealth.Crash();
    }

    public void DestroyAsteroid()
    {
        AudioManager.Instance.PlaySound(asteroidDestroySFX);
        Instantiate(asteroidExlostionVFX, transform.position, Quaternion.identity, transform);
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
