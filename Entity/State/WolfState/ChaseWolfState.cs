public class ChaseWolfState : GroundedWolfState
{
    public ChaseWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Run")
    {
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity(1.10f);
    }

    public override void Update()
    {
        base.Update();
        if (Entity.Input.IsPlayerInAttackRange())
            StateMachine.SetState(new AnticipationWolfState(Entity, StateMachine));
        else if (Entity.Input.IsPlayerBehind() && GameManager.instance.Player.Movement.IsGrounded())
            StateMachine.SetState(new RetreatWolfState(Entity, StateMachine));
    }
}
