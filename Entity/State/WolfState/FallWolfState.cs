public class FallWolfState : WolfState
{
    public FallWolfState(Wolf entity, StateMachine stateMachine, string animatorBoolean = "Fall") : base(entity, stateMachine, animatorBoolean)
    {
    }

    public override void Update()
    {
        if (Entity.Movement.IsGrounded())
            StateMachine.SetState(new LandWolfState(Entity, StateMachine));
    }
}
