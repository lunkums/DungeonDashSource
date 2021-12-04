public class GroundedWolfState : WolfState
{
    public GroundedWolfState(Wolf entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger) { }

    public override void Update()
    {
        if (!Entity.Movement.IsGrounded())
            StateMachine.SetState(Entity.FallState(StateMachine));
        else if (Entity.Input.IsThereAHole())
            StateMachine.SetState(Entity.JumpState(StateMachine));
    }
}
