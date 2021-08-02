public abstract class BatState : AnimatedState
{
    private Bat entity;

    public new Bat Entity => entity;

    public BatState(Bat entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger)
    {
        this.entity = entity;
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetVelocity();
    }
}
