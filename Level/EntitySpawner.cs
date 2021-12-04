using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private string entityName;

    private bool activated;

    private void Awake()
    {
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            ObjectPooler.instance.SpawnObject(entityName, spawnPoint.position);
            activated = true;
        }
    }
}
