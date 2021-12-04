using UnityEngine;

public sealed class EntityStateHandler : MonoBehaviour
{
    [SerializeField] private Entity entity;
    private StateMachine stateMachine;

    private void OnEnable()
    {
        stateMachine = new StateMachine(entity);
    }

    private void Update()
    {
        stateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdate();
    }

    public void SetDamagedState()
    {
        stateMachine.SetState(entity.DamagedState(stateMachine));
    }

    public void SetDeathState()
    {
        stateMachine.SetState(entity.DeathState(stateMachine));
    }
}
