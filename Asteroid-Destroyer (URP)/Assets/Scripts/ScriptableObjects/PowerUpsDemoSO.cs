using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpsDemoSO : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI currentTextSerializeField;
	[SerializeField] PowerUpsScriptableObjectData powerUpsScriptableObjectData;

    private void Start()
    {
        powerUpsScriptableObjectData.currentStats.text = currentTextSerializeField.text;
    }
}
