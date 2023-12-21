using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpaceShipShooting : MonoBehaviour
{
    PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        LookAtPlayerSpaceShip();
    }

    private void LookAtPlayerSpaceShip()
    {
        transform.LookAt(player.transform.position);
    }
}
