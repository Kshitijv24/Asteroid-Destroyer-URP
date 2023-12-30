using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseShieldPickUpDropRateLevelUp : MonoBehaviour
{
    public void IncreaseShieldPickUpDropRate()
    {
        float shieldPickUpDropRate = PickUpsDropRateManager.Instance.GetShieldPickUpDropRate();
        PickUpsDropRateManager.Instance.SetShieldPickUpDropRate(shieldPickUpDropRate + 0.1f);

        GameManager.Instance.ResumeGameAndHideLevelUpPanel();
    }
}
