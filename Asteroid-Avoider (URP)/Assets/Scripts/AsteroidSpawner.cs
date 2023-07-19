using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidPrefab;
    [SerializeField] float secondsBetweenAsteroidsSpawn;
    [SerializeField] Vector2 forceRange;

    float timer;
    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnAsteroids();

            timer += secondsBetweenAsteroidsSpawn;
        }
    }

    private void SpawnAsteroids()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroids = asteroidPrefab[Random.Range(0, asteroidPrefab.Length)];

        //GameObject asteroidInstance = Instantiate(
        //    selectedAsteroids,
        //    worldSpawnPoint,
        //    Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        GameObject pooledAsteroidsPrefab = ObjectPool.Instance.GetPooledGameObject();

        if(pooledAsteroidsPrefab != null)
        {
            pooledAsteroidsPrefab.transform.position = worldSpawnPoint;
            pooledAsteroidsPrefab.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            pooledAsteroidsPrefab.SetActive(true);
        }

        Rigidbody rb = pooledAsteroidsPrefab.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
