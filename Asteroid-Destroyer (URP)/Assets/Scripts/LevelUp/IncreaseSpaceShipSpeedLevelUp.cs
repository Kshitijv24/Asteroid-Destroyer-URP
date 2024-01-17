using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseSpaceShipSpeedLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
	[SerializeField] PowerUpsSO increaseSpaceShipSpeedSO;

    private void OnEnable()
    {
        increaseSpaceShipSpeedSO.currentStats = PlayerMovement.Instance.GetPlayerForceMagnitude();
        increaseSpaceShipSpeedSO.upgradedStats = PlayerMovement.Instance.GetPlayerForceMagnitude() + 2;

        currentStats.SetText(
            increaseSpaceShipSpeedSO.powerUpStatsDetails,
            increaseSpaceShipSpeedSO.currentStats,
            increaseSpaceShipSpeedSO.upgradedStats);
    }
}