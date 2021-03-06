public class AttackWolfState: FallWolfState
{
    public AttackWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Attack") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Input.EnableHitbox(true);
        Entity.Movement.Jump();
    }

    public override void Exit()
    {
        base.Exit();
        Entity.Input.EnableHitbox(false);
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity(Entity.Movement.ForwardJumpVelocity);
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
            base.Update();
    }
}
