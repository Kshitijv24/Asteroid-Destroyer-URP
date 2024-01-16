using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseSO", menuName = "ScriptableObjectFolder/PowerUpsScriptableObjectDataSO")]
public class PowerUpsSO : ScriptableObject
{
    public string powerUpStatsDetails;
    public float currentStats;
    public float upgradedStats;

    public void IncreasePlayerSpaceShipSpeed()
    {
        float playerForceMagnitude = PlayerMovement.Instance.GetPlayerForceMagnitude();
        PlayerMovement.Instance.SetPlayerForceMagnitude(playerForceMagnitude + 2.0f);
        GameManager.Instance.ResumeGameAndHideLevelUpPanel();
    }

    public void IncreaseBulletFiringRate()
    {
        float firingRateOfUp = PlayerShootingFromUp.Instance.GetBulletFireRate();
        PlayerShootingFromUp.Instance.SetBulletFiringRate(firingRateOfUp - 0.1f);

        GameManager.Instance.ResumeGameAndHideLevelUpPanel();
    }
}
