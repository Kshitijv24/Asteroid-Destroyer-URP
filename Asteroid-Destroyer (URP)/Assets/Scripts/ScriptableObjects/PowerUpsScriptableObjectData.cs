using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpsScriptableObjectDataSO", menuName = "ScriptableObjectFolder/IncreasePlayerForceMagnitudeSO")]
public class PowerUpsScriptableObjectData : ScriptableObject
{
    public TextMeshProUGUI currentStats;

    //private void OnEnable()
    //{
    //    currentStats.text = "Current SpaceShip Speed: " + PlayerMovement.Instance.GetPlayerForceMagnitude();
    //}

    public void IncreasePlayerForceMagnitudeSO()
    {
        float playerForceMagnitude = PlayerMovement.Instance.GetPlayerForceMagnitude();
        PlayerMovement.Instance.SetPlayerForceMagnitude(playerForceMagnitude + 2.0f);

        GameManager.Instance.ResumeGameAndHideLevelUpPanel();
    }
}
