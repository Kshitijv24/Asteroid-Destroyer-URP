using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    [SerializeField] GameObject playerDeathVFX;
    [SerializeField] AudioClip playerSpaceShipDeathSFX;

    public void Crash()
    {
        AudioManager.Instance.PlaySound(playerSpaceShipDeathSFX);
        Instantiate(playerDeathVFX, transform.position, Quaternion.identity);
        gameOverHandler.ShowEndGameScreen();
        Destroy(gameObject);
    }
}
