using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[SelectionBase]
public class EnemySpaceShipShooting : MonoBehaviour
{
    [SerializeField] float fireTime;

    PlayerMovement player;
    //bool canFire;

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

    private void ShootAtThePlayer()
    {
        if(fireTime <= Time.deltaTime)
        {
            //canFire = true;
        }
    }
}
