public abstract class AttackPlayerState : GroundedPlayerState
{
    protected bool hasAttacked = false;

    public abstract int AttackNumber { get; }
    public abstract float AnticipationTime { get; }
    public abstract float RecoveryTime { get; }

    public AttackPlayerState(Player entity, StateMachine stateMachine, string animatorBoolean) : base(entity, stateMachine, animatorBoolean)
    {
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
        {
            StateMachine.SetState(new RunPlayerState(Entity, StateMachine));
        }
        else if (IsCurrentAnimationPastTime(RecoveryTime))
        {
            base.Update();
        }
        else if (!hasAttacked)
        {
            if (IsCurrentAnimationPastTime(AnticipationTime))
            {
                Entity.AttackController.Attack(AttackNumber);
                hasAttacked = true;
            }
            else
            {
                base.Update();
            }
        }
    }

    protected override void SetNextAttackState()
    {
        if (IsCurrentAnimationPastTime(RecoveryTime))
            StateMachine.SetState(new Attack2PlayerState(Entity, StateMachine));
    }
}
