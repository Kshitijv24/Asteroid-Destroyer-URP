using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;
    [SerializeField] GameObject playerDeathVFX;

    public void Crash()
    {
        Instantiate(playerDeathVFX, transform.position, Quaternion.identity);
        gameOverHandler.ShowEndGameScreen();
        Destroy(gameObject);
    }
}
