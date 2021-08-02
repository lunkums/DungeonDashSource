public class LandWolfState : WolfState
{
    public LandWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Land")
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
            StateMachine.SetState(new SearchWolfState(Entity, StateMachine));
    }
}
