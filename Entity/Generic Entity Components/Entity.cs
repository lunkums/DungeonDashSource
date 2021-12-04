using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Damageable damageable;

    public Animator Animator => _animator;
    public AudioManager Audio => AudioManager.instance;
    public Damageable Damageable => damageable;

    public void Respawn(Vector2 position)
    {
        gameObject.transform.position = position;
    }

    public abstract IState DamagedState(StateMachine stateMachine);

    public abstract IState DeathState(StateMachine stateMachine);

    public abstract IState InitialState(StateMachine stateMachine);
}