public abstract class State : IState
{
    private IEntity entity;
    private StateMachine stateMachine;

    public IEntity Entity => entity;
    public StateMachine StateMachine => stateMachine;

    public State(IEntity entity, StateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();
}
