public abstract class BatState : AnimatedState<Bat>
{
    public BatState(Bat entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger) { }

    public override void FixedUpdate()
    {
        Entity.Movement.SetVelocity();
    }

    public override void Update() { }
}
