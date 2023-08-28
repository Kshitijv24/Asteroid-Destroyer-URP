using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [HideInInspector] public int score;

    [SerializeField] TextMeshProUGUI scoreText;

    public static ScoreSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public TextMeshProUGUI GetScoreTextUI() => scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = $"Enemies Killed: {score}";
    }
}
