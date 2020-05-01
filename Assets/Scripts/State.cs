public abstract class State
{
    protected PlayerStateMachine stateMachine;
    protected ZombieStateMachine zmStateMachine;
    protected BlemmeyStateMachine blStateMachine;

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

    public State(BlemmeyStateMachine sm)
    {
        this.blStateMachine = sm;
    }

}
