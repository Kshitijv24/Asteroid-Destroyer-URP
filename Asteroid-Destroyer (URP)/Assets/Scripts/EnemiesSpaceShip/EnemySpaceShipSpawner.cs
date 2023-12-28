using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShipSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpaceShipPrefab;
    [SerializeField] float spawnTime = 1;
    [SerializeField] Vector2 forceRange;

    float timer;
    Camera mainCamera;
    Rigidbody rb;

    private void Awake() => mainCamera = Camera.main;

    private void Update() => SpawnEnemySpaceShipAtATime();

    private void SpawnEnemySpaceShipAtATime()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemySpaceShip();
            timer += spawnTime;

            ChangeEnemySpaceShipSpawnRateAccordingToThePlayerLevel();
        }
    }

    private void SpawnEnemySpaceShip()
    {
        int side = Random.Range(0, 4);

        Vector3 spawnPoint = Vector2.zero;
        Vector3 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPoint.x = 0;
                spawnPoint.z = Random.value;
                direction = new Vector3(1f, 0f, Random.Range(-1f, 1f));
                break;
            case 1:
                spawnPoint.x = 1;
                spawnPoint.z = Random.value;
                direction = new Vector3(-1f, 0f, Random.Range(-1f, 1f));
                break;
            case 2:
                spawnPoint.x = Random.value;
                spawnPoint.z = 0;
                direction = new Vector3(Random.Range(-1f, 1f), 0f, 1f);
                break;
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.z = 1;
                direction = new Vector3(Random.Range(-1f, 1f), 0f, -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.y = 0;

        GameObject pooledEnemySpaceShipPrefab = EnemySpaceShipObjectPool.Instance.GetPooledGameObject();

        if (pooledEnemySpaceShipPrefab != null)
        {
            pooledEnemySpaceShipPrefab.transform.position = worldSpawnPoint;
            pooledEnemySpaceShipPrefab.SetActive(true);
            rb = pooledEnemySpaceShipPrefab.GetComponent<Rigidbody>();
        }

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
        }
    }

    private void ChangeEnemySpaceShipSpawnRateAccordingToThePlayerLevel()
    {
        if (PlayerLevelUpManager.Instance.playerLevel == 2)
        {
            spawnTime = 0.8f;
        }
        else if (PlayerLevelUpManager.Instance.playerLevel == 4)
        {
            spawnTime = 0.6f;
        }
        else if (PlayerLevelUpManager.Instance.playerLevel == 6)
        {
            spawnTime = 0.4f;
        }
    }
}
