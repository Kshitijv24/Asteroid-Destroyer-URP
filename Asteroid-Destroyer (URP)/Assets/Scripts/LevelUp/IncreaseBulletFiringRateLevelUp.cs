using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletFiringRateLevelUp : MonoBehaviour
{
    public void IncreaseBulletFiringRate()
    {
        float firingRateOfUp = PlayerShootingFromUp.Instance.GetBulletFireRate();
        float newBulletFiringRate = PlayerShootingFromUp.Instance.SetBulletFiringRate(firingRateOfUp - 0.1f);
        PlayerShootingFromLeft.Instance.SetBulletFiringRate(newBulletFiringRate);
        PlayerShootingFromRight.Instance.SetBulletFiringRate(newBulletFiringRate);
        GameManager.Instance.ResumeGame();
    }
}
