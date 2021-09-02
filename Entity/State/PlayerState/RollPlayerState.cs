public class RollPlayerState : GroundedPlayerState
{
    public RollPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Roll")
    {
    }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("player_roll");
        Entity.Movement.EnableRollHurtbox(true);
    }

    public override void Exit()
    {
        base.Exit();
        Entity.Movement.EnableRollHurtbox(false);
    }

    public override void Update()
    {
        if (Entity.Movement.IsGrounded())
        {
            if (Entity.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                StateMachine.SetState(new RunPlayerState(Entity, StateMachine));
            else if (Entity.InputController.Jump)
                StateMachine.SetState(new JumpPlayerState(Entity, StateMachine));
        }
        else
        {
            StateMachine.SetState(new FallPlayerState(Entity, StateMachine));
        }
    }
}
