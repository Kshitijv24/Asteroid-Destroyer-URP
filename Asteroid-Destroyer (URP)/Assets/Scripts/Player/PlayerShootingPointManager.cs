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
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    public bool IsShootingPointLeftActive()
    {
        if (shootingPointLeft == null) return false;

        return shootingPointLeft.activeSelf;
    }

    public bool IsShootingPointRightActive()
    {
        if (shootingPointRight == null) return false;

        return shootingPointRight.activeSelf;
    }

    public void ActivateShootingPointLeft() => shootingPointLeft.SetActive(true);

    public void ActivateShootingPointRight() => shootingPointRight.SetActive(true);
}
