using System;
using System.Collections.Generic;

public class HealthBarSystem
{
    public const int MAX_INDEX = 1;

    private List<Heart> heartList;
    private int currentHealth;
    private Damageable damageable;

    public List<Heart> HeartList => heartList;

    public Action OnHealthChanged;

    public HealthBarSystem(Player player)
    {
        damageable = player.Damageable;
        int heartAmount = damageable.CurrentHealth * MAX_INDEX;
        heartList = new List<Heart>();

        for (int i = 0; i < heartAmount; i++)
        {
            Heart heart = new Heart(1);
            heartList.Add(heart);
        }

        currentHealth = damageable.CurrentHealth;
        damageable.OnDamaged += PlayerDamageable_OnHealthChanged;
        damageable.OnDamageReverted += PlayerDamageable_OnHealthChanged;
        damageable.OnDestruct += PlayerDamageable_OnHealthChanged;
    }

    private void PlayerDamageable_OnHealthChanged()
    {
        int damageAmount = currentHealth - damageable.CurrentHealth;
        Damage(damageAmount);
    }

    public void Damage(int damageAmount)
    {
        for (int i = heartList.Count - 1; i >= 0; i--)
        {
            Heart heart = heartList[i];
            if (damageAmount > heart.Index)
            {
                damageAmount -= heart.Index;
                heart.Damage(damageAmount);
            }
            else
            {
                heart.Damage(damageAmount);
                break;
            }
        }

        currentHealth -= damageAmount;
        OnHealthChanged?.Invoke();
    }

    public void RevertDamage(int damage)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingIndices = MAX_INDEX - heart.Index;

            if (damage > missingIndices)
            {
                damage -= missingIndices;
                heart.RevertDamage(damage);
            }
            else
            {
                heart.RevertDamage(damage);
                break;
            }
        }

        currentHealth += damage;
        OnHealthChanged?.Invoke();
    }

    public class Heart
    {
        public int Index { get; set; }

        public Heart(int index)
        {
            Index = index;
        }

        public void Damage(int damageAmount)
        {
            if (damageAmount >= Index)
            {
                Index = 0;
            }
            else
            {
                Index -= damageAmount;
            }
        }

        public void RevertDamage(int damageAmount)
        {
            if (Index + damageAmount > MAX_INDEX)
            {
                Index = MAX_INDEX;
            }
            else
            {
                Index += damageAmount;
            }
        }
    }
}
