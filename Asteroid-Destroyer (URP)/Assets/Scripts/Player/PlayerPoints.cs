using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPoints : MonoBehaviour
{
    public static PlayerPoints Instance { get; private set; }

    [SerializeField] TextMeshProUGUI playerPointsText;

    int playerPoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    private void Start() => UpdatePlayerPointsTextUI();

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            playerPointsText.gameObject.SetActive(false);
        }
        else
        {
            UpdatePlayerPointsTextUI();
            playerPointsText.gameObject.SetActive(true);
        }
    }

    private void UpdatePlayerPointsTextUI()
    {
        playerPoints = GetPlayerPoints();
        playerPointsText.text = "Available Points: " + playerPoints.ToString();
    }

    public int GetPlayerPoints() => PlayerPrefs.GetInt("playerPoints", playerPoints);

    public void DecreasePlayerPoints(int points)
    {
        int currentPlayerPoints = PlayerPrefs.GetInt("playerPoints", playerPoints);
        currentPlayerPoints -= points;
        PlayerPrefs.SetInt("playerPoints", currentPlayerPoints);
    }

    public void AddPlayerPoints(int points)
    {
        int currentPlayerPoints = PlayerPrefs.GetInt("playerPoints", playerPoints);
        currentPlayerPoints += points;
        PlayerPrefs.SetInt("playerPoints", currentPlayerPoints);
    }

    public void IncrementPlayerPointByOne()
    {
        playerPoints++;
        PlayerPrefs.SetInt("playerPoints", playerPoints);
    }
}
