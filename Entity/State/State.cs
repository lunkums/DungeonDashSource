public abstract class State<E> : IState where E : IEntity
{
    private E entity;
    private StateMachine stateMachine;

    public E Entity => entity;
    public StateMachine StateMachine => stateMachine;

    public State(E entity, StateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();
}
