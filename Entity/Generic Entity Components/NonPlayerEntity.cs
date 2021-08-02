using UnityEngine;

public abstract class NonPlayerEntity : Entity
{
    private GameManager gameManager = GameManager.instance;
    [SerializeField] private float searchRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;

    public GameManager GameManager => gameManager;
    public float SearchRadius => searchRadius;
    public float AttackRadius => attackRadius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SearchRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, AttackRadius);
    }

    public bool IsPlayerInRange(float range)
    {
        Vector2 selfPosition = transform.position;
        Vector2 playerPosition = GameManager.Player.transform.position;
        return Vector2.Distance(selfPosition, playerPosition) < range;
    }
}
