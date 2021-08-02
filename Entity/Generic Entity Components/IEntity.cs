using UnityEngine;

public interface IEntity
{
    Animator Animator { get; }

    State InitialState(StateMachine stateMachine);

    State DamagedState(StateMachine stateMachine);

    State DeathState(StateMachine stateMachine);
}