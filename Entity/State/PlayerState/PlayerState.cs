public abstract class PlayerState : AnimatedState
{
    private Player entity;

    public new Player Entity => entity;

    public PlayerState(Player entity, StateMachine stateMachine, string animatorTrigger) : base(entity, stateMachine, animatorTrigger)
    {
        this.entity = entity;
    }
    
    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity();
    }
}
