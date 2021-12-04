public abstract class GroundedPlayerState : PlayerState
{
    public GroundedPlayerState(Player entity, StateMachine stateMachine, string animatorBoolean) : base(entity, stateMachine, animatorBoolean) { }

    public override void Update()
    {
        if (Entity.Movement.IsGrounded())
        {
            if (Entity.InputController.Jump)
                StateMachine.SetState(Entity.JumpState(StateMachine));
            else if (Entity.InputController.Roll)
                StateMachine.SetState(Entity.RollState(StateMachine));
            else if (Entity.InputController.Attack)
                SetNextAttackState();
            else if (Entity.InputController.FallThrough)
                Entity.Movement.DisablePlatformCollisions();
            //else if (Entity.InputController.Test)
                //StateMachine.SetState(new DamagedPlayerState(Entity, StateMachine));
        }
        else
        {
            StateMachine.SetState(Entity.FallPlayerState(StateMachine));
        }
    }

    protected virtual void SetNextAttackState()
    {
        PlayerState nextAttackState = Entity.Attack1State(StateMachine);

        if (Entity.AttackController.TimeSinceLastAttack < Entity.AttackController.ComboTimeFrame)
        {
            int nextAttackNumber = Entity.AttackController.LastAttackNumber % 3 + 1;

            switch (nextAttackNumber)
            {
                case 2:
                    nextAttackState = Entity.Attack2State(StateMachine);
                    break;
                case 3:
                    nextAttackState = Entity.Attack3State(StateMachine);
                    break;
                default:
                    break;
            }
        }

        StateMachine.SetState(nextAttackState);
    }
}
