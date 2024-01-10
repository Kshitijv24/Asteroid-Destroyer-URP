using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpsDemoSO : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentStats;
	[SerializeField] PowerUpsScriptableObjectData powerUpsScriptableObjectData;

    private void OnEnable()
    {
        powerUpsScriptableObjectData.currentStats = PlayerMovement.Instance.GetPlayerForceMagnitude();
        powerUpsScriptableObjectData.upgradedStats = PlayerMovement.Instance.GetPlayerForceMagnitude() + 2;

        currentStats.SetText(
            powerUpsScriptableObjectData.powerUPDetails,
            powerUpsScriptableObjectData.currentStats,
            powerUpsScriptableObjectData.upgradedStats);
    }
}
