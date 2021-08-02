public class StateMachine
{
    private IState currentState;

    public IState CurrentState => currentState;

    public StateMachine(IEntity entity)
    {
        currentState = entity.InitialState(this);
    }

    public void SetState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }
}
