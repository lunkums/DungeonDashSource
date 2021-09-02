using UnityEngine;

public class WolfInput : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private float searchRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private LayerMask raycastLayer;

    public GameManager GameManager => gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public bool IsPlayerInSearchRange()
    {
        Vector2 playerPosition = GameManager.Player.transform.position;
        return Vector2.Distance(transform.position, playerPosition) < searchRadius;
    }

    public bool IsPlayerInAttackRange()
    {
        Vector2 playerPosition = GameManager.Player.transform.position;
        return Vector2.Distance(attackPoint.position, playerPosition) < attackRadius;
    }

    public bool IsPlayerBehind()
    {
        Vector2 selfPosition = attackPoint.transform.position;
        Vector2 playerPosition = GameManager.Player.transform.position;
        return selfPosition.x > playerPosition.x;
    }

    public void EnableHitbox(bool enabled)
    {
        hitbox.SetActive(enabled);
    }

    public bool IsThereAHole()
    {
        bool holeDetected = true;

        Vector2 direction = (rayPoint.transform.position - transform.position).normalized;
        Debug.DrawRay(transform.position, direction / 2.0f, Color.red);
        var rayHit = Physics2D.Raycast(transform.position, direction, 1 / 2.0f, raycastLayer);

        if (rayHit)
            holeDetected = false;

        return holeDetected;
    }
}
