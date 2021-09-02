using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool bypassRecoveryInterval;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collider = collision.gameObject;
        var damageableComponent = collider.GetComponent<IDamageable>();
        damageableComponent?.TakeDamage(damage, bypassRecoveryInterval);
    }
}
