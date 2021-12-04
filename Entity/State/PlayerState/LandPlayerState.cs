public class LandPlayerState : GroundedPlayerState
{
    public LandPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Land") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("player_land");
        Entity.DustParticles.Play();
    }

    public override void Update()
    {
        if (IsCurrentAnimationPastTime(1.0f))
            StateMachine.SetState(Entity.InitialState(StateMachine));
        else
            base.Update();
    }
}