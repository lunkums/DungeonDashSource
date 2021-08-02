public class Attack2PlayerState : AttackPlayerState
{
    public override int AttackNumber => 2;
    public override float AnticipationTime => 0.25f;
    public override float RecoveryTime => 0.40f;

    public Attack2PlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Attack2")
    {
    }

    protected override void SetNextAttackState()
    {
        if (IsCurrentAnimationPastTime(RecoveryTime))
            StateMachine.SetState(new Attack3PlayerState(Entity, StateMachine));
    }
}
