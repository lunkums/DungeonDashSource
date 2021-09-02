using UnityEngine;

public class JumpPlayerState : PlayerState
{
    private float groundedCheckDelay = 0.05f;
    private float jumpTime = 0.20f;
    private bool jumpPressed = true;

    public JumpPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Jump")
    {
    }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("player_jump");
    }

    public override void Update()
    {
        groundedCheckDelay -= Time.deltaTime;
        if (!Entity.InputController.JumpPressed)
            jumpPressed = false;
        if (groundedCheckDelay < 0.0f && Entity.Movement.IsGrounded())
            StateMachine.SetState(new LandPlayerState(Entity, StateMachine));
        if (Entity.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            StateMachine.SetState(new FallPlayerState(Entity, StateMachine));
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        jumpTime -= Time.fixedDeltaTime;
        if (jumpTime > 0.0f && jumpPressed)
            Entity.Movement.Jump();
    }
}
