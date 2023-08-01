using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool Instance { get; private set; }

    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] int amountToPool = 10;

    List<GameObject> pooledGameObjects = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject instantiatedGameObject = Instantiate(bulletPrefab[Random.Range(0, bulletPrefab.Length)], transform);
            instantiatedGameObject.SetActive(false);
            pooledGameObjects.Add(instantiatedGameObject);
        }
    }

    public GameObject GetPooledGameObject()
    {
        for (int i = 0; i < pooledGameObjects.Count; i++)
        {
            if (!pooledGameObjects[i].activeInHierarchy)
            {
                return pooledGameObjects[i];
            }
        }
        return null;
    }
}
