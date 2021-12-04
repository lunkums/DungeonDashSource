public class RollPlayerState : GroundedPlayerState
{
    public RollPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Roll") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("player_roll");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (Entity.Movement.IsGrounded())
        {
            if (Entity.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                StateMachine.SetState(Entity.InitialState(StateMachine));
            else if (Entity.InputController.Jump)
                StateMachine.SetState(Entity.JumpState(StateMachine));
            else if (Entity.InputController.FallThrough)
                Entity.Movement.DisablePlatformCollisions();
        }
        else
            StateMachine.SetState(Entity.FallPlayerState(StateMachine));
    }
}
