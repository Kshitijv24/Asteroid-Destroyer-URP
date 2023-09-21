using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNewShootingPoint : MonoBehaviour
{
	public void ActivateLeftShootingPoint()
	{
		PlayerShootingPointManager.Instance.ActivateShootingPointLeft();
		GameManager.Instance.ResumeGame();
	}

	public void ActivateRightShootingPoint()
	{
        PlayerShootingPointManager.Instance.ActivateShootingPointRight();
        GameManager.Instance.ResumeGame();
    }
}
