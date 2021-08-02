using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Damageable damageable;

    public Animator Animator => _animator;
    public AudioManager Audio => AudioManager.instance;
    public Damageable Damageable => damageable;

    public abstract State DamagedState(StateMachine stateMachine);

    public abstract State DeathState(StateMachine stateMachine);

    public abstract State InitialState(StateMachine stateMachine);
}