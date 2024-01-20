using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseShieldPickUpDropRateLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
    [SerializeField] PowerUpsSO increaseShieldPickupDropRateSO;

    private void OnEnable()
    {
        increaseShieldPickupDropRateSO.currentStats = PickUpsDropRateManager.Instance.GetShieldPickUpDropRate();
        increaseShieldPickupDropRateSO.upgradedStats = PickUpsDropRateManager.Instance.GetShieldPickUpDropRate() + 0.1f;

        currentStats.SetText(
            increaseShieldPickupDropRateSO.powerUpStatsDetails,
            increaseShieldPickupDropRateSO.currentStats,
            increaseShieldPickupDropRateSO.upgradedStats);
    }
}
