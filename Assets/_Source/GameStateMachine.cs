using UnityEngine;

public class GameStateMachine
{
    public AGameState CurrentState { get; private set; }

    public void Initialize(AGameState startState)
    {
        if (CurrentState != null) return;
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(AGameState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
