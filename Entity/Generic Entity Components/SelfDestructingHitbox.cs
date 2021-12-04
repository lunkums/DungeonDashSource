using UnityEngine;

public class SelfDestructingHitbox : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Damageable damageable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
            damageable.TakeDamage(damage);

        this.damageable.TakeDamage(damage);
    }
}
