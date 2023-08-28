using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpsLimiter : MonoBehaviour
{
	[SerializeField] GameObject increaseBulletFireRateLevelUp;
    [SerializeField] GameObject increaseShipSpeedLevelUp;
    [SerializeField] GameObject increaseBulletSpeedLevelUp;
    [SerializeField] float maxBulletFireRate = 0.3f;
    [SerializeField] float maxPlayerShipSpeed = 20f;
    [SerializeField] float maxBulletSpeed = 15f;

    private void Update()
    {
        LimitIncreaseOnBulletFireRate();
        LimitIncreaseOnShipSpeed();
        LimitIncreaseOnBulletSpeed();
    }

    private void LimitIncreaseOnBulletFireRate()
    {
        if (PlayerShooting.Instance.GetBulletFireRate() == maxBulletFireRate)
        {
            increaseBulletFireRateLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseOnShipSpeed()
    {
        if(PlayerMovement.Instance.GetPlayerForceMagnitude() == maxPlayerShipSpeed)
        {
            increaseShipSpeedLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseOnBulletSpeed()
    {
        if(PlayerShooting.Instance.GetBulletSpeed() == maxBulletSpeed)
        {
            increaseBulletSpeedLevelUp.SetActive(false);
        }
    }
}
