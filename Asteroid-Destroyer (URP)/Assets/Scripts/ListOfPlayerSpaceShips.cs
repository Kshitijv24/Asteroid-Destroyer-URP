using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListOfPlayerSpaceShips : MonoBehaviour
{
	[SerializeField] List<GameObject> allPlayerSpaceShips = new List<GameObject>();

    int selectedSpaceShip = 0;

    private void Start()
    {
        foreach (GameObject playerSpaceShip in allPlayerSpaceShips)
        {
            playerSpaceShip.SetActive(false);
        }

        allPlayerSpaceShips[0].SetActive(true);
    }

    public void ShowPreviousSpaceShip()
	{
        allPlayerSpaceShips[selectedSpaceShip].SetActive(false);
        selectedSpaceShip--;

        if(selectedSpaceShip < 0 )
        {
            selectedSpaceShip += allPlayerSpaceShips.Count;
        }

        allPlayerSpaceShips[selectedSpaceShip].SetActive(true);
    }

    public void ShowNextSpaceShip()
    {
        allPlayerSpaceShips[selectedSpaceShip].SetActive(false);
        selectedSpaceShip = (selectedSpaceShip + 1) % allPlayerSpaceShips.Count;
        allPlayerSpaceShips[selectedSpaceShip].SetActive(true);
    }

    public void SelectSpaceShip()
    {
        PlayerPrefs.SetInt("selectedSpaceShip", selectedSpaceShip);
        SceneManager.LoadScene(2);
    }
}
