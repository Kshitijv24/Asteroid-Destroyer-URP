using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreMultiplier;

    float score;
    bool shouldCount = true;

    private void Update()
    {
        if(!shouldCount) { return; }

        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int EndTimer()
    {
        shouldCount = false;
        scoreText.text = string.Empty;
        
        return Mathf.FloorToInt(score);
    }
}
