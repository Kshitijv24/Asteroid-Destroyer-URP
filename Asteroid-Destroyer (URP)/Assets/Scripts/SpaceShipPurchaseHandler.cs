using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipPurchaseHandler : MonoBehaviour
{
    [SerializeField] SpaceShipSelection spaceShipSelection;
    [SerializeField] SpaceShip[] spaceShipArray;
    [SerializeField] Button buyButton;
    [SerializeField] Button selectButton;
    [SerializeField] Image lockedSpaceShipImage;

    private void Start()
    {
        CheckIfSpaceShipIsUnlocked();
    }

    private void Update()
    {
        HandleSpaceShipPurchase();
    }

    private void CheckIfSpaceShipIsUnlocked()
    {
        foreach (SpaceShip spaceShip in spaceShipArray)
        {
            if (spaceShip.price == 0)
            {
                spaceShip.isUnlocked = true;
            }
            else
            {
                spaceShip.isUnlocked = PlayerPrefs.GetInt(spaceShip.name) == 0 ? false : true;
            }
        }
    }

    private void HandleSpaceShipPurchase()
    {
        SpaceShip spaceShip = spaceShipArray[spaceShipSelection.GetSelectedSpaceShip()];

        if (spaceShip.isUnlocked)
        {
            ShowUnlockSpaceShipUI();
        }
        else
        {
            ShowLockSpaceShipUI();
            ShowPriceOfSpaceShipInBuyButton(spaceShip);
            BuySpaceShipIfHaveEnoughMoney(spaceShip);
        }
    }

    private void ShowUnlockSpaceShipUI()
    {
        buyButton.gameObject.SetActive(false);
        lockedSpaceShipImage.gameObject.SetActive(false);
        selectButton.gameObject.SetActive(true);
    }

    private void ShowLockSpaceShipUI()
    {
        buyButton.gameObject.SetActive(true);
        selectButton.gameObject.SetActive(false);
        lockedSpaceShipImage.gameObject.SetActive(true);
    }

    private void ShowPriceOfSpaceShipInBuyButton(SpaceShip spaceShip)
    {
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy: " + spaceShip.price;
    }

    private void BuySpaceShipIfHaveEnoughMoney(SpaceShip spaceShip)
    {
        buyButton.interactable = spaceShip.price <= PlayerPoints.Instance.GetPlayerPoints();
    }

    public void BuySpaceShip()
    {
        SpaceShip spaceShip = spaceShipArray[spaceShipSelection.GetSelectedSpaceShip()];
        PlayerPrefs.SetInt(spaceShip.name, 1);

        spaceShip.isUnlocked = true;
        PlayerPoints.Instance.DecreasePlayerPoints(spaceShip.price);
    }
}
