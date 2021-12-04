public class SearchWolfState : GroundedWolfState
{
    public SearchWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Idle") { }

    public override void Update()
    {
        base.Update();
        if (Entity.Input.IsPlayerInSearchRange())
        {
            if (Entity.Input.IsPlayerBehind())
                StateMachine.SetState(Entity.RetreatState(StateMachine));
            else
                StateMachine.SetState(Entity.ChaseState(StateMachine));
        }
    }
}
