using UnityEngine;

public class JumpPlayerState : PlayerState
{
    private float groundedCheckDelay;
    private float jumpTime;
    private bool jumpPressed;

    public JumpPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Jump") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("player_jump");
        groundedCheckDelay = 0.05f;
        jumpTime = 0.20f;
        jumpPressed = true;
        Entity.DustParticles.Play();
    }

    public override void Update()
    {
        groundedCheckDelay -= Time.deltaTime;
        jumpTime -= Time.deltaTime;
        if (!Entity.InputController.JumpPressed)
            jumpPressed = false;
        if (groundedCheckDelay < 0.0f && Entity.Movement.IsGrounded())
            StateMachine.SetState(Entity.LandState(StateMachine));
        if (Entity.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            StateMachine.SetState(Entity.FallPlayerState(StateMachine));
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (jumpTime > 0.0f && jumpPressed)
            Entity.Movement.Jump();
    }
}
