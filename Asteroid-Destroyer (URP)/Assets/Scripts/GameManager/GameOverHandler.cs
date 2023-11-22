using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AsteroidSpawner asteroidSpawner;
    [SerializeField] TextMeshProUGUI endScreenScoreCard;

    public void ShowEndGameScreen() => StartCoroutine(EndGame());

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.7f);
        asteroidSpawner.enabled = false;
        endScreenScoreCard.text = $"Your Score is : {ScoreSystem.Instance.score.ToString()}" ;
        gameOverDisplay.SetActive(true);
    }

    public void PlayAgain() => SceneManager.LoadScene(2);

    public void ReturnToMenu() => SceneManager.LoadScene(0);
}
