using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletFiringRateLevelUp : MonoBehaviour
{
    public void IncreaseBulletFiringRate()
    {
        float firingRateOfUp = PlayerShootingFromUp.Instance.GetBulletFireRate();
        PlayerShootingFromUp.Instance.SetBulletFiringRate(firingRateOfUp - 0.1f);

        GameManager.Instance.ResumeGame();
    }
}
