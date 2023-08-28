using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AsteroidSpawner asteroidSpawner;
    [SerializeField] TextMeshProUGUI gameOverText;

    public void ShowEndGameScreen()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.7f);
        asteroidSpawner.enabled = false;
        //int finalScore = scoreSystem.EndTimer();
        //gameOverText.text = $"Your Score: {finalScore}";
        gameOverDisplay.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
