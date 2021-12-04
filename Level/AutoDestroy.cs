using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private int distanceBeforeDestruction = 20;
    [SerializeField] private Transform pointOfDestruction;
    private Entity _entity;
    private bool isActive;

    private void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    private void OnEnable()
    {
        isActive = true;
    }

    private void LateUpdate()
    {
        GameObject player = GameManager.instance.Player.gameObject;

        if (isActive && Vector2.Distance(pointOfDestruction.position, player.transform.position) > distanceBeforeDestruction)
        {
            isActive = false;

            if (IsObjectPoolable())
                ObjectPooler.instance.AddToPool(gameObject);
            else
                Destroy(gameObject);
        }
    }

    private bool IsObjectPoolable()
    {
        return _entity != null;
    }
}
