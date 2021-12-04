using UnityEngine;

public class Wolf : Entity
{
    private DeathWolfState deathState;
    private SearchWolfState searchState;
    private AttackWolfState attackState;
    private AnticipationWolfState anticipationState;
    private RetreatWolfState retreatState;
    private LandWolfState landState;
    private FallWolfState fallState;
    private JumpWolfState jumpState;
    private ChaseWolfState chaseState;

    [SerializeField] private WolfInput input;
    [SerializeField] private GroundedEntityMovement movement;

    public WolfInput Input => input;
    public GroundedEntityMovement Movement => movement;

    public override IState DamagedState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override IState DeathState(StateMachine stateMachine)
    {
        return deathState ??= new DeathWolfState(this, stateMachine);
    }

    public override IState InitialState(StateMachine stateMachine)
    {
        return searchState ??= new SearchWolfState(this, stateMachine);
    }

    public AttackWolfState AttackState(StateMachine stateMachine)
    {
        return attackState ??= new AttackWolfState(this, stateMachine);
    }

    public AnticipationWolfState AnticipationState(StateMachine stateMachine)
    {
        return anticipationState ??= new AnticipationWolfState(this, stateMachine);
    }

    public RetreatWolfState RetreatState(StateMachine stateMachine)
    {
        return retreatState ??= new RetreatWolfState(this, stateMachine);
    }

    public LandWolfState LandState(StateMachine stateMachine)
    {
        return landState ??= new LandWolfState(this, stateMachine);
    }

    public FallWolfState FallState(StateMachine stateMachine)
    {
        return fallState ??= new FallWolfState(this, stateMachine);
    }

    public JumpWolfState JumpState(StateMachine stateMachine)
    {
        return jumpState ??= new JumpWolfState(this, stateMachine);
    }

    public ChaseWolfState ChaseState(StateMachine stateMachine)
    {
        return chaseState ??= new ChaseWolfState(this, stateMachine);
    }
}
