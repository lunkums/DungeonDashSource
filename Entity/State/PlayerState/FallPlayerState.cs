public class FallPlayerState : PlayerState
{
    public FallPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Fall")
    {
    }

    public override void Update()
    {
        if (Entity.Movement.IsGrounded())
            StateMachine.SetState(new LandPlayerState(Entity, StateMachine));
    }
}