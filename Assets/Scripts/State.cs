public abstract class State
{
    protected PlayerStateMachine stateMachine;
    protected ZombieStateMachine zmStateMachine;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(PlayerStateMachine sm)
    {
        this.stateMachine = sm;
    }

    public State(ZombieStateMachine sm)
    {
        this.zmStateMachine = sm;
    }

}
