using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShipSelection : MonoBehaviour
{
	[SerializeField] List<GameObject> allPlayerSpaceShipList = new List<GameObject>();
    [SerializeField] float spaceShipRotationSpeed = 50.0f;
    [SerializeField] SpaceShip[] spaceShipArray;
    [SerializeField] Button buyButton;
    [SerializeField] Button selectButton;
    [SerializeField] Image lockedSpaceShipImage;

    int selectedSpaceShip = 0;

    private void Start()
    {
        CheckIfSpaceShipIsUnlocked();
        OnlyShowingFirstSpaceShipAtTheStart();
    }

    private void OnlyShowingFirstSpaceShipAtTheStart()
    {
        foreach (GameObject playerSpaceShip in allPlayerSpaceShipList)
        {
            playerSpaceShip.SetActive(false);
        }

        allPlayerSpaceShipList[0].SetActive(true);
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

    private void Update()
    {
        RotateSpaceShips();
        HandleSpaceShipPurchase();
    }

    private void RotateSpaceShips()
    {
        transform.Rotate(0, spaceShipRotationSpeed * Time.deltaTime, 0);
    }

    public void ShowPreviousSpaceShip()
	{
        allPlayerSpaceShipList[selectedSpaceShip].SetActive(false);
        selectedSpaceShip--;

        if(selectedSpaceShip < 0 )
        {
            selectedSpaceShip += allPlayerSpaceShipList.Count;
        }

        allPlayerSpaceShipList[selectedSpaceShip].SetActive(true);
    }

    public void ShowNextSpaceShip()
    {
        allPlayerSpaceShipList[selectedSpaceShip].SetActive(false);
        selectedSpaceShip = (selectedSpaceShip + 1) % allPlayerSpaceShipList.Count;
        allPlayerSpaceShipList[selectedSpaceShip].SetActive(true);
    }

    public void SelectSpaceShip()
    {
        PlayerPrefs.SetInt("selectedSpaceShip", selectedSpaceShip);
        SceneManager.LoadScene(2);
    }

    public void BuySpaceShip()
    {
        SpaceShip spaceShip = spaceShipArray[selectedSpaceShip];
        PlayerPrefs.SetInt(spaceShip.name, 1);

        spaceShip.isUnlocked = true;
        PlayerPoints.Instance.DecreasePlayerPoints(spaceShip.price);
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

    private void HandleSpaceShipPurchase()
    {
        SpaceShip spaceShip = spaceShipArray[selectedSpaceShip];

        if(spaceShip.isUnlocked)
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

    private void ShowPriceOfSpaceShipInBuyButton(SpaceShip spaceShip)
    {
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy: " + spaceShip.price;
    }

    private void BuySpaceShipIfHaveEnoughMoney(SpaceShip spaceShip)
    {
        buyButton.interactable = spaceShip.price <= PlayerPoints.Instance.GetPlayerPoints();
    }
}
