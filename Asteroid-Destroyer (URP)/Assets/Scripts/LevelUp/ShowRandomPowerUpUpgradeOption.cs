using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRandomPowerUpUpgradeOption : MonoBehaviour
{
    [SerializeField] int numberOfPowerUpShownAtATime = 2;
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
        List<GameObject> selectedPowerUpsList = new List<GameObject>();

        while (selectedPowerUpsList.Count < numberOfPowerUpShownAtATime)
        {
            GameObject selectedPowerUp = allPowerUpsList[Random.Range(0, allPowerUpsList.Count)];

            if (!selectedPowerUpsList.Contains(selectedPowerUp))
            {
                selectedPowerUpsList.Add(selectedPowerUp);
                selectedPowerUp.SetActive(true);
            }
        }

        foreach (GameObject notSelectedPowerUp in selectedPowerUpsList)
        {
            if (!allPowerUpsList.Contains(notSelectedPowerUp))
            {
                notSelectedPowerUp.gameObject.SetActive(false);
            }
        }
    }
}
