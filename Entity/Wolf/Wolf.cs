using UnityEngine;

public class Wolf : GroundedEntity
{
    [SerializeField] private WolfInput input;

    public WolfInput Input => input;

    public override State DamagedState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override State DeathState(StateMachine stateMachine)
    {
        return new DeathWolfState(this, stateMachine);
    }

    public override State InitialState(StateMachine stateMachine)
    {
        return new SearchWolfState(this, stateMachine);
    }
}
