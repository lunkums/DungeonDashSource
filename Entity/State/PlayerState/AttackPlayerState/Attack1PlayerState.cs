public class Attack1PlayerState : AttackPlayerState
{
    public override int AttackNumber => 1;
    public override float AnticipationTime => 0.20f;
    public override float RecoveryTime => 0.40f;

    public Attack1PlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Attack")
    {
    }

    protected override void SetNextAttackState()
    {
        if (IsCurrentAnimationPastTime(RecoveryTime))
            StateMachine.SetState(new Attack2PlayerState(Entity, StateMachine));
    }
}
