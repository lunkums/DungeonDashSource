public class FlyArrowState : ArrowState
{
    public FlyArrowState(Arrow entity, StateMachine stateMachine) : base(entity, stateMachine, "Fly") { }

    public override void FixedUpdate()
    {
        Entity.Movement.SetXVelocity();

        if (!Entity.Renderer.isVisible)
            Entity.Movement.MoveTowardsPlayer();
    }

    public override void Update() { }
}
