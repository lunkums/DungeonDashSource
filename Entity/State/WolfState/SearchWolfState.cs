public class SearchWolfState : GroundedWolfState
{
    public SearchWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Idle")
    {
    }

    public override void Update()
    {
        base.Update();
        if (Entity.Input.IsPlayerInSearchRange())
        {
            if (Entity.Input.IsPlayerBehind())
                StateMachine.SetState(new RetreatWolfState(Entity, StateMachine));
            else
                StateMachine.SetState(new ChaseWolfState(Entity, StateMachine));
        }
    }
}
