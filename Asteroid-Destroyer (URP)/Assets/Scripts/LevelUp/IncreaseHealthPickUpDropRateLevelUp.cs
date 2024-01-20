using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseHealthPickUpDropRateLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
    [SerializeField] PowerUpsSO increaseHealthPickupDropRateSO;

    private void OnEnable()
    {
        increaseHealthPickupDropRateSO.currentStats = PickUpsDropRateManager.Instance.GetHealthPickUpDropRate();
        increaseHealthPickupDropRateSO.upgradedStats = PickUpsDropRateManager.Instance.GetHealthPickUpDropRate() + 0.1f;

        currentStats.SetText(
            increaseHealthPickupDropRateSO.powerUpStatsDetails,
            increaseHealthPickupDropRateSO.currentStats,
            increaseHealthPickupDropRateSO.upgradedStats);
    }
}
