using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListOfPlayerSpaceShips : MonoBehaviour
{
	[SerializeField] List<GameObject> allPlayerSpaceShips = new List<GameObject>();
    [SerializeField] Image lockedImage;
    [SerializeField] List<int> requiredPlayerPointsToUnlockShip = new List<int>();

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
        if(PlayerPoints.Instance.GetPlayerPoints() > requiredPlayerPointsToUnlockShip[selectedSpaceShip])
        {
            lockedImage.gameObject.SetActive(false);
        }

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
