using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    [SerializeField] GameObject playerDeathVFX;
    [SerializeField] ParticleSystem playerDamagedVFX;
    [SerializeField] AudioClip playerSpaceShipDeathSFX;
    [SerializeField] int playerHealthPoints = 3;

    public void DamagePlayer(int damageAmount)
    {
        AudioManager.Instance.PlaySound(playerSpaceShipDeathSFX, 1f);
        playerDamagedVFX.Play();
        playerHealthPoints -= damageAmount;

        if(playerHealthPoints <= 0)
        {
            Instantiate(playerDeathVFX, transform.position, Quaternion.identity);
            gameOverHandler.ShowEndGameScreen();
            Destroy(gameObject);
        }
    }
}
