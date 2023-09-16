using System;
using System.Collections.Generic;
using Zenject;

public class GameStateMachine<T> : IStateMachine where T : AGameState
{
    private Dictionary<Type, T> states;
    private AGameState currentState;

    public GameStateMachine
        ([Inject(Id = InjectIdData.PREPARE_STATE_ID)] T prepareState, 
        [Inject(Id = InjectIdData.GAME_STATE_ID)] T gameState)
    {
        states = new Dictionary<Type, T>()
        {
            { typeof(StatePrepare), prepareState },
            { typeof(StateGame), gameState }
        };

        SetupStates();
    }

    private void SetupStates()
    {
        foreach (var state in states)
        {
            state.Value.Setup(this);
        }
    }

    public void ChangeState<T>()
    {
        if (states.ContainsKey(typeof(T)))
        {
            currentState?.Exit();
            currentState = states[typeof(T)];
            currentState.Enter();
        }
    }
}
