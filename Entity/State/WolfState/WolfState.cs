public abstract class WolfState : AnimatedState
{
    private Wolf entity;

    public new Wolf Entity => entity;

    public WolfState(Wolf entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger)
    {
        this.entity = entity;
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
    }
}
