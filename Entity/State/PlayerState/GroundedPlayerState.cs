public abstract class GroundedPlayerState : PlayerState
{
    public GroundedPlayerState(Player entity, StateMachine stateMachine, string animatorBoolean) : base(entity, stateMachine, animatorBoolean)
    {
    }

    public override void Update()
    {
        if (Entity.Movement.IsGrounded())
        {
            if (Entity.InputController.Jump)
                StateMachine.SetState(new JumpPlayerState(Entity, StateMachine));
            else if (Entity.InputController.Roll)
                StateMachine.SetState(new RollPlayerState(Entity, StateMachine));
            else if (Entity.InputController.Attack)
                SetNextAttackState();
            //else if (Entity.InputController.Test)
                //StateMachine.SetState(new DamagedPlayerState(Entity, StateMachine));
        }
        else
        {
            StateMachine.SetState(new FallPlayerState(Entity, StateMachine));
        }
    }

    protected virtual void SetNextAttackState()
    {
        PlayerState nextAttackState = new Attack1PlayerState(Entity, StateMachine);

        if (Entity.AttackController.TimeSinceLastAttack < Entity.AttackController.ComboTimeFrame)
        {
            int nextAttackNumber = Entity.AttackController.LastAttackNumber % 3 + 1;

            switch (nextAttackNumber)
            {
                case 2:
                    nextAttackState = new Attack2PlayerState(Entity, StateMachine);
                    break;
                case 3:
                    nextAttackState = new Attack3PlayerState(Entity, StateMachine);
                    break;
                default:
                    break;
            }
        }

        StateMachine.SetState(nextAttackState);
    }
}
