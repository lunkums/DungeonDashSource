public class DeathBatState : BatState
{
    public DeathBatState(Bat entity, StateMachine stateMachine) : base(entity, stateMachine, "Death")
    {
    }

    public override void Enter()
    {
        base.Enter();
        Entity.Audio.Play("bat_death");
        Entity.Movement.EnableFreeFall();
        Entity.EnableHitbox(false);
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
    }
}