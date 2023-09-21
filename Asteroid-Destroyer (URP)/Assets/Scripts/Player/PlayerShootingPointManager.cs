using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingPointManager : MonoBehaviour
{
    public static PlayerShootingPointManager Instance { get; private set; }

    [SerializeField] GameObject shootingPointLeft;
	[SerializeField] GameObject shootingPointRight;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsShootingPointLeftActive() => shootingPointLeft.activeSelf;

    public bool IsShootingPointRightActive() => shootingPointRight.activeSelf;

    public void ActivateShootingPointLeft() => shootingPointLeft.SetActive(true);

    public void ActivateShootingPointRight() => shootingPointRight.SetActive(true);
}
