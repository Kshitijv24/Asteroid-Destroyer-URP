using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsText;
    
    float poolingTime = 1f;
    float time;
    int frameCount;

    private void Start()
    {
        Application.targetFrameRate = 600;
    }

    private void Update()
    {
        time += Time.unscaledDeltaTime;
        frameCount++;

        if(time >= poolingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = "FPS: " + frameRate.ToString();

            time -= poolingTime;
            frameCount = 0;
        }
    }
}
