using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpsLimiter : MonoBehaviour
{
	[SerializeField] GameObject increaseBulletFireRateLevelUp;
    [SerializeField] GameObject increaseShipSpeedLevelUp;
    [SerializeField] GameObject increaseBulletSpeedLevelUp;
    [SerializeField] GameObject increaseHealthPickUpDropRateLevelUp;
    [SerializeField] GameObject increaseShieldPickUpDropRateLevelUp;
    [SerializeField] GameObject shootingPointRight;
    [SerializeField] GameObject shootingPointLeft;
    [SerializeField] float maxBulletFireRate = 0.3f;
    [SerializeField] float maxPlayerShipSpeed = 16f;
    [SerializeField] float maxBulletSpeed = 15f;
    [SerializeField] float maxHealthPickUpDropRate = 0.4f;
    [SerializeField] float maxShieldPickUpDropRate = 0.4f;

    private void Update()
    {
        LimitIncreaseOnBulletFireRate();
        LimitIncreaseOnShipSpeed();
        LimitIncreaseOnBulletSpeed();
        LimitIncreaseDropRateOfHealthPickUp();
        LimitIncreaseDropRateOfShieldPickUp();
        LimitShootingPoints();
    }

    private void LimitIncreaseOnBulletFireRate()
    {
        if (PlayerShootingFromUp.Instance.GetBulletFireRate() == maxBulletFireRate)
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(increaseBulletFireRateLevelUp);
            increaseBulletFireRateLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseOnShipSpeed()
    {
        if(PlayerMovement.Instance.GetPlayerForceMagnitude() == maxPlayerShipSpeed)
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(increaseShipSpeedLevelUp);
            increaseShipSpeedLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseOnBulletSpeed()
    {
        if(PlayerShootingFromUp.Instance.GetBulletSpeed() == maxBulletSpeed)
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(increaseBulletSpeedLevelUp);
            increaseBulletSpeedLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseDropRateOfHealthPickUp()
    {
        if(PickUpsDropRateManager.Instance.GetHealthPickUpDropRate() == maxHealthPickUpDropRate)
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(increaseHealthPickUpDropRateLevelUp);
            increaseHealthPickUpDropRateLevelUp.SetActive(false);
        }
    }

    private void LimitIncreaseDropRateOfShieldPickUp()
    {
        if (PickUpsDropRateManager.Instance.GetShieldPickUpDropRate() == maxShieldPickUpDropRate)
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(increaseShieldPickUpDropRateLevelUp);
            increaseShieldPickUpDropRateLevelUp.SetActive(false);
        }
    }

    private void LimitShootingPoints()
    {
        if (PlayerShootingPointManager.Instance.IsShootingPointLeftActive())
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(shootingPointLeft);
            shootingPointLeft.SetActive(false);
        }
        if (PlayerShootingPointManager.Instance.IsShootingPointRightActive())
        {
            ShowRandomPowerUpUpgradeOption.Instance.allPowerUpsList.Remove(shootingPointRight);
            shootingPointRight.SetActive(false);
        }
    }
}
