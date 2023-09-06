public abstract class AGameState
{
    public abstract void Enter();

    public abstract void Exit();

    public virtual void Update() { }

    public virtual void FixedUpdate() { }

}
