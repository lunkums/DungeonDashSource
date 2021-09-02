using System.Collections;
using UnityEngine;

public class SpriteFlicker : SpriteAlpha
{
    [SerializeField] private float secondsBetweenFlickers;
    private float timeOfLastFlicker = 0f;
    [SerializeField] private Damageable damageable;

    private void OnEnable()
    {
        damageable.OnDamaged += EnableShader;
    }

    private void OnDisable()
    {
        damageable.OnDamaged -= EnableShader;
    }

    private void EnableShader()
    {
        StartCoroutine(SpriteFlickerCoroutine());
    }

    private IEnumerator SpriteFlickerCoroutine()
    {
        while (!damageable.CanBeDamaged())
        {
            if (Time.time > timeOfLastFlicker + secondsBetweenFlickers)
            {
                if (MaterialAlpha > 0f)
                    MaterialAlpha = 0f;
                else
                    MaterialAlpha = 1.0f;

                timeOfLastFlicker = Time.time;
            }

            yield return new WaitForSeconds(secondsBetweenFlickers);
        }

        MaterialAlpha = 1.0f;
        yield break;
    }
}
