using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNewShootingPoint : MonoBehaviour
{
	public void ActivateLeftShootingPoint()
	{
		PlayerShootingPointManager.Instance.ActivateShootingPointLeft();
		GameManager.Instance.ResumeGameAndHideLevelUpPanel();
	}

	public void ActivateRightShootingPoint()
	{
        PlayerShootingPointManager.Instance.ActivateShootingPointRight();
        GameManager.Instance.ResumeGameAndHideLevelUpPanel();
    }
}
