using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject entityPrefab;

    private bool activated;

    private void Awake()
    {
        activated = false;
    }

    private void SpawnEntity()
    {
        Instantiate(entityPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.CompareTag("Player") && !activated)
        {
            SpawnEntity();
            activated = true;
        }
    }
}
