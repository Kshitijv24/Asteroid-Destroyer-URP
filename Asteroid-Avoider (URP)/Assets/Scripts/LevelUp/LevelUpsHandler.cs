using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpsHandler : MonoBehaviour
{
	[SerializeField] GameObject increaseBulletFireRateLevelUp;

    private void Update()
    {
        if(PlayerShooting.Instance.GetBulletFireRate() < 0.3)
        {
            increaseBulletFireRateLevelUp.SetActive(false);
        }
    }
}
