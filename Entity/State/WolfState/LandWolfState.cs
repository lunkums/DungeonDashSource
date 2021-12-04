public class LandWolfState : GroundedWolfState
{
    public LandWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Land") { }

    public override void Update()
    {
        base.Update();
        if (IsCurrentAnimationPastTime(1.0f))
            StateMachine.SetState(Entity.InitialState(StateMachine));
    }
}
