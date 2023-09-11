using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpsLimiter : MonoBehaviour
{
	[SerializeField] GameObject increaseBulletFireRateLevelUp;
    [SerializeField] GameObject increaseShipSpeedLevelUp;
    [SerializeField] GameObject increaseBulletSpeedLevelUp;
    [SerializeField] GameObject increaseHealthPickUpDropRateLevelUp;
    [SerializeField] float maxBulletFireRate = 0.3f;
    [SerializeField] float maxPlayerShipSpeed = 16f;
    [SerializeField] float maxBulletSpeed = 15f;
    [SerializeField] float maxHealthPickUpDropRate = 0.4f;

    private void Update()
    {
        LimitIncreaseOnBulletFireRate();
        LimitIncreaseOnShipSpeed();
        LimitIncreaseOnBulletSpeed();
        LimitIncreaseDropRateOfHealthPickUp();
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

    public void LimitIncreaseDropRateOfHealthPickUp()
    {
        if(PickUpsDropRateManager.Instance.GetHealthPickUpDropRate() == maxHealthPickUpDropRate)
        {
            increaseHealthPickUpDropRateLevelUp.SetActive(false);
        }
    }
}
