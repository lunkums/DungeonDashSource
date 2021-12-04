using UnityEngine;

public class WolfInput : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private float searchRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private Transform holeDetectionPoint;

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
        Gizmos.DrawWireSphere(holeDetectionPoint.position, 0.125f);
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
        Vector2 selfPosition = attackPoint.position;
        Vector2 playerPosition = GameManager.Player.transform.position;
        return selfPosition.x > playerPosition.x;
    }

    public void EnableHitbox(bool enabled)
    {
        hitbox.SetActive(enabled);
    }

    public bool IsThereAHole()
    {
        return !UtilityEntityMovement.IsGrounded(holeDetectionPoint);
    }
}
