using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public static ObjectPool Instance { get; private set; }

    [SerializeField] GameObject[] asteroidsPrefabs;

    List<GameObject> pooledGameObjects = new List<GameObject>();
    int amountToPool = 20;

    private void Awake()
    {
        if(Instance == null)
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
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject instantiatedGameObject = Instantiate(asteroidsPrefabs[Random.Range(0, 2)]);
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
