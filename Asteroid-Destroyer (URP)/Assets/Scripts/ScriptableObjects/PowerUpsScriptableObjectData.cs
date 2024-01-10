using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpsScriptableObjectDataSO", menuName = "ScriptableObjectFolder/IncreasePlayerForceMagnitudeSO")]
public class PowerUpsScriptableObjectData : ScriptableObject
{
    public string powerUPDetails;
    public float currentStats;
    public float upgradedStats;

    public void IncreasePlayerForceMagnitudeSO()
    {
        float playerForceMagnitude = PlayerMovement.Instance.GetPlayerForceMagnitude();
        PlayerMovement.Instance.SetPlayerForceMagnitude(playerForceMagnitude + 2.0f);

        GameManager.Instance.ResumeGameAndHideLevelUpPanel();
    }
}
