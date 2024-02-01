using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseGunFireRateLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
    [SerializeField] PowerUpsSO increaseGunFireRateSO;

    private void OnEnable()
    {
        increaseGunFireRateSO.currentStats = PlayerShooting.Instance.GetBulletFireRate();
        increaseGunFireRateSO.upgradedStats = PlayerShooting.Instance.GetBulletFireRate() - 0.1f;

        currentStats.SetText(
            increaseGunFireRateSO.powerUpStatsDetails,
            increaseGunFireRateSO.currentStats,
            increaseGunFireRateSO.upgradedStats);
    }
}
