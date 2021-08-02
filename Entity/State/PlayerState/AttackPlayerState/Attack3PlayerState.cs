public class Attack3PlayerState : AttackPlayerState
{
    public override int AttackNumber => 3;
    public override float AnticipationTime => 4/7.0f;
    public override float RecoveryTime => 0f;

    public Attack3PlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Attack3")
    {
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
        {
            StateMachine.SetState(new RunPlayerState(Entity, StateMachine));
        }
        else if (!hasAttacked)
        {
            if (IsCurrentAnimationPastTime(AnticipationTime))
            {
                Entity.AttackController.Attack(AttackNumber);
                hasAttacked = true;
            }
        }
    }
}
