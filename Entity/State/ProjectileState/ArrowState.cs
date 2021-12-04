public abstract class ArrowState : AnimatedState<Arrow>
{
    public ArrowState(Arrow entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger) { }

    public override void FixedUpdate()
    {
        Entity.Movement.SetXVelocity();
    }

    public override void Update() { }
}
