using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
            damageable.TakeDamage(damage);
    }
}
