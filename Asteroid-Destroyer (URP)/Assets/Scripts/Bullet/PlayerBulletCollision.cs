using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    [SerializeField] float maxDistance = 0.5f; // Maximum distance the ray can travel
    [SerializeField] float raySpreadAngle = 10f; // Angle in degrees for the spread of the rays
    [SerializeField] Color rayColor = Color.red;

    private void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        // Cast rays in front and on each side of the bullet's direction
        CastRay(transform.forward); // Center ray
        CastRay(transform.forward + transform.right * Mathf.Tan(raySpreadAngle * Mathf.Deg2Rad)); // Right ray
        CastRay(transform.forward - transform.right * Mathf.Tan(raySpreadAngle * Mathf.Deg2Rad)); // Left ray
    }

    private void CastRay(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hitInfo;

        Debug.DrawRay(transform.position, direction * maxDistance, rayColor);

        if (Physics.Raycast(ray, out hitInfo, maxDistance))
        {
            Collider hitCollider = hitInfo.collider;

            DestroyAsteroidWithBullet(hitCollider);
            DestroyEnemySpaceShipWithBullet(hitCollider);
            DestroyEnemyBulletWithBullet(hitCollider);
        }
    }

    private void DestroyAsteroidWithBullet(Collider other)
    {
        AsteroidCollision asteroid = other.GetComponent<AsteroidCollision>();

        if (asteroid != null)
        {
            asteroid.AsteroidDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }

    private void DestroyEnemySpaceShipWithBullet(Collider other)
    {
        EnemySpaceShipCollision enemySpaceShip = other.GetComponent<EnemySpaceShipCollision>();

        if (enemySpaceShip != null)
        {
            enemySpaceShip.EnemySpaceShipDestroyedByPlayer();
            gameObject.SetActive(false);
        }
    }

    private void DestroyEnemyBulletWithBullet(Collider other)
    {
        EnemyBulletCollision enemyBullet = other.GetComponent<EnemyBulletCollision>();

        if (enemyBullet != null)
        {
            enemyBullet.InstantiateBulletDestroyVFX();
            gameObject.SetActive(false);
        }
    }
}
