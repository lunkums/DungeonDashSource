public class DeathWolfState : WolfState
{
    public DeathWolfState(Wolf entity, StateMachine stateMachine) : base(entity, stateMachine, "Death") { }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("wolf_death");
        Entity.Movement.Stop();
    }

    public override void FixedUpdate()
    {
        Entity.Movement.SetForwardVelocity(0);
    }
}
