using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingPointManager : MonoBehaviour
{
    public static PlayerShootingPointManager Instance { get; private set; }

	[SerializeField] GameObject shootingPointUpper;
    [SerializeField] GameObject shootingPointLeft;
	[SerializeField] GameObject shootingPointRight;

    bool activatedOnceLeft;
    bool activatedOnceRight;

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

    public void ActivateShootingPointUpper() => shootingPointUpper.SetActive(true);

    public void ActivateShootingPointLeft()
    {
        activatedOnceLeft = true;
        shootingPointLeft.SetActive(true);
    }

    public void ActivateShootingPointRight()
    {
        activatedOnceRight = true;
        shootingPointRight.SetActive(true);
    }

    public void DeactivateAllShootingPoints()
    {
        shootingPointUpper.SetActive(false);

        shootingPointLeft.SetActive(false);

        shootingPointRight.SetActive(false);
    }

    public void ActivateAllShootingPoints()
    {
        shootingPointUpper.SetActive(true);
        
        if (!shootingPointLeft.activeSelf && activatedOnceLeft)
        {
            shootingPointLeft.SetActive(true);
        }

        if (!shootingPointRight.activeSelf && activatedOnceRight)
        {
            shootingPointRight.SetActive(true);
        }
    }
}
