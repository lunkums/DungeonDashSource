using System;

public class DamagedPlayerState : PlayerState
{
    public DamagedPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, entity.Movement.IsGrounded() ? "Run" : "Fall") { }

    public override void Enter()
    {
        base.Enter();
        string[] hurtSounds = { "hurt1_player", "hurt2_player", "hurt3_player" };
        Random rand = new Random();
        string hurtSound = hurtSounds[rand.Next(hurtSounds.Length)];
        Entity.Audio.Play(hurtSound);
    }

    public override void Update()
    {
        StateMachine.SetState(Entity.Movement.IsGrounded() ? Entity.InitialState(StateMachine) : Entity.FallPlayerState(StateMachine));
    }
}
