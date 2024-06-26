using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseBulletSpeedLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
    [SerializeField] PowerUpsSO increaseBulletSpeedSO;

    private void OnEnable()
    {
        increaseBulletSpeedSO.currentStats = PlayerShootingData.Instance.GetBulletSpeed();
        increaseBulletSpeedSO.currentStats = PlayerShootingData.Instance.GetBulletSpeed() + 1.0f;

        currentStats.SetText(
            increaseBulletSpeedSO.powerUpStatsDetails,
            increaseBulletSpeedSO.currentStats,
            increaseBulletSpeedSO.upgradedStats);
    }
}
