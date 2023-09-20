using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletFiringRateLevelUp : MonoBehaviour
{
    public void IncreaseBulletFiringRate()
    {
        float firingRateOfUp = PlayerShootingFromUp.Instance.GetBulletFireRate();
        float firingRateOfLeft = PlayerShootingFromLeft.Instance.GetBulletFireRate();
        float firingRateOfRight = PlayerShootingFromRight.Instance.GetBulletFireRate();
        PlayerShootingFromUp.Instance.SetBulletFiringRate(firingRateOfUp - 0.1f);
        PlayerShootingFromLeft.Instance.SetBulletFiringRate(firingRateOfLeft - 0.1f);
        PlayerShootingFromRight.Instance.SetBulletFiringRate(firingRateOfRight - 0.1f);
        GameManager.Instance.ResumeGame();
    }
}
