using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShipObjectPool : MonoBehaviour
{
    public static EnemySpaceShipObjectPool Instance { get; private set; }

    [SerializeField] GameObject[] enemySpaceShipPrefabArray;
    [SerializeField] int amountToPool = 10;

    List<GameObject> pooledGameObjectList = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject instantiatedGameObject =
                Instantiate(enemySpaceShipPrefabArray[Random.Range(0, enemySpaceShipPrefabArray.Length)], transform);

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
