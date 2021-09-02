public class AnticipationWolfState : GroundedWolfState
{
    public AnticipationWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Anticipation")
    {
    }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("wolf_growl");
    }

    public override void Update()
    {
        base.Update();
        if (IsCurrentAnimationPastTime(1.0f))
            StateMachine.SetState(new AttackWolfState(Entity, StateMachine));
    }
}
