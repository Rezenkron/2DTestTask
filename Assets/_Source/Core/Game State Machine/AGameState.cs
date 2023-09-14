public abstract class AGameState
{
    protected IStateMachine stateMachine;
    public void Setup(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }

    public virtual void Exit() { }

}
