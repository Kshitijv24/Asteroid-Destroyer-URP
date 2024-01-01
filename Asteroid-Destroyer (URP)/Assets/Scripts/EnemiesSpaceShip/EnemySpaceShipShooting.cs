using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[SelectionBase]
public class EnemySpaceShipShooting : MonoBehaviour
{
    public float fixedZRotation = 90f;
    public float fixedYRotation = -90f;

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
        if(player == null) return;

        transform.LookAt(player.transform.position);
    }
}
