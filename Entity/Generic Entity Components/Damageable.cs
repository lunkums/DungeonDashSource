using System;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private EntityStateHandler stateHandler;
    [SerializeField] private float recoveryTimeInterval;
    
    private int currentHealth;
    private float currentTime;
    private float nextDamageTime;

    public event Action OnDamaged;
    public event Action OnDestruct;
    public event Action OnDamageReverted;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    private void Initialize()
    {
        currentHealth = maxHealth;
        currentTime = 0;
        nextDamageTime = 0;
    }

    private void OnEnable()
    {
        Initialize();

        OnDamaged += stateHandler.SetDamagedState;
        OnDestruct += stateHandler.SetDeathState;
    }

    private void OnDisable()
    {
        OnDamaged -= stateHandler.SetDamagedState;
        OnDestruct -= stateHandler.SetDeathState;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void TakeDamage(int damage, bool bypassRecoveryInterval = false)
    {
        if (CanBeDamaged() || bypassRecoveryInterval)
        {
            currentHealth -= damage;
            nextDamageTime = currentTime + recoveryTimeInterval;

            if (currentHealth <= 0)
            {
                OnDestruct?.Invoke();
            }
            else
            {
                OnDamaged?.Invoke();
            }
        }
    }

    public void RevertDamage(int damage)
    {
        currentHealth += damage;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        OnDamageReverted?.Invoke();
    }

    public bool CanBeDamaged()
    {
        return currentHealth > 0 && currentTime >= nextDamageTime;
    }
}
