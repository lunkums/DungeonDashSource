public abstract class AttackPlayerState : GroundedPlayerState
{
    protected bool hasAttacked;

    public abstract int AttackNumber { get; }
    public abstract float AnticipationTime { get; }
    public abstract float RecoveryTime { get; }

    public AttackPlayerState(Player entity, StateMachine stateMachine, string animatorBoolean) : base(entity, stateMachine, animatorBoolean) { }

    public override void Enter()
    {
        base.Enter();
        hasAttacked = false;
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
        {
            StateMachine.SetState(Entity.InitialState(StateMachine));
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
}
