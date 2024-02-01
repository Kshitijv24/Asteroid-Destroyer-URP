using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool Instance { get; private set; }

    [SerializeField] GameObject[] bulletPrefabArray;
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
            GameObject instantiatedGameObject = Instantiate(bulletPrefabArray[Random.Range(0, bulletPrefabArray.Length)], transform);
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
