using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseGunFireRateLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
    [SerializeField] PowerUpsSO increaseGunFireRate;

    private void OnEnable()
    {
        increaseGunFireRate.currentStats = PlayerShootingFromUp.Instance.GetBulletFireRate();
        increaseGunFireRate.upgradedStats = PlayerShootingFromUp.Instance.GetBulletFireRate() - 0.1f;

        currentStats.SetText(
            increaseGunFireRate.powerUpStatsDetails,
            increaseGunFireRate.currentStats,
            increaseGunFireRate.upgradedStats);
    }
}
