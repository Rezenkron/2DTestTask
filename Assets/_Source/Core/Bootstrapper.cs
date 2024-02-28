using UnityEngine;
using VContainer;

public class Bootstrapper : MonoBehaviour
{
    private IStateMachine stateMachine;
    private IInputHandler inputHandler;

    [Inject]
    private void Construct(IStateMachine stateMachine, IInputHandler inputHandler)
    {
        this.stateMachine = stateMachine;
        this.inputHandler = inputHandler;
    }

    private void Start()
    {
        stateMachine.ChangeState<StatePrepare>();
        inputHandler.GetInputHold(true);
        inputHandler.GetInputClick(true);
    }
}
