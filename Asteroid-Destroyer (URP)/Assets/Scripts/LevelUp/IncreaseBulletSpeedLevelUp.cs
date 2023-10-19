using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletSpeedLevelUp : MonoBehaviour
{
	public void IncreaseBulletSpeed()
	{
		float bulletSpeedOfUp = PlayerShootingFromUp.Instance.GetBulletSpeed();
		PlayerShootingFromUp.Instance.SetBulletSpeed(bulletSpeedOfUp + 1.0f);
        
		GameManager.Instance.ResumeGameAndHideLevelUpPanel();
	}
}
