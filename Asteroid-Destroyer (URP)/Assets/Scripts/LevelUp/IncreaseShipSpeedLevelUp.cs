using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseShipSpeedLevelUp : MonoBehaviour
{
    public void IncreasePlayerForceMagnitude()
	{
        float playerForceMagnitude = PlayerMovement.Instance.GetPlayerForceMagnitude();
        PlayerMovement.Instance.SetPlayerForceMagnitude(playerForceMagnitude + 2.0f);

        GameManager.Instance.ResumeGame();
	}
}
