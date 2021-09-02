public class RetreatWolfState : GroundedWolfState
{
    public RetreatWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Run")
    {
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity(.5f);
    }

    public override void Update()
    {
        base.Update();
        if (!Entity.Input.IsPlayerBehind() && GameManager.instance.Player.Movement.IsGrounded())
            StateMachine.SetState(new ChaseWolfState(Entity, StateMachine));
    }
}
