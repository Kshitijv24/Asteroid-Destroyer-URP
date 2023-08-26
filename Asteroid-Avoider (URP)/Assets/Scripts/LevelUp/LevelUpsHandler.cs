using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpsHandler : MonoBehaviour
{
	[SerializeField] GameObject increaseBulletFireRateLevelUp;
    [SerializeField] GameObject increaseShipSpeedLevelUp;
    [SerializeField] GameObject increaseBulletSpeedLevelUp;

    private void Update()
    {
        LimitIncreaseOnBulletFireRate();
        LimitIncreaseOnShipSpeed();
        LimitIncreaseOnBulletSpeed();
    }

    private void LimitIncreaseOnBulletFireRate()
    {
        if (PlayerShooting.Instance.GetBulletFireRate() < 0.3)
        {
            increaseBulletFireRateLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseOnShipSpeed()
    {
        if(PlayerMovement.Instance.GetPlayerForceMagnitude() > 20)
        {
            increaseShipSpeedLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseOnBulletSpeed()
    {
        if(PlayerShooting.Instance.GetBulletSpeed() > 20)
        {
            increaseBulletSpeedLevelUp.SetActive(false);
        }
    }
}
