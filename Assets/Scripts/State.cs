public abstract class State
{
    protected PlayerStateMachine stateMachine;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(PlayerStateMachine sm)
    {
        this.stateMachine = sm;
    }

}
