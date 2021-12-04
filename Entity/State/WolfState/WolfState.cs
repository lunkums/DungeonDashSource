public abstract class WolfState : AnimatedState<Wolf>
{
    public WolfState(Wolf entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger) { }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity();
    }

    public override void Update() { }
}
