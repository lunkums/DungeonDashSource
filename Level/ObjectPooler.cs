using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private PoolingObject[] poolingObjects;
    private Dictionary<string, GameObject> prefabs;
    private Dictionary<string, Queue<GameObject>> objectPools;

    public static ObjectPooler instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        InitializePools();
    }

    private void InitializePools()
    {
        prefabs = new Dictionary<string, GameObject>();
        objectPools = new Dictionary<string, Queue<GameObject>>();

        foreach (PoolingObject poolObj in poolingObjects)
        {
            prefabs.Add(poolObj.tag, poolObj.prefab);
            Queue<GameObject> pool = new Queue<GameObject>();
            objectPools.Add(poolObj.tag, pool);
        }
    }

    public void SpawnObject(string tag, Vector2 position)
    {
        var pool = objectPools[tag];
        if (pool.Count > 0)
        {
            var entity = pool.Dequeue();
            var entityScript = entity.GetComponent<Entity>();
            entity.SetActive(true);
            entityScript.Respawn(position);
        }
        else
        {
            var entity = Instantiate(prefabs[tag], position, Quaternion.identity);
            entity.name = prefabs[tag].name;
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        objectPools[instance.name].Enqueue(instance);
    }

    [System.Serializable]
    private struct PoolingObject
    {
        public string tag;
        public GameObject prefab;
    }
}
