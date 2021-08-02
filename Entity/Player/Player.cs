using UnityEngine;

public class Player : Entity
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerAttackController attackController;

    public PlayerInputController InputController => inputController;
    public PlayerMovement Movement => movement;
    public PlayerAttackController AttackController => attackController;

    private void Awake()
    {
        GameManager.instance.Player = this;
    }

    public override State InitialState(StateMachine stateMachine)
    {
        return new RunPlayerState(this, stateMachine);
    }

    public override State DamagedState(StateMachine stateMachine)
    {
        return new DamagedPlayerState(this, stateMachine);
    }

    public override State DeathState(StateMachine stateMachine)
    {
        return new DeathPlayerState(this, stateMachine);
    }
}
