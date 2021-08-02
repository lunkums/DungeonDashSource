using UnityEngine;

public class JumpPlayerState : PlayerState
{
    private float groundedCheckDelay;

    public JumpPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Jump")
    {
    }

    public override void Enter()
    {
        base.Enter();
        Entity.Movement.Jump();
        groundedCheckDelay = 0.05f;
        Entity.Audio.Play("player_jump");
    }

    public override void Update()
    {
        groundedCheckDelay -= Time.deltaTime;
        if (groundedCheckDelay < 0.0f && Entity.Movement.IsGrounded())
            StateMachine.SetState(new LandPlayerState(Entity, StateMachine));
        if (Entity.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            StateMachine.SetState(new FallPlayerState(Entity, StateMachine));
    }
}
