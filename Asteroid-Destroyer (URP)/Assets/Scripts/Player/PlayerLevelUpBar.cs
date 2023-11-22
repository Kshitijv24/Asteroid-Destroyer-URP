using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUpBar : MonoBehaviour
{
	[SerializeField] Slider playerLevelUpBarSlider;
    [SerializeField] TextMeshProUGUI playerLevelText;

    private void Start() => playerLevelUpBarSlider.value = 0;

    private void Update()
    {
        playerLevelUpBarSlider.maxValue = PlayerLevelUpManager.Instance.noOfEnemiesNeededToKillToLevelUp;
        playerLevelUpBarSlider.value = PlayerLevelUpManager.Instance.killedEnemies;

        playerLevelText.text = "Player Level " + PlayerLevelUpManager.Instance.playerLevel.ToString();
    }
}
