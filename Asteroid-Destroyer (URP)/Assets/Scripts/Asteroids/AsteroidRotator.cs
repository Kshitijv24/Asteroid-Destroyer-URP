using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    [SerializeField] float rotationAmount = 40f;

    private void Update()
    {
        transform.Rotate(
            rotationAmount * Time.deltaTime, 
            rotationAmount * Time.deltaTime, 
            rotationAmount * Time.deltaTime);
    }
}
