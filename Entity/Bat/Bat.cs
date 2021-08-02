using UnityEngine;

public class Bat : Entity
{
    [SerializeField] private BatMovement movement;
    [SerializeField] private GameObject hitbox;

    public BatMovement Movement => movement;

    public void EnableHitbox(bool enabled)
    {
        hitbox.SetActive(enabled);
    }

    public override State DamagedState(StateMachine stateMachine)
    {
        return null;
    }

    public override State DeathState(StateMachine stateMachine)
    {
        return new DeathBatState(this, stateMachine);
    }

    public override State InitialState(StateMachine stateMachine)
    {
        return new FlyBatState(this, stateMachine);
    }
}
