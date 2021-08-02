public class RetreatWolfState : WolfState
{
    public RetreatWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Run")
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        Entity.Movement.SetForwardVelocity();
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity(.5f);
    }

    public override void Update()
    {
        if (!Entity.Input.IsPlayerBehind() && GameManager.instance.Player.Movement.IsGrounded())
            StateMachine.SetState(new ChaseWolfState(Entity, StateMachine));
    }
}
