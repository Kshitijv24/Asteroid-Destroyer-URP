using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ShowLeftSpaceShip()
	{
        allPlayerSpaceShips[selectedSpaceShip].SetActive(false);
        selectedSpaceShip--;

        if(selectedSpaceShip < 0 )
        {
            selectedSpaceShip += allPlayerSpaceShips.Count;
        }
        allPlayerSpaceShips[selectedSpaceShip].SetActive(true);
    }

    public void ShowRightSpaceShip()
    {
        allPlayerSpaceShips[selectedSpaceShip].SetActive(false);
        selectedSpaceShip = (selectedSpaceShip + 1) % allPlayerSpaceShips.Count;
        allPlayerSpaceShips[selectedSpaceShip].SetActive(true);
    }
}
