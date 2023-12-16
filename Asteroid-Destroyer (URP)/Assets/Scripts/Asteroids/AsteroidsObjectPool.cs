using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsObjectPool : MonoBehaviour
{
	public static AsteroidsObjectPool Instance { get; private set; }
        
    [SerializeField] GameObject[] asteroidsPrefabArray;
    [SerializeField] int amountToPool = 10;

    List<GameObject> pooledGameObjectList = new List<GameObject>();

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
            GameObject instantiatedGameObject = 
                Instantiate(asteroidsPrefabArray[Random.Range(0, asteroidsPrefabArray.Length)], transform);

            instantiatedGameObject.SetActive(false);
            pooledGameObjectList.Add(instantiatedGameObject);
        }
    }

    public GameObject GetPooledGameObject()
    {
        for (int i = 0; i < pooledGameObjectList.Count; i++)
        {
            if (!pooledGameObjectList[i].activeInHierarchy)
            {
                return pooledGameObjectList[i];
            }
        }
        return null;
    }
}
