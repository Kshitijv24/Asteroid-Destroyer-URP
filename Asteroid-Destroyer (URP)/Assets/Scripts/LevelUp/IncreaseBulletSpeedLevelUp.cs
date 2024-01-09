using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncreaseBulletSpeedLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentText;
    [SerializeField] TextMeshProUGUI nextText;

    private void OnEnable()
    {
        currentText.SetText("Current: " + PlayerShootingFromUp.Instance.GetBulletSpeed());
        nextText.SetText("Upgraded: " + PlayerShootingFromUp.Instance.GetBulletSpeed() + 1);
    }

    public void IncreaseBulletSpeed()
	{
		float bulletSpeedOfUp = PlayerShootingFromUp.Instance.GetBulletSpeed();
		PlayerShootingFromUp.Instance.SetBulletSpeed(bulletSpeedOfUp + 1.0f);
        
		GameManager.Instance.ResumeGameAndHideLevelUpPanel();
	}
}
