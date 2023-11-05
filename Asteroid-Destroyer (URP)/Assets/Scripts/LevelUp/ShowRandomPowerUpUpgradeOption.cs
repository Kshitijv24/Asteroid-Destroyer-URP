using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRandomPowerUpUpgradeOption : MonoBehaviour
{
    [SerializeField] int numberOfPowerUpShownAtATime = 3;
    [SerializeField] List<GameObject> allPowerUpsList;

    private void OnEnable()
    {
        DisableAllPowerUpsAtTheStart();
        ShowRandomPowerUp();
    }

    private void DisableAllPowerUpsAtTheStart()
    {
        foreach (GameObject powerUp in allPowerUpsList)
        {
            powerUp.SetActive(false);
        }
    }

    private void ShowRandomPowerUp()
    {
        // Shuffle the list of power-ups to make the selection random
        List<GameObject> shuffledPowerUps = new List<GameObject>(allPowerUpsList);
        int n = shuffledPowerUps.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject powerUp = shuffledPowerUps[k];
            shuffledPowerUps[k] = shuffledPowerUps[n];
            shuffledPowerUps[n] = powerUp;
        }

        // Determine the number of power-ups to show (up to numberOfPowerUpShownAtATime)
        int powerUpsToShow = Mathf.Min(numberOfPowerUpShownAtATime, shuffledPowerUps.Count);

        // Show exactly numberOfPowerUpShownAtATime power-ups
        for (int i = 0; i < numberOfPowerUpShownAtATime; i++)
        {
            if (i < powerUpsToShow)
            {
                GameObject selectedPowerUp = shuffledPowerUps[i];
                selectedPowerUp.SetActive(true);
            }
        }
    }
}
