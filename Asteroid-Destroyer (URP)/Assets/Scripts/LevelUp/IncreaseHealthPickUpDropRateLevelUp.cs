using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealthPickUpDropRateLevelUp : MonoBehaviour
{
	public void IncreaseHealthPickUpDropRate()
	{
		float healthPickUpDropRate = PickUpsDropRateManager.Instance.GetHealthPickUpDropRate();
		PickUpsDropRateManager.Instance.SetHealthPickUpDropRate(healthPickUpDropRate + 0.1f);

		GameManager.Instance.ResumeGame();
    }
}
