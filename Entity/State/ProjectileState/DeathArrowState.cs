public class DeathArrowState : ArrowState
{
    public DeathArrowState(Arrow entity, StateMachine stateMachine) : base(entity, stateMachine, "Death") { }

    public override void FixedUpdate()
    {
        Entity.Movement.SetXVelocity(0f);
    }

    public override void Update() { }
}
