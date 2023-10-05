using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletSpeedLevelUp : MonoBehaviour
{
	public void IncreaseBulletSpeed()
	{
		float bulletSpeedOfUp = PlayerShootingFromUp.Instance.GetBulletSpeed();
		float newBulletSpeed = PlayerShootingFromUp.Instance.SetBulletSpeed(bulletSpeedOfUp + 1.0f);

        if (PlayerShootingPointManager.Instance.IsShootingPointLeftActive())
		{
            PlayerShootingFromLeft.Instance.SetBulletSpeed(newBulletSpeed);
        }

        if (PlayerShootingPointManager.Instance.IsShootingPointRightActive())
        {
            PlayerShootingFromRight.Instance.SetBulletSpeed(newBulletSpeed);
        }
        
		GameManager.Instance.ResumeGame();
	}
}
