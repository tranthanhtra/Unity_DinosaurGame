using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
  public Dictionary<string, Queue<GameObject>> PoolDictionary;

  public List<Pool> pools;

  [System.Serializable]
  public class Pool
  {
    public string objectTag;
    public GameObject prefab;
    public int poolSize;
  }

  public static ObjectPool Instance;

  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    PoolDictionary = new Dictionary<string, Queue<GameObject>>();

    foreach (Pool pool in pools)
    {
      Queue<GameObject> objectPool = new Queue<GameObject>();

      for (var i = 0; i < pool.poolSize; ++i)
      {
        GameObject obj = Instantiate(pool.prefab, GameConfig.StartingPoint[pool.objectTag], Quaternion.identity);
        obj.SetActive(false);
        objectPool.Enqueue(obj);
      }

      PoolDictionary.Add(pool.objectTag, objectPool);
    }
  }

  public GameObject GetObject(string objectTag, Vector3 position, Quaternion rotation)
  {
    if (!PoolDictionary.ContainsKey(objectTag))
    {
      Debug.Log("tag not exist");
      return null;
    }

    var obj = PoolDictionary[objectTag].Dequeue();
    obj.SetActive(true);
    obj.transform.position = position;
    obj.transform.rotation = rotation;

    PoolDictionary[objectTag].Enqueue(obj);

    return obj;
  }
}