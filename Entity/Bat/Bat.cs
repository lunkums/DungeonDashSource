using UnityEngine;

public class Bat : Entity
{
    private FlyBatState flyState;
    private DeathBatState deathState;

    [SerializeField] private BatMovement movement;
    [SerializeField] private GameObject hitbox;

    public BatMovement Movement => movement;

    private void OnEnable()
    {
        hitbox.SetActive(true);
    }

    public void EnableHitbox(bool enabled)
    {
        hitbox.SetActive(enabled);
    }

    public override IState DamagedState(StateMachine stateMachine)
    {
        return null;
    }

    public override IState DeathState(StateMachine stateMachine)
    {
        return deathState ??= new DeathBatState(this, stateMachine);
    }

    public override IState InitialState(StateMachine stateMachine)
    {
        return flyState ??= new FlyBatState(this, stateMachine);
    }
}
