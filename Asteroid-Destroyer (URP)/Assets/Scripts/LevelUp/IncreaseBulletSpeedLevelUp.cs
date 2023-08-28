using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletSpeedLevelUp : MonoBehaviour
{
	public void IncreaseBulletSpeed()
	{
		float bulletSpeed = PlayerShooting.Instance.GetBulletSpeed();
		PlayerShooting.Instance.SetBulletSpeed(bulletSpeed + 1.0f);
		GameManager.Instance.ResumeGame();
	}
}
