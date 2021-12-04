public class JumpWolfState : WolfState
{
    public JumpWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Attack") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Movement.Jump(6.0f);
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
            StateMachine.SetState(Entity.FallState(StateMachine));
    }
}
