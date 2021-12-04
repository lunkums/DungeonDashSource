using UnityEngine;

public class Arrow : Entity
{
    private FlyArrowState flyArrowState;
    private DeathArrowState deathArrowState;
    [SerializeField] private ArrowMovement arrowMovement;
    [SerializeField] private SpriteRenderer _renderer;

    public ArrowMovement Movement => arrowMovement;
    public SpriteRenderer Renderer => _renderer;

    public override IState DamagedState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override IState DeathState(StateMachine stateMachine)
    {
        return deathArrowState ??= new DeathArrowState(this, stateMachine);
    }

    public override IState InitialState(StateMachine stateMachine)
    {
        return flyArrowState ??= new FlyArrowState(this, stateMachine);
    }
}
