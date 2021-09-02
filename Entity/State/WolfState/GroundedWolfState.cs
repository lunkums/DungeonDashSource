public class GroundedWolfState : WolfState
{
    public GroundedWolfState(Wolf entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger)
    {
    }

    public override void Update()
    {
        if (!Entity.Movement.IsGrounded())
            StateMachine.SetState(new FallWolfState(Entity, StateMachine));
        else if (Entity.Input.IsThereAHole())
            StateMachine.SetState(new JumpWolfState(Entity, StateMachine));
    }
}
