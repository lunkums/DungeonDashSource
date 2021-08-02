using UnityEngine;

public class PlayerMaterialTint : MaterialTint
{
    [SerializeField] private Damageable damageable;

    private void OnEnable()
    {
        damageable.OnDamaged += SetDamagedTint;
    }

    private void OnDisable()
    {
        damageable.OnDamaged -= SetDamagedTint;
    }

    private void SetDamagedTint()
    {
        SetTintColor(Color.white);
    }
}
