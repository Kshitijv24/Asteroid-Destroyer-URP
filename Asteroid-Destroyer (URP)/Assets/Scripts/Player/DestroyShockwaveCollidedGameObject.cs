using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShockwaveCollidedGameObject : MonoBehaviour
{
    [SerializeField] float speedAtWitchTheSphereColliderExpand = 10f;
    [SerializeField] float maxRadiosOfSphereCollider = 40f;

    SphereCollider sphereCollider;

    private void Awake() => sphereCollider = GetComponent<SphereCollider>();

    private void Update() => 
        sphereCollider.radius = 
        Mathf.Lerp(sphereCollider.radius, maxRadiosOfSphereCollider, speedAtWitchTheSphereColliderExpand * Time.unscaledDeltaTime);

    private void OnTriggerEnter(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();
        EnemySpaceShipCollision enemy = other.GetComponent<EnemySpaceShipCollision>();
        EnemyBulletCollision enemyBullet = other.GetComponent<EnemyBulletCollision>();

        if (asteroid != null || enemy != null || enemyBullet != null)
            other.gameObject.SetActive(false);
    }

    private void OnDisable() => sphereCollider.radius = 1.0f;
}
