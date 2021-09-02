public interface IDamageable
{
    void TakeDamage(int damage, bool bypassRecoveryInterval = false);

    void RevertDamage(int damage);

    void Destruct();
}