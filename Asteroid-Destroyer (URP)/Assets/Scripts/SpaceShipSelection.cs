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

    int selectedSpaceShip = 0;

    private void Start()
    {
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

    private void Update()
    {
        RotateSpaceShips();
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

    public int GetSelectedSpaceShip()
    {
        return selectedSpaceShip;
    }
}
