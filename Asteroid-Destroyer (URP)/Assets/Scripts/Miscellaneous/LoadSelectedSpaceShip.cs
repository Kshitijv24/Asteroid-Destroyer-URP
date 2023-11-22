using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSelectedSpaceShip : MonoBehaviour
{
    [SerializeField] GameObject[] allSpaceShips;

    private void Start()
    {
        int selectedSpaceShip = PlayerPrefs.GetInt("selectedSpaceShip");
        GameObject spaceShipPrefab = allSpaceShips[selectedSpaceShip];
        Instantiate(spaceShipPrefab);
    }
}
