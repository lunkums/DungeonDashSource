using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.RevertDamage(healAmount);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        AudioManager.instance.Play("health_pickup");
    }
}
