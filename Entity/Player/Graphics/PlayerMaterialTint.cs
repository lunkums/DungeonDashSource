using System.Collections;
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
        StartCoroutine(ResetTintCoroutine());
    }

    private IEnumerator ResetTintCoroutine()
    {
        while (!damageable.CanBeDamaged())
        {
            if (!IsTintVisible())
            {
                SetTintAlpha(1.0f);
            }

            yield return null;
        }

        yield break;
    }
}
