public interface IDamageable
{
    void TakeDamage(int damage);

    void RevertDamage(int damage);

    void Destruct();
}