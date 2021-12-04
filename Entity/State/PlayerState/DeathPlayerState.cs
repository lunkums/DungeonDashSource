public class DeathPlayerState : PlayerState
{
    public DeathPlayerState(Player entity, StateMachine stateMachine) : base(entity, stateMachine, "Death") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Movement.Stop();
        Entity.InputController.EnableInput(false);
        Entity.Audio.Play("player_death");
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity(0);
    }

    public override void Update() { }
}