using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBulletFiringRateLevelUp : MonoBehaviour
{
    public void IncreaseBulletFiringRate()
    {
        float firingRate = PlayerShooting.Instance.GetBulletFireRate();
        PlayerShooting.Instance.SetBulletFiringRate(firingRate - 0.1f);
        GameManager.Instance.ResumeGame();
    }
}
