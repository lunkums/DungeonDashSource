using UnityEngine;

public interface IEntity
{
    Animator Animator { get; }

    void Respawn(Vector2 position);

    IState InitialState(StateMachine stateMachine);

    IState DamagedState(StateMachine stateMachine);

    IState DeathState(StateMachine stateMachine);
}