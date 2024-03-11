using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class NoOfEnemiesNeedToKillForLevelUp : MonoBehaviour
{
	[SerializeField] TMP_InputField inputField;

    int valueToSave;

    private void Start()
    {
        valueToSave = PlayerPrefs.GetInt("PlayerInput");
        inputField.text = valueToSave.ToString();
    }

    private void Update()
    {
        if (int.TryParse(inputField.text, out valueToSave))
        {
            PlayerPrefs.SetInt("PlayerInput", valueToSave);
        }
    }
}
