public abstract class PlayerState : AnimatedState<Player>
{
    public PlayerState(Player entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger) { }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity();
    }
}
