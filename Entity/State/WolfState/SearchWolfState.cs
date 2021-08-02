public class SearchWolfState : WolfState
{
    public SearchWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Idle")
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (Entity.Input.IsPlayerInSearchRange())
        {
            if (Entity.Input.IsPlayerBehind())
                StateMachine.SetState(new RetreatWolfState(Entity, StateMachine));
            else
                StateMachine.SetState(new ChaseWolfState(Entity, StateMachine));
        }
    }
}
